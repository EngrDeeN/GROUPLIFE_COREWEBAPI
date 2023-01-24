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
    public class QuotAgentDetlController : ControllerBase
    {

        IQuotAgentDetlRepository iQuotAgentDetlRepository;
        public QuotAgentDetlController(IQuotAgentDetlRepository _iQuotAgentDetlRepository)
        {
            iQuotAgentDetlRepository = _iQuotAgentDetlRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotAgentDetl/GetQuotAgentDetl/{QuotationId}")]
        public ActionResult GetQuotAgentDetails(int QuotationId)
        {
            var result = iQuotAgentDetlRepository.GetQuotAgentDetDetails(QuotationId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotAgentDetl/PostQuotAgentDetl")]
        public ActionResult PostQuotAgentDetl(QuotAgentDetl quotAgentDetl)
        {
            var result = iQuotAgentDetlRepository.PostQuotAgentDet(quotAgentDetl);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotAgentDetl/PutQuotAgentDetl")]
        public ActionResult PutQuotAgentDetl(QuotAgentDetl quotAgentDetl)
        {
            var result = iQuotAgentDetlRepository.PutQuotAgentDet(quotAgentDetl);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Updated Successfully."; }
            return Ok(result);
        }
    }
}
