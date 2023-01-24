using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IAgentRegisterRepository
    {
        public object GetAgentList();
        public object GetAgentDetails(int AgentRegisterId);
        public object PostAgent(AgentRegister AgentRegister);
        public object PutAgent(AgentRegister AgentRegister);
       /// public object DeleteAgent(int AgentRegisterId);
    }
}
