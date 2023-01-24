using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class InquiryController : ControllerBase
    {

        IInquiryRepository Inquiry_Repository;
        public InquiryController(IInquiryRepository _IInquiryRepository)
        {
            Inquiry_Repository = _IInquiryRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Inquiry/GetInquiryDetails/{QUOTATHDR_CODE}")]
        public ActionResult GetInquiryDetails(string QUOTATHDR_CODE)
        {
            var result = Inquiry_Repository.GetInquiryDetails(QUOTATHDR_CODE);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Inquiry/Get_Inquiry_Member_Details/{QUOTATHDR_CODE}")]
        public ActionResult Get_Inquiry_Member_Details(string QUOTATHDR_CODE)
        {
            var result = Inquiry_Repository.Get_Inquiry_Member_Details(QUOTATHDR_CODE);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Inquiry/Get_Inquiry_Pending_Member_Details/{QUOTATHDR_CODE}")]
        public ActionResult Get_Inquiry_Pending_Member_Details(string QUOTATHDR_CODE)
        {
            var result = Inquiry_Repository.Get_Inquiry_Pending_Member_Details(QUOTATHDR_CODE);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Inquiry/Get_Inquiry_Rider_Details/{QUOTATHDR_ID}")]
        public ActionResult Get_Inquiry_Rider_Details(int QUOTATHDR_ID)
        {
            var result = Inquiry_Repository.Get_Inquiry_Rider_Details(QUOTATHDR_ID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
