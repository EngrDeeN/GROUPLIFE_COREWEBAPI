using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.DAORespositories;
using WebCoreApi.Models;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CustomerFileUploadController : ControllerBase
    {
        ICustomerFileUploadingRepository customerFileUploadingRepository;
        public CustomerFileUploadController(ICustomerFileUploadingRepository _customerFileUploadingRepository)
        {
            customerFileUploadingRepository = _customerFileUploadingRepository;
        }


        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/CustomerFile/UploadCustomerFile")]
        public IActionResult PostUploadCustomerFile(CustomerFileUploading customerFileUploading)
        {
            var result = customerFileUploadingRepository.PostUploadCustomerFile(customerFileUploading);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Successfully Uploaded"; }
            return Ok(result);

        }
    }
}
