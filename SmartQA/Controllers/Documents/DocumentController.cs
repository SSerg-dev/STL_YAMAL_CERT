using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.Models;

namespace SmartQA.Controllers.Documents
{
    public class DocumentController : CommonEntityODataController<Document, DocumentEdit>
    {
        public DocumentController(DataContext context, AppUserManager userManager) : base(context, userManager)
        {
            
            
        }

        public async Task<IActionResult> Post(DocumentNew form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var now = DateTimeOffset.Now;
            var document = new Document
            {
                ID = Guid.NewGuid(),
                Issue_Date = now,
                Issue_Date_DT = await _context.GetConstructionSiteDT(now),
                DocumentType = await _context.Set<DocumentType>().Where(t => t.Title == "N/A").SingleAsync()
            };
            
            form.Serialize(document);
            
            if (document.Root_ID == Guid.Empty)
            {
                document.Root_ID = document.ID;
            }                                                              

            document.OnSave(_context, await _userManager.Get(User));

            GetDbSet().Add(document);

            await _context.SaveChangesAsync();

            return Created(document);
        }
    }
}