using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface ICustomerRepository
    {
        public object GetCustomerList();
        public object GetCustomerDetails(int customerCode);
        public object PostCustomer(Customer customer);
        public object PutCustomer(Customer customer);
        public object DeleteCustomer(int customerCode);
        public object SearchCustomer(string customerCNIC);
        public object GetCustAddressDetails(int customerCode, string addressType);
        public object PostCustomerAddress(CustomerAddress customerAddress);
        public object PutCustomerAddress(CustomerAddress customerAddress);
        public object GetCustBankDetails(int customerCode);
        public object PostCustBankDetails(CustomerBankDtls customerBankDtls);
        public object PutCustBankDetails(CustomerBankDtls customerBankDtls);
        public object GetCustFamilyHist(int customerCode);
        public object PostCustFamilyHist(CustomerFamlyHist customerFamilyHist);
        public object PutCustFamilyHist(CustomerFamlyHist customerFamilyHist);
        public object GetCustFamilyDoct(int customerCode);
        public object PostCustFamilyDoct(CustomerFamlyDoctr customerFamilyDoct);
        public object PutCustFamilyDoct(CustomerFamlyDoctr customerFamilyDoct);
        public object GetCustDocumUpload(int customerCode);
        public object PostCustDocumUpload(CustomerDocUpload customerDocUpload);
        public object PutCustDocumUpload(CustomerDocUpload customerDocUpload);

        public object GetSocialMediaProfile(int CustomerCode);
        public object PostSocialMediaProfile(CustomerSociMedProf CustomerSociMedProf);
        public object PutSocialMediaProfile(CustomerSociMedProf CustomerSociMedProf);

    }
}
