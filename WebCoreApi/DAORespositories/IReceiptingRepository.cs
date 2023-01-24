using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IReceiptingRepository
    {
        public object GetReceiptingList();
        public object GetReceiptingDetails(int ReceiptId);
        public object GetReceiptingDetailsByQuotation(string QuotationCode);
        public object PostReceipting(Receipting Receipting);
        public object PutReceipting(Receipting Receipting);
        public object DeleteReceipting(int ReceiptId);

        public object Get_Bank_List();
        public object GET_VOUCHER_LIST();        
        public object Get_Valid_Quotation_List(string Document_Id, string VoucherId);
        

            


    }
}
