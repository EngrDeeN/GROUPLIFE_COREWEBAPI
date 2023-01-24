using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IUnderWrittingRepository
    {

        public object GetUnderWrittingList();
        public object GetUnderWrittingDetails(int UnderWrittingId);
        public object GetUnderWrittingDetailsByQuotation(string IDENTIF_NO);
        public object GetPendingPersons(string Policy_no); //Added by Shizra Aijaz
        public object GetUnderWrittingDetailsByRider(string FGQH_QUOTATHDR_CODE, string IDENTIF_NO);
        public object PostUnderWritting(UnderWritting UnderWritting);
        public object PutUnderWritting(UnderWritting UnderWritting);
        public object DeleteUnderWritting(int UnderWrittingId);

        public object PostUnderWrittingDocument(UnderWritt_Doc UnderWritt_Doc);
        public object PutUnderWrittingDocument(UnderWritt_Doc UnderWritt_Doc);
        public object DeleteUnderWrittingDocument(int UnderWritt_DocId);

        public object Get_NewOrDelete_Customer(string PolicyNo);

    }
}
