using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartQA.Auth;
using SmartQA.Controllers.Shared;
using SmartQA.DB;
using SmartQA.DB.Models.Documents;
using SmartQA.DB.Models.Files;
using SmartQA.Files;
using SmartQA.Models;
using SmartQA.Models.Forms;

namespace SmartQA.Controllers.Documents
{
    public class DocumentAttachmentController : CommonEntityODataController<DocumentAttachment, DocumentAttachmentEdit>
    {
        private readonly AppSettings _appSettings;
        
        public DocumentAttachmentController(DataContext context, AppUserManager userManager,           
            IOptions<AppSettings> appSettings) : base(context, userManager)
        {
            _appSettings = appSettings.Value;
        }                         
            
        
    }
}