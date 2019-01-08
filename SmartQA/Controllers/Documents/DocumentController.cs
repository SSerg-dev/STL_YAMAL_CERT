using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.Files;
using SmartQA.DB.Models.People;
using SmartQA.Files;
using SmartQA.Models;
using SmartQA.Models.Forms;

namespace SmartQA.Controllers.Documents
{
    public class DocumentController : CommonEntityODataController<Document, DocumentEdit>
    {
        private readonly AppSettings _appSettings;
        
        public DocumentController(
            DataContext context,
            AppUserManager userManager,
            IOptions<AppSettings> appSettings) : base(context, userManager)
        {
            _appSettings = appSettings.Value;
        }

        public override IQueryable<Document> GetQuery()
            => base.GetQuery()
                .Include(d => d.DocumentStatusSet)
                .ThenInclude(ds => ds.Status)
                .Include(d => d.Document_to_GOSTSet)
                .ThenInclude(dtg => dtg.GOST)
                .Include(d => d.Document_to_PIDSet)
                .ThenInclude(dtp => dtp.PID);
                        
        [HttpPost]
        [EnableQuery]
        [RequestSizeLimit(1024*1024*1024)]
        public async Task<IQueryable<DocumentAttachment>> UploadAttachments([FromODataUri] Guid key, DocumentAttachmentsUpload fileUpload)
        {                            
            var user = await _userManager.Get(User);                        
            var attachments = new List<DocumentAttachment>();
            
            if (ModelState.IsValid)
            {
                var saveTo = $"DocumentAttachments/{key}";
                
                foreach (var file in fileUpload.File)
                {
                    if (file.Length == 0) continue;
                    
                    var ID = Guid.NewGuid();
                    var uploadName = file.FileName.Trim();
                    var ext = Path.GetExtension(uploadName);
                        
                    var fileName = Path.Combine(saveTo, ID.ToString()).Replace("\\", "/");
                    if (!ext.IsNullOrEmpty()) 
                        fileName += ext;

                    var fileDesc = new FileDesc
                    {
                        ID = ID,
                        ContentType = file.ContentType,
                        FileName = fileName,
                        UploadName = uploadName,
                        Length = file.Length,
                    };                    
                    fileDesc.OnSave(_context, user);
                    
                    var attachment = new DocumentAttachment
                    {
                        FileDesc = fileDesc,
                        Document_ID = key                        
                    };
                    attachment.OnSave(_context, user);
                    
                    var targetPath = Path.Combine(_appSettings.FileStoragePath, fileName);                                             
                    await file.SaveAsAsync(targetPath);
                    
                    attachments.Add(attachment);
                    _context.Add(fileDesc);
                    _context.Add(attachment);
                }
            }

            await _context.SaveChangesAsync();
                                  
            return attachments.AsQueryable();
        }
        
        public async Task<IActionResult> Post(DocumentNew form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Get(User);
            var now = DateTimeOffset.Now;
            var document = new Document
            {
                ID = Guid.NewGuid(),
                Issue_Date = now,                
                Issue_Date_DT = await _context.GetConstructionSiteDT(now),
                DocumentStatusSet = new List<DocumentStatus>(),
                DocumentType = await _context.Set<DocumentType>().Where(t => t.Title == "N/A").SingleAsync(),
                Status = await _context.Set<Status>().SingleAsync(s => s.Status_Code == "wDd"),
                Resp_Employee = await _context.Set<Employee>().FirstOrDefaultAsync(e => e.AppUser_ID == user.Id)                 
            };
                       
            form.Serialize(document, _context);
            
            if (document.Root_ID == Guid.Empty)
            {
                document.Root_ID = document.ID;
            }                                                              

            document.OnSave(_context, user);

            GetDbSet().Add(document);

            await _context.SaveChangesAsync();

            return Created(document);
        }
        
        
    }
}