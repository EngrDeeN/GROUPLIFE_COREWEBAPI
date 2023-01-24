using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IQuotCompyGrpDetlRepository
    {
        public object GetQuotCompyGrpDetlDetails(int QuotCompyGrpDetlId);
        public object PostQuotCompyGrpDetl(QuotCompyGrpDetl quotCompyGrpDetl);
        public object PutQuotCompyGrpDetl(QuotCompyGrpDetl quotCompyGrpDetl);
       
    }
}
