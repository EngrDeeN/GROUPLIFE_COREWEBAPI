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
    public class UnderWrittingController : ControllerBase
    {

        IUnderWrittingRepository IUnderWrittingRepository;
        public UnderWrittingController(IUnderWrittingRepository _IUnderWrittingRepository)
        {
            IUnderWrittingRepository = _IUnderWrittingRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/UnderWritting/GetUnderWrittingList")]
        public ActionResult GetUnderWrittingList()
        {
            var result = IUnderWrittingRepository.GetUnderWrittingList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/UnderWritting/GetUnderWrittingDetails/{UnderWrittingId}")]
        public ActionResult GetUnderWrittingDetails(int UnderWrittingId)
        {
            var result = IUnderWrittingRepository.GetUnderWrittingDetails(UnderWrittingId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/UnderWritting/GetUnderWrittingDetailsByQuotation/{P_IDENTIF_NO}")]
        public ActionResult GetUnderWrittingDetailsByQuotation(string P_IDENTIF_NO)
        {
            var result = IUnderWrittingRepository.GetUnderWrittingDetailsByQuotation(P_IDENTIF_NO);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]  //Added by Shizra Aijaz
        [HttpGet]
        [Route("api/UnderWritting/GetPendingPersons/{Policy_no}")]
        public ActionResult GetPendingPersons(string Policy_no)
        {
            var result = IUnderWrittingRepository.GetPendingPersons(Policy_no);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/UnderWritting/GetUnderWrittingDetailsByRider/{FGQH_QUOTATHDR_CODE}/{P_IDENTIF_NO}")]
        public ActionResult GetUnderWrittingDetailsByRider(string FGQH_QUOTATHDR_CODE, string P_IDENTIF_NO)
        {
            var result = IUnderWrittingRepository.GetUnderWrittingDetailsByRider(FGQH_QUOTATHDR_CODE,P_IDENTIF_NO);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/UnderWritting/PostUnderWritting")]
        public ActionResult PostUnderWritting(UnderWritting UnderWritting)
        {
            var result = IUnderWrittingRepository.PostUnderWritting(UnderWritting);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Under Writting Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/UnderWritting/PutUnderWritting")]
        public ActionResult PutUnderWritting(UnderWritting UnderWritting)
        {
            var result = IUnderWrittingRepository.PutUnderWritting(UnderWritting);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "UnderWritting Updated Successfully."; }
            return Ok(result);
        }


        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/UnderWritting/DeleteUnderWritting/{UnderWrittingId}")]
        public ActionResult DeleteUnderWritting(int UnderWrittingId)
        {
            var result = IUnderWrittingRepository.DeleteUnderWritting(UnderWrittingId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Under Writting Deleted Successfully."; }
            return Ok(result);
        }
        /// <summary>
        /// Adding Under Writing doc 
        /// </summary>
        /// <param name="UnderWrittingId"></param>
        /// <returns></returns>

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/UnderWritting/PostUnderWrittingDocument")]
        public ActionResult PostUnderWrittingDocument(UnderWritt_Doc UnderWritt_Doc)
        {
            var result = IUnderWrittingRepository.PostUnderWrittingDocument(UnderWritt_Doc);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Under Writting Document Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/UnderWritting/PutUnderWrittingDocument")]
        public ActionResult PutUnderWrittingDocument(UnderWritt_Doc UnderWritt_Doc)
        {
            var result = IUnderWrittingRepository.PutUnderWrittingDocument(UnderWritt_Doc);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "UnderWritting Document Updated Successfully."; }
            return Ok(result);
        }


        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/UnderWritting/DeleteUnderWrittingDocument/{UnderWritt_DocId}")]
        public ActionResult DeleteUnderWrittingDocument(int UnderWritt_DocId)
        {
            var result = IUnderWrittingRepository.DeleteUnderWrittingDocument(UnderWritt_DocId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Under Writting Document Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]  //Added by Shizra Aijaz
        [HttpGet]
        [Route("api/UnderWritting/Get_NewOrDelete_Customer/{Policy_no}")]
        public ActionResult Get_NewOrDelete_Customer(string Policy_no)
        {
            var result = IUnderWrittingRepository.GetPendingPersons(Policy_no);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}