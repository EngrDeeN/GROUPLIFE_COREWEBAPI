using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IQuotationRepository
    {
        public object GetQuotationList();
        public object GetAgentList();
        public object GetQuotationDetails(string QuotationId);
        public object PostQuotations(QuotationHDR quotation);
        public object PutQuotations(QuotationHDR quotation);
        public object DeleteQuotations  (int QuotationId);
        public object Get_Quotat_Plan_Dtls(string QuotationCode);


        public object GetQuotaRiderDetails(int QUOTATION_ID, int FGQG_COMPGRP_ID);
        public object PostQuotaRider(Quotation_Rider Quoatation_Rider);
        public object PutQuotaRider(Quotation_Rider Quoatation_Rider);

        public object GetQuotaEventList(int ListCode);
        public object GetQuotaEventDetails(int QUOTATION_ID, int FGQG_COMPGRP_ID);
        public object PostQuotaEvent(Quotation_Event Quotation_Event);
        public object PutQuotaEvent(Quotation_Event Quotation_Event);
      



    }
}
