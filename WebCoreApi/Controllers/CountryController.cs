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
    public class CountryController : ControllerBase
    {
        ICountryRepository countryRepository;
        public CountryController(ICountryRepository _countryRepository)
        {
            countryRepository = _countryRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Country/GetCountryList")]
        public ActionResult GetCountryList()
        {
            var result = countryRepository.GetCountryList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Country/GetCountryDetails/{countryId}")]
        public ActionResult GetCountryDetails(int countryId)
        {
            var result = countryRepository.GetCountryDetails(countryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Country/PostCountry")]
        public ActionResult PostCountry(Country country)
        {
            var result = countryRepository.PostCountry(country);
            if (result == null)
            {
                return NotFound();
            } else { result = "Country Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Country/PutCountry")]
        public ActionResult PutCountry(Country country)
        {
            var result = countryRepository.PutCountry(country);
            if (result == null)
            {
                return NotFound();
            } else { result = "Country Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/Country/DeleteCountry/{countryId}")]
        public ActionResult DeleteCountry(int countryId)
        {
            var result = countryRepository.DeleteCountry(countryId);
            if (result == null)
            {
                return NotFound();
            } else { result = "Country Deleted Successfully."; }
            return Ok(result);
        }
    }
}
