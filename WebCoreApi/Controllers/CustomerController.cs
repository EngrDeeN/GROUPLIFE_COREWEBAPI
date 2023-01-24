using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutSocialMediaProfile")]
        public ActionResult PutSocialMediaProfile(CustomerSociMedProf CustomerSociMedProf)
        {
            var result = customerRepository.PutSocialMediaProfile(CustomerSociMedProf);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetSocialMediaProfile/{customerCode}")]
        public ActionResult GetSocialMediaProfile(int CustomerCode)
        {
            var result = customerRepository.GetSocialMediaProfile(CustomerCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostSocialMediaProfile")]
        public ActionResult PostSocialMediaProfile(CustomerSociMedProf CustomerSociMedProf)
        {
            var result = customerRepository.PostSocialMediaProfile(CustomerSociMedProf);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustomerList")]
        public ActionResult GetCustomerList()
        {
            var result = customerRepository.GetCustomerList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustomerDetails/{customerCode}")]
        public ActionResult GetCustomerDetails(int customerCode)
        {
            var result = customerRepository.GetCustomerDetails(customerCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/SearchCustomer/{customerCNIC}")]
        public ActionResult SearchCustomer(string customerCNIC)
        {
            var result = customerRepository.SearchCustomer(customerCNIC);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostCustomer")]
        public ActionResult PostCustomer(Customer customer)
        {
            var result = customerRepository.PostCustomer(customer);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutCustomer")]
        public ActionResult PutCustomer(Customer customer)
        {
            var result = customerRepository.PutCustomer(customer);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Updated Successfully."; }
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/Customer/DeleteCustomer/{customerCode}")]
        public ActionResult DeleteCustomer(int customerCode)
        {
            var result = customerRepository.DeleteCustomer(customerCode);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Customer Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustAddressDetails/{customerCode}/{addressType}")]
        public ActionResult GetCustAddressDetails(int customerCode, string addressType)
        {
            var result = customerRepository.GetCustAddressDetails(customerCode, addressType);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostCustomerAddress")]
        public ActionResult PostCustomerAddress(CustomerAddress customerAddress)
        {
            var result = customerRepository.PostCustomerAddress(customerAddress);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Address Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutCustomerAddress")]
        public ActionResult PutCustomerAddress(CustomerAddress customerAddress)
        {
            var result = customerRepository.PutCustomerAddress(customerAddress);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Address Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustBankDetails/{customerCode}")]
        public ActionResult GetCustBankDetails(int customerCode)
        {
            var result = customerRepository.GetCustBankDetails(customerCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostCustBankDetails")]
        public ActionResult PostCustBankDetails(CustomerBankDtls customerBankDtls)
        {
            var result = customerRepository.PostCustBankDetails(customerBankDtls);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Bank Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutCustBankDetails")]
        public ActionResult PutCustBankDetails(CustomerBankDtls customerBankDtls)
        {
            var result = customerRepository.PutCustBankDetails(customerBankDtls);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Bank Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustFamilyHist/{customerCode}")]
        public ActionResult GetCustFamilyHist(int customerCode)
        {
            var result = customerRepository.GetCustFamilyHist(customerCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostCustFamilyHist")]
        public ActionResult PostCustFamilyHist(CustomerFamlyHist customerFamilyHist)
        {
            var result = customerRepository.PostCustFamilyHist(customerFamilyHist);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Family History Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutCustFamilyHist")]
        public ActionResult PutCustFamilyHist(CustomerFamlyHist customerFamilyHist)
        {
            var result = customerRepository.PutCustFamilyHist(customerFamilyHist);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Family History Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustFamilyDoct/{customerCode}")]
        public ActionResult GetCustFamilyDoct(int customerCode)
        {
            var result = customerRepository.GetCustFamilyDoct(customerCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostCustFamilyDoct")]
        public ActionResult PostCustFamilyDoct(CustomerFamlyDoctr customerFamilyDoct)
        {
            var result = customerRepository.PostCustFamilyDoct(customerFamilyDoct);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Family Doctor Record Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutCustFamilyDoct")]
        public ActionResult PutCustFamilyDoct(CustomerFamlyDoctr customerFamilyDoct)
        {
            var result = customerRepository.PutCustFamilyDoct(customerFamilyDoct);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Family Doctor Record Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Customer/GetCustDocumUpload/{customerCode}")]
        public ActionResult GetCustDocumUpload(int customerCode)
        {
            var result = customerRepository.GetCustDocumUpload (customerCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PostCustDocumUpload")]
        public ActionResult PostCustDocumUpload(CustomerDocUpload customerDocUpload)
        {
            var result = customerRepository.PostCustDocumUpload (customerDocUpload);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Document Record Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Customer/PutCustDocumUpload")]
        public ActionResult PutCustDocumUpload(CustomerDocUpload customerDocUpload)
        {
            var result = customerRepository.PutCustDocumUpload(customerDocUpload);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Customer Document Record Updated Successfully."; }
            return Ok(result);
        }
    }
}
