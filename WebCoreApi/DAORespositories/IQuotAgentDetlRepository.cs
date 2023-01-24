using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IQuotAgentDetlRepository
    {
        public object GetQuotAgentDetDetails(int QuotAgentDetId);
        public object PostQuotAgentDet(QuotAgentDetl quotAgentDetl);
        public object PutQuotAgentDet(QuotAgentDetl quotAgentDetl);
    }
}
