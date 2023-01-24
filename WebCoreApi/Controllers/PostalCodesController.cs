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
    public class PostalCodesController : ControllerBase
    {
        IPostalCodesRepository postalCodesRepository;
        public PostalCodesController(IPostalCodesRepository _postalCodesRepository)
        {
            postalCodesRepository = _postalCodesRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/PostalCodes/GetPostalCodeList")]
        public ActionResult GetPostalCodeList()
        {
            var result = postalCodesRepository.GetPostalCodeList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/PostalCodes/GetPostalCodeDetails/{postalCodeId}")]
        public ActionResult GetPostalCodeDetails(int postalCodeId)
        {
            var result = postalCodesRepository.GetPostalCodeDetails(postalCodeId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/PostalCodes/GetPostCodeDtlByCtyProvCont/{cityId}/{provinceId}/{countryId}")]
        public ActionResult GetPostCodeDtlByCtyProvCont(int cityId, int provinceId, int countryId)
        {
            var result = postalCodesRepository.GetPostCodeDtlByCtyProvCont(cityId, provinceId, countryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/PostalCodes/PostPostalCode")]
        public ActionResult PostPostalCode(PostalCodes postalCodes)
        {
            var result = postalCodesRepository.PostPostalCode(postalCodes);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Postal Code Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/PostalCodes/PutPostalCode")]
        public ActionResult PutPostalCode(PostalCodes postalCodes)
        {
            var result = postalCodesRepository.PutPostalCode(postalCodes);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Postal Code Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/PostalCodes/DeletePostalCode/{postalCodeId}")]
        public ActionResult DeletePostalCode(int postalCodeId)
        {
            var result = postalCodesRepository.DeletePostalCode(postalCodeId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Postal Code Deleted Successfully."; }
            return Ok(result);
        }
    }
}
