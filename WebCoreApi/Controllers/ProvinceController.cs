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
    public class ProvinceController : ControllerBase
    {
        IProvinceRepository provinceRepository;
        public ProvinceController(IProvinceRepository _provinceRepository)
        {
            provinceRepository = _provinceRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Province/GetProvinceList")]
        public ActionResult GetProvinceList()
        {
            var result = provinceRepository.GetProvinceList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Province/GetProvinceDetails/{provinceId}/{countryId}")]
        public ActionResult GetProvinceDetails(int provinceId, int countryId)
        {
            var result = provinceRepository.GetProvinceDetails(provinceId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Province/GetProvinceDetailsByCont/{countryId}")]
        public ActionResult GetProvinceDetails(int countryId)
        {
            var result = provinceRepository.GetProvinceDetailsByCont(countryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Province/PostProvince")]
        public ActionResult PostProvince(Province province)
        {
            var result = provinceRepository.PostProvince(province);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Province Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Province/PutProvince")]
        public ActionResult PutProvince(Province province)
        {
            var result = provinceRepository.PutProvince(province);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Province Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/Province/DeleteProvince/{provinceId}")]
        public ActionResult DeleteProvince(int provinceId)
        {
            var result = provinceRepository.DeleteProvince(provinceId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Province Deleted Successfully."; }
            return Ok(result);
        }
    }
}
