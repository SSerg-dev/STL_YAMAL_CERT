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
using SmartQA.Models;

namespace SmartQA.Controllers.Documents
{
    public class DocumentUIController : ODataController
    {
        protected readonly DataContext _context;
        protected readonly AppUserManager _userManager;
        
        public DocumentUIController(DataContext context, AppUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [EnableQuery]
        public SingleResult<DocumentUI> Get([FromODataUri] Guid key)
        {
            return SingleResult.Create(GetQuery().Where(x => x.ID == key));            
        }

        [EnableQuery]
        public virtual IQueryable<DocumentUI> Get()
            => GetQuery();       

        public IQueryable<DocumentUI> GetQuery()
        {
            return _context.Set<Document>()
                .Include(d => d.DocumentType)
                .Join(                    
                    _context.Set<DocumentStatus>()
                        .Include(ds => ds.Status)
                        .Where(ds => ds.RowStatus == 0),                    
                    doc => doc.ID,
                    ds => ds.Document_ID,
                    (doc, ds) => new DocumentUI
                    {
                        ID = doc.ID,
                        Document_Code = doc.Document_Code,                                                
                        Document_Date = doc.Document_Date,
                        Document_Name = doc.Document_Name,
                        Document_Number = doc.Document_Number,
                        DocumentType = doc.DocumentType,
                        IsActual = doc.IsActual,
                        Issue_Date = doc.Issue_Date,                        
                        Status = ds.Status
                    }
                );
        }
    }
}