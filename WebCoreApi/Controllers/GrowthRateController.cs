using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.DAORespositories;
using WebCoreApi.Models;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class GrowthRateController : ControllerBase
    {
        IGrowthRateRepository GROWTH_RATE_REPOSITORY;
        public GrowthRateController(IGrowthRateRepository growth_rate_repository)
        {
            GROWTH_RATE_REPOSITORY = growth_rate_repository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GrowthRate/Get_Rowth_Rates_List")]
        public ActionResult GET_GROWTH_RATE_LIST()
        {
            var result = GROWTH_RATE_REPOSITORY.GET_GROWTH_RATE_LIST();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GrowthRate/Get_Growth_Rates_Details/{growthID}")]
        public ActionResult GET_GROWTH_RATE_DETAILS(int growthID)
        {
            var result = GROWTH_RATE_REPOSITORY.GET_GROWTH_RATE_DETAILS(growthID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GrowthRate/Get_Growth_Rates_Details_byDescp/{growthDescp}")]
        public ActionResult GET_GROWTH_RATE_DETAILS_BY_DESCP(string growthDescp)
        {
            var result = GROWTH_RATE_REPOSITORY.GET_GROWTH_RATE_DETAILS_BY_DESCP(growthDescp);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }     
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GrowthRate/Get_Growth_Rates_Details_byProdId/{productID}/{growthRate}")]
        public ActionResult GET_GROWTH_RATE_DETAILS_BY_PRODUCT(int productID, int growthRate)
        {
            var result = GROWTH_RATE_REPOSITORY.GET_GROWTH_RATE_DETAILS_BY_PRODUCT(productID, growthRate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/GrowthRate/Post_Growth_Rates")]
        public ActionResult POST_GROWTH_RATES(GROWTH_RATE growth_rate)
        {
            var result = GROWTH_RATE_REPOSITORY.POST_GROWTH_RATES(growth_rate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/GrowthRate/Put_Growth_Rates")]
        public ActionResult UPDATE_GROWTH_RATES(GROWTH_RATE growth_rate)
        {
            var result = GROWTH_RATE_REPOSITORY.UPDATE_GROWTH_RATES(growth_rate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
