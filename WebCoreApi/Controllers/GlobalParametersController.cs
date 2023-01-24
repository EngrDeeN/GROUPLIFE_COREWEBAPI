using WebCoreApi.Repositories;
using WebCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using WebCoreApi.DAORespositories;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class GlobalParametersController : ControllerBase
    {
        IGlobalParametersRepository globalParamRepository;
        public GlobalParametersController(IGlobalParametersRepository _globalParamRepository)
        {
            globalParamRepository = _globalParamRepository;
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GlobalParameters/GetLocationList/{FSCH_SYS_CODE_HID}")]
        public ActionResult GetLocationList(int FSCH_SYS_CODE_HID)
        {
            var result = globalParamRepository.GetLocationList(FSCH_SYS_CODE_HID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GlobalParameters/GetGlobalParamByCategory/{categoryCode}")]
        public ActionResult GetGlobalParamByCategory(string categoryCode)
        {
            var result = globalParamRepository.GetGlobalParamByCategory(categoryCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
       
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GlobalParameters/GetGlobalParamByCatType/{categoryCode}/{typeCode}")]
        public ActionResult GetGlobalParamByCatType(string categoryCode, string typeCode)
        {
            var result = globalParamRepository.GetGlobalParamByCatType(categoryCode, typeCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GlobalParameters/GetGlobalParamGetCurrencyList")]
        public ActionResult GetCurrencyList()
        {
            var result = globalParamRepository.GetCurrencyList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
