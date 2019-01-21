using System;
using System.IO;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartQA.Auth;
using SmartQA.DB;
using SmartQA.DB.Models.Files;

namespace SmartQA.Controllers.Files
{
    [Route("api/[controller]/[action]")]
    public class FileController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly AppUserManager _userManager;
        private readonly DataContext _context;

        public FileController(
            DataContext context,
            AppUserManager userManager,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public IActionResult Download(string fileDescId)
        {
            var fileDesc = _context.Set<FileDesc>()
                .Find(Guid.Parse(fileDescId));
            if (fileDesc == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(_appSettings.FileStoragePath, fileDesc.FileName);
            var contentType = fileDesc.ContentType.IsNullOrEmpty() ? "application/octet-stream" : fileDesc.ContentType;

            var result = new PhysicalFileResult(filePath, contentType);
            if (!fileDesc.UploadName.IsNullOrEmpty())
            {
                result.FileDownloadName = fileDesc.UploadName;
            }

            return result;
        }
    }
}