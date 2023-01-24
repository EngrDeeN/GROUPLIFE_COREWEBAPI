using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using WebCoreApi.DAORespositories;

namespace WebCoreApi.Repositories
{
    public class FileUploadRepoistory : IFileUploadRepoistory
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        IConfiguration configuration;

        public FileUploadRepoistory(IWebHostEnvironment webHostEnvironment, IConfiguration _configuration)
        {
            this._webHostEnvironment = webHostEnvironment;
            this.configuration = _configuration;
        }

        public object OnPostMyUploader(IFormFile MyUploader)
        {
            string uploadsFolder;
            try
            {
                if (MyUploader != null)
                {
                    uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "FileUpload");
                    string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        MyUploader.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception )
            {
                //throw ex;
                return new ObjectResult(new { status = "fail" });
                //result = "Failed to load list or operation " + ex.Message;
            }
            return new ObjectResult(new { status = "success" });
            //return result;
        }
    }
}
