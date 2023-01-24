using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IQuotaProcessRepository
    {
        public object GetQuotaProcessList();
        public object GetQuotaProcessDetails(string QuotationCode);
        public object PostQuotaProcessPolicy(PolicyGeneration policyGeneration);
        public object PostQuotaProcessPolicyGenrtWithQuotationId(PolicyGeneration PolicyGeneration);
        public object PostQuotaProcess(QuotaProcess QuotaProcess);
        public object PutQuotaProcess(QuotaProcess QuotaProcess);
        public object DeleteQuotaProcess(int QuotaProcessId);

        public object GetQuotaProcessFLCList();
        public object GetQuotatFCLDtls(string QuotationCode);
        public object PostQuotaFLCProcess(QuotationProcessFCL QuotaProcessFCL);
        public object PutQuotaFLCProcess(QuotationProcessFCL QuotaProcessFCL);
        public object DeleteQuotaFLCProcess(int QuotaProFCLId);

        public object GetQuotaProcessUnitRateList();
        public object GetQuotatUnitRateLimitDtls(string QuotationCode);
        public object PostQuotaProcessUR(QuotationProcessUnitRate QuotaProcessUnitRate);
        public object PutQuotaProcessUR(QuotationProcessUnitRate QuotaProcessUnitRate);
        public object DeleteQuotaProcessUR(int QuotaProcessUniteRateId);


        public object CreateDuplicationQuoation(PolicyIssuance request);

    }
}
