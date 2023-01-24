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
    public class QuotationController : ControllerBase
    {
        readonly IQuotationRepository iQuotationRepository;
        public QuotationController(IQuotationRepository _iQuotationRepository)
        {
            iQuotationRepository = _iQuotationRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Quotation/GetAgentList")]
        public ActionResult GetAgentList()
        {
            var result = iQuotationRepository.GetAgentList();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Quotation/GetQuotationList")]
        public ActionResult GetQuotationList()
        {
            var result = iQuotationRepository.GetQuotationList();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Quotation/GetQuotationDetails/{QuotationCode}")]
        public ActionResult GetQuotationDetails(string QuotationCode)
        {
            var result = iQuotationRepository.GetQuotationDetails(QuotationCode);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Quotation/GetQuotatPlanDtls/{QuotationCode}")]
        public ActionResult Get_Quotat_Plan_Dtls(string QuotationCode)
        {
            var result = iQuotationRepository.Get_Quotat_Plan_Dtls(QuotationCode);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Quotation/PostQuotation")]
        public ActionResult PostQuotation(QuotationHDR Quotation)
        {
            var result = iQuotationRepository.PostQuotations(Quotation);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Saved Successfully.";             }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Quotation/PutQuotation")]
        public ActionResult PutQuotation(QuotationHDR Quotation)
        {
            var result = iQuotationRepository.PutQuotations(Quotation);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/Quotation/DeleteQuotation/{QuotationId}")]
        public ActionResult DeleteQuotation(int QuotationId)
        {
            var result = iQuotationRepository.DeleteQuotations(QuotationId);

            if (result == null)
            {
                return NotFound();
            }
            else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotationRider/GetQuotaRiderDetails/{QUOTATION_ID}/{FGQG_COMPGRP_ID}")]
        public ActionResult GetQuotaRiderDetails(int QUOTATION_ID, int FGQG_COMPGRP_ID)
        {
            var result = iQuotationRepository.GetQuotaRiderDetails(QUOTATION_ID, FGQG_COMPGRP_ID);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotationRider/PostQuotaRider")]
        public ActionResult PostQuotaRider(Quotation_Rider Quoatation_Rider)
        {
            var result = iQuotationRepository.PostQuotaRider(Quoatation_Rider);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotationRider/PutQuotaRider")]
        public ActionResult PutQuotaRider(Quotation_Rider Quoatation_Rider)
        {
            var result = iQuotationRepository.PutQuotaRider(Quoatation_Rider);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotationEvent/GetQuotaEventList/{ListCode}")]
        public ActionResult GetQuotaEventList(int ListCode)
        {
            var result = iQuotationRepository.GetQuotaEventList(ListCode);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/QuotationEvent/GetQuotaEventDetails/{QUOTATION_CODE}/{FGQG_COMPGRP_ID}")]
        public ActionResult GetQuotaEventDetails(int QUOTATION_CODE, int FGQG_COMPGRP_ID)
        {
            var result = iQuotationRepository.GetQuotaEventDetails(QUOTATION_CODE, FGQG_COMPGRP_ID);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotationEvent/PostQuotaEvent")]
        public ActionResult PostQuotaEvent(Quotation_Event Quotation_Event)
        {
            var result = iQuotationRepository.PostQuotaEvent(Quotation_Event);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/QuotationEvent/PutQuotaEvent")]
        public ActionResult PutQuotaEvent(Quotation_Event Quotation_Event)
        {
             var result = iQuotationRepository.PutQuotaEvent(Quotation_Event);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Quotation Deleted Successfully."; }
            return Ok(result);
        }

    }
}