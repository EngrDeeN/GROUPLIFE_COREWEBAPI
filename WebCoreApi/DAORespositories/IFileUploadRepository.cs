using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IFileUploadRepoistory
    {
        public object OnPostMyUploader(IFormFile MyUploader);
    }
}
