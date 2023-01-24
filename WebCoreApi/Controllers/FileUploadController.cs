using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.DAORespositories;

namespace WebCoreApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        IFileUploadRepoistory iFileUploadRepoistory;

        public FileUploadController(IFileUploadRepoistory _iFileUploadRepoistory)
        {
            this.iFileUploadRepoistory = _iFileUploadRepoistory;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/FileUpload/SaveImageFile/")]
        public ActionResult SaveImageFile(IFormFile MyUploader)
        {
            var result = iFileUploadRepoistory.OnPostMyUploader(MyUploader);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
