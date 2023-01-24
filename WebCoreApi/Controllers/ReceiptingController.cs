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
    public class ReceiptingController : ControllerBase
    {
        IReceiptingRepository receiptingRepository;
        public ReceiptingController(IReceiptingRepository _receiptingRepository)
        {
            receiptingRepository = _receiptingRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Receipting/GetReceiptingList")]
        public ActionResult GetReceiptingList()
        {
            var result = receiptingRepository.GetReceiptingList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Receipting/GetReceiptingDetails/{ReceiptId}")]
        public ActionResult GetReceiptingDetails(int ReceiptId)
        {
            var result = receiptingRepository.GetReceiptingDetails(ReceiptId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Receipting/GetReceiptingDetailsByQuotation/{QuotationCode}")]
        public ActionResult GetReceiptingDetailsByQuotation(string QuotationCode)
        {
            var result = receiptingRepository.GetReceiptingDetailsByQuotation(QuotationCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Receipting/PostReceipting")]
        public ActionResult PostReceipting(Receipting Receipting)
        {
            var result = receiptingRepository.PostReceipting(Receipting);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Receipt Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Receipting/PutReceipting")]
        public ActionResult PutReceipting(Receipting Receipting)
        {
            var result = receiptingRepository.PutReceipting(Receipting);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Receipt Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/Receipting/DeleteReceipting/{ReceiptId}")]
        public ActionResult DeleteReceipting(int ReceiptId)
        {
            var result = receiptingRepository.DeleteReceipting(ReceiptId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Receipt Deleted Successfully."; }
            return Ok(result);
        }


        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Receipting/Get_Bank_List/")]
        public ActionResult Get_Bank_List()
        {
            var result = receiptingRepository.Get_Bank_List();
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Receipt Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Receipting/GET_VOUCHER_LIST/")]
        public ActionResult GET_VOUCHER_LIST()
        {
            var result = receiptingRepository.GET_VOUCHER_LIST();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Receipting/Get_Valid_Quotation_List/{Document_Id}/{VoucherId}")]
        public ActionResult Get_Valid_Quotation_List(string Document_Id,string VoucherId)
        {
            var result = receiptingRepository.Get_Valid_Quotation_List(Document_Id, VoucherId);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Receipt Deleted Successfully."; }
            return Ok(result);
        }
    }
}
