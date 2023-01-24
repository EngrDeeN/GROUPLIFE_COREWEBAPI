using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IGLIndividualAdditionRepository
    {
        public object GetGLIndiAddiDetailsByPolicyNo(string ByPolicyNo);
        public object GetGLIndiAddiDetails(string CustomerCNIC, string ByPolicyNo);
        public object PostGLIndiAddi(GLIndividualAddition GLIndividualAddition);
        public object PutGLIndiAddi(GLIndividualAddition GLIndividualAddition);
        public object PurgeGLIndiAddi(GLIndividualAddition GLIndividualAddition);
        public object FluctuatAddMmbrDtl(FluctuatAddMmbrDtl FluctuatAddMmbrDtl);

        


    }
}
