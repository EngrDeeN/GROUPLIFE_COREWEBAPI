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
    public class AgentRegisterController : ControllerBase
    {

        IAgentRegisterRepository IAgentRegisterRepository;
        public AgentRegisterController(IAgentRegisterRepository _IAgentRegisterRepository)
        {
            IAgentRegisterRepository = _IAgentRegisterRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Agent/GetAgentList")]
        public ActionResult GetAgentList( )
        {
            var result = IAgentRegisterRepository.GetAgentList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Agent/GetAgentDetails/{AgentRegisterId}")]
        public ActionResult GetAgentDetails(int AgentRegisterId)
        {
            var result = IAgentRegisterRepository.GetAgentDetails(AgentRegisterId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Agent/PostAgent")]
        public ActionResult PostAgent(AgentRegister AgentRegister)
        {
            var result = IAgentRegisterRepository.PostAgent(AgentRegister);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Agent Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Agent/PutAgent")]
        public ActionResult PutAgent(AgentRegister AgentRegister)
        {
            var result = IAgentRegisterRepository.PutAgent(AgentRegister);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Agent Updated Successfully."; }
            return Ok(result);
        }
    }
}
