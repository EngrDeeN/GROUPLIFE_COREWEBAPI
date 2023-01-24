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
    public class CityController : ControllerBase
    {
        ICityRepository cityRepository;
        public CityController(ICityRepository _cityRepository)
        {
            cityRepository = _cityRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/City/GetCityList")]
        public ActionResult GetCityList()
        {
            var result = cityRepository.GetCityList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/City/GetCityDetails/{cityId}")]
        public ActionResult GetCityDetails(int cityId)
        {
            var result = cityRepository.GetCityDetails(cityId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/City/GetCityDetailsByProvCont/{provinceId}/{countryId}")]
        public ActionResult GetCityDetailsByProvCont(int provinceId, int countryId)
        {
            var result = cityRepository.GetCityDetailsByProvCont(provinceId, countryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/City/PostCity")]
        public ActionResult PostCity(City city)
        {
            var result = cityRepository.PostCity(city);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "City Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/City/PutCity")]
        public ActionResult PutCity(City city)
        {
            var result = cityRepository.PutCity(city);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "City Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/City/DeleteCity/{cityId}")]
        public ActionResult DeleteCity(int cityId)
        {
            var result = cityRepository.DeleteCity(cityId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "City Deleted Successfully."; }
            return Ok(result);
        }
    }
}
