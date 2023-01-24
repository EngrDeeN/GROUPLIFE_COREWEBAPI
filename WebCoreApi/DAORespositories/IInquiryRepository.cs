using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IInquiryRepository
    {
        public object GetInquiryDetails(string QUOTATHDR_CODE);
        public object Get_Inquiry_Member_Details(string QUOTATHDR_CODE);
        public object Get_Inquiry_Pending_Member_Details(string QUOTATHDR_CODE);
        public object Get_Inquiry_Rider_Details(int quotationID);

    }
}
