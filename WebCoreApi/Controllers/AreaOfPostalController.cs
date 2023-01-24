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
    public class AreaOfPostalController : ControllerBase
    {
        IAreaOfPostalRepository areaOfpostalRepository;
        public AreaOfPostalController(IAreaOfPostalRepository _areaOfpostalRepository)
        {
            areaOfpostalRepository = _areaOfpostalRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/AreaOfPostal/GetAreaOfPostalList")]
        public ActionResult GetAreaOfPostalList()
        {
            var result = areaOfpostalRepository.GetAreaOfPostalList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/AreaOfPostal/GetAreaOfPostalDetails/{areaOfPostalId}")]
        public ActionResult GetAreaOfPostalDetails(int areaOfPostalId)
        {
            var result = areaOfpostalRepository.GetAreaOfPostalDetails(areaOfPostalId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/AreaOfPostal/GetAreaOfPostalDtlByPostalCode/{postalCodeId}")]
        public ActionResult GetAreaOfPostalDtlByPostalCode(int postalCodeId)
        {
            var result = areaOfpostalRepository.GetAreaOfPostalDtlByPostalCode(postalCodeId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/AreaOfPostal/PostAreaOfPostal")]
        public ActionResult PostAreaOfPostal(AreaOfPostal areaOfPostal)
        {
            var result = areaOfpostalRepository.PostAreaOfPostal(areaOfPostal);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Area of Postal Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/AreaOfPostal/PutAreaOfPostal")]
        public ActionResult PutAreaOfPostal(AreaOfPostal areaOfPostal)
        {
            var result = areaOfpostalRepository.PutAreaOfPostal(areaOfPostal);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Area of Postal Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/AreaOfPostal/DeleteAreaOfPostal/{areaOfPostalId}")]
        public ActionResult DeleteAreaOfPostal(int areaOfPostalId)
        {
            var result = areaOfpostalRepository.DeleteAreaOfPostal(areaOfPostalId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Area of Postal Deleted Successfully."; }
            return Ok(result);
        }
    }
}
