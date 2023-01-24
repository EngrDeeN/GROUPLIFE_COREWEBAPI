using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class QuotaProcessController : ControllerBase
    {
        readonly IQuotaProcessRepository iQuotaProcessRepository;
        public QuotaProcessController(IQuotaProcessRepository _iQuotaProcessRepository)
        {
            iQuotaProcessRepository = _iQuotaProcessRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PolicyGenrtWithQuotationId")]
        public ActionResult PostQuotaProcessPolicyGenrtWithQuotationId(PolicyGeneration PolicyGeneration)
        {
            var result = iQuotaProcessRepository.PostQuotaProcessPolicyGenrtWithQuotationId(PolicyGeneration);

            if (result == null)
            {
                return NotFound();
            }//else { result = "Policy Successfully Generated."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PostQuotaProcessPolicy")]
        public ActionResult PostQuotaProcessPolicy(PolicyGeneration policyGeneration)
        {
            var result = iQuotaProcessRepository.PostQuotaProcessPolicy(policyGeneration);

            if (result == null)
            {
                return NotFound();
            }else { result = "Quotation Process Successfully Run."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotaProcess/GetQuotaProcessList")]
        public ActionResult GetQuotaProcessList()
        {
            var result = iQuotaProcessRepository.GetQuotaProcessList();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotaProcess/GetQuotaProcessDetails/{QuotaProcessId}")]
        public ActionResult GetQuotaProcessDetails(string QuotaProcessId)
        {
            var result = iQuotaProcessRepository.GetQuotaProcessDetails(QuotaProcessId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PostQuotaProcess")]
        public ActionResult PostQuotaProcess(QuotaProcess QuotaProcess)
        {
            var result = iQuotaProcessRepository.PostQuotaProcess(QuotaProcess);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Saved Successfully.";             }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PutQuotaProcess")]
        public ActionResult PutQuotaProcess(QuotaProcess QuotaProcess)
        {
            var result = iQuotaProcessRepository.PutQuotaProcess(QuotaProcess);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/QuotaProcess/DeleteQuotaProcess/{QuotationId}")]
        public ActionResult DeleteQuotaProcess(int QuotaProcessId)
        {
            var result = iQuotaProcessRepository.DeleteQuotaProcess(QuotaProcessId);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        //Quotation Process  FCL
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotaProcess/GetQuotaProcessFLCList")]
        public ActionResult GetQuotaProcessFLCList()
        {
            var result = iQuotaProcessRepository.GetQuotaProcessFLCList();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotaProcess/GetQuotatFCLDtls/{QuotationCode}")]
        public ActionResult GetQuotatFCLDtls(string QuotationCode)
        {
            var result = iQuotaProcessRepository.GetQuotatFCLDtls(QuotationCode);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PostQuotaFLCProcess")]
        public ActionResult PostQuotaFLCProcess(QuotationProcessFCL QuotationProcessFCL)
        {
            var result = iQuotaProcessRepository.PostQuotaFLCProcess(QuotationProcessFCL);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PutQuotaFLCProcess")]
        public ActionResult PutQuotaFLCProcess(QuotationProcessFCL QuotationProcessFCL)
        {
            var result = iQuotaProcessRepository.PutQuotaFLCProcess(QuotationProcessFCL);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/QuotaProcess/DeleteQuotaFLCProcess/{QuotaProFCLId}")]
        public ActionResult DeleteQuotaFLCProcess(int QuotaProFCLId)
        {
            var result = iQuotaProcessRepository.DeleteQuotaFLCProcess(QuotaProFCLId);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        //Unite Rate Of Quotation Process
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotaProcess/GetQuotaProcessUnitRateList")]
        public ActionResult GetQuotaProcessUnitRateList()
        {
            var result = iQuotaProcessRepository.GetQuotaProcessUnitRateList();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotaProcess/GetQuotatUnitRateLimitDtls/{QuotationCode}")]
        public ActionResult GetQuotatUnitRateLimitDtls(string QuotationCode)
        {
            var result = iQuotaProcessRepository.GetQuotatUnitRateLimitDtls(QuotationCode);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PostQuotaProcessUR")]
        public ActionResult PostQuotaProcessUR(QuotationProcessUnitRate QuotationProcessUnitRate)
        {
            var result = iQuotaProcessRepository.PostQuotaProcessUR(QuotationProcessUnitRate);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Process Successfully Run."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/PutQuotaProcessUR")]
        public ActionResult PutQuotaProcessUR(QuotationProcessUnitRate QuotationProcessUnitRate)
        {
            var result = iQuotaProcessRepository.PutQuotaProcessUR(QuotationProcessUnitRate);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/QuotaProcess/DeleteQuotaProcessUR/{QuotaProcessUniteRateId}")]
        public ActionResult DeleteQuotaProcessUR(int QuotaProcessUniteRateId)
        {
            var result = iQuotaProcessRepository.DeleteQuotaProcessUR(QuotaProcessUniteRateId);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotaProcess/CreateDuplicationQuoation")]
        public ActionResult CreateDuplicationQuoation(PolicyIssuance request)
        {
            var result = iQuotaProcessRepository.CreateDuplicationQuoation(request);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Created Duplicate Successfully."; }
            return Ok(result);
        }
    }
}
