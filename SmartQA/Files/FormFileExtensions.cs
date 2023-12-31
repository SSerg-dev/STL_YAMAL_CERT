using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SmartQA.Files
{
    public static class FormFileExtensions
    {
        private static int DefaultBufferSize = 80 * 1024;
        /// <summary>
        /// Asynchronously saves the contents of an uploaded file.
        /// </summary>
        /// <param name="formFile">The <see cref="IFormFile"/>.</param>
        /// <param name="filename">The name of the file to create.</param>
        public static async Task SaveAsAsync(
            this IFormFile formFile,
            string filename,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            
            if (formFile == null)
            {
                throw new ArgumentNullException(nameof(formFile));
            }
            
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            
            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                var inputStream = formFile.OpenReadStream();
                await inputStream.CopyToAsync(fileStream, DefaultBufferSize, cancellationToken);
            }
        }
    }
}