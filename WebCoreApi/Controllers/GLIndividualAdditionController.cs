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
    public class GLIndividualAdditionController : ControllerBase
    {

        IGLIndividualAdditionRepository IGLIndividualAdditionRepository;
        public GLIndividualAdditionController(IGLIndividualAdditionRepository _IGLIndividualAdditionRepository)
        {
            IGLIndividualAdditionRepository = _IGLIndividualAdditionRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GLIndivAddi/GetGLIndiAddiDetailsByPolicyNo/{ByPolicyNo}")]
        public ActionResult GetGLIndiAddiDetailsByPolicyNo(string ByPolicyNo)
        {
            var result = IGLIndividualAdditionRepository.GetGLIndiAddiDetailsByPolicyNo(ByPolicyNo);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/GLIndivAddi/GetGLIndiAddiDetails/{CustomerCNIC}/{ByPolicyNo}")]
        public ActionResult GetGLIndiAddiDetails(string CustomerCNIC, string ByPolicyNo)
        {
            var result = IGLIndividualAdditionRepository.GetGLIndiAddiDetails(CustomerCNIC, ByPolicyNo);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/GLIndivAddi/PostGLIndiAddi")]
        public ActionResult PostGLIndiAddi(GLIndividualAddition GLIndividualAddition)
        {
            var result = IGLIndividualAdditionRepository.PostGLIndiAddi(GLIndividualAddition);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "GL Individual Addition Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/GLIndivAddi/PutGLIndiAddi")]
        public ActionResult PutGLIndiAddi(GLIndividualAddition GLIndividualAddition)
        {
            var result = IGLIndividualAdditionRepository.PutGLIndiAddi(GLIndividualAddition);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "GL Individual Addition Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/GLIndivAddi/PurgeGLIndiAddi")]
        public ActionResult PurgeGLIndiAddi(GLIndividualAddition GLIndividualAddition)
        {
            var result = IGLIndividualAdditionRepository.PurgeGLIndiAddi(GLIndividualAddition);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "GL Individual Addition Delete Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/GLIndivAddi/FluctuatAddMmbrDtl")]
        public ActionResult FluctuatAddMmbrDtl(FluctuatAddMmbrDtl FluctuatAddMmbrDtl)
        {
            var result = IGLIndividualAdditionRepository.FluctuatAddMmbrDtl(FluctuatAddMmbrDtl);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "New Memeber has been Successfully added."; }
            return Ok(result);
        }

        
    }
}
