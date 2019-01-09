using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SmartQA.Models.Forms
{
    public class DocumentAttachmentsUpload
    {        
        public ICollection<IFormFile> File { get; set; }        
    }
        
}