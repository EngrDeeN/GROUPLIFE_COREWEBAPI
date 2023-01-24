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
    public class QuotCompyGrpDetlController : ControllerBase
    {

        IQuotCompyGrpDetlRepository iQuotCompyGrpDetlRepository;
        public QuotCompyGrpDetlController(IQuotCompyGrpDetlRepository _iQuotCompyGrpDetlRepository)
        {
            iQuotCompyGrpDetlRepository = _iQuotCompyGrpDetlRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotCompyGrpDetl/GetQuotCompyGrpDetlDetails/{QuotationId}")]
        public ActionResult GetQuotCompyGrpDetlDetails(int QuotationId)
        {
            var result = iQuotCompyGrpDetlRepository.GetQuotCompyGrpDetlDetails(QuotationId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotCompyGrpDetl/PostQuotCompyGrpDetl")]
        public ActionResult PostQuotCompyGrpDetl(QuotCompyGrpDetl quotCompyGrpDetl)
        {
            var result = iQuotCompyGrpDetlRepository.PostQuotCompyGrpDetl(quotCompyGrpDetl);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotCompyGrpDetl/PutQuotCompyGrpDetl")]
        public ActionResult PutQuotCompyGrpDetl(QuotCompyGrpDetl quotCompyGrpDetl)
        {
            var result = iQuotCompyGrpDetlRepository.PutQuotCompyGrpDetl(quotCompyGrpDetl);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Successfully Updated ."; }
            return Ok(result);
        }
    }
}
