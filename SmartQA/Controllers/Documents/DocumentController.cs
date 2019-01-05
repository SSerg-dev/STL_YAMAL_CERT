using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.People;
using SmartQA.Models;

namespace SmartQA.Controllers.Documents
{
    public class DocumentController : CommonEntityODataController<Document, DocumentEdit>
    {
        public DocumentController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {}

        public override IQueryable<Document> GetQuery()
            => base.GetQuery()                
                .Include(d => d.DocumentStatusSet)
                .ThenInclude(ds => ds.Status);

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