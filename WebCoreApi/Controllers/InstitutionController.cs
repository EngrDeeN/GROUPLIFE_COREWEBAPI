using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class InstitutionController : ControllerBase
    {
        IInstitutionRepository InstitutionRepository;
        public InstitutionController(IInstitutionRepository _institutionRepository)
        {
            InstitutionRepository = _institutionRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitutionList")]
        public ActionResult GetCustomerList()
        {
            var result = InstitutionRepository.GetInstitutionList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitutionDetails/{InstitutionCode}")]

        public ActionResult GetCustomerDetails(int InstitutionCode)
        {
            var result = InstitutionRepository.GetInstitutionDetails(InstitutionCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/SearchInstitution/{InstRegNo}/{FSSI_DESCRIPTION}")]
        public ActionResult SearchInstitution(string InstRegNo, string FSSI_DESCRIPTION)
        {

            var result = InstitutionRepository.SearchInstitution(InstRegNo, FSSI_DESCRIPTION);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PostInstitution")]
        public ActionResult PostInstitution(Institution institution)
        {
            var result = InstitutionRepository.PostInstitution(institution);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PutInstitution")]
        public ActionResult PutInstitution(Institution institution)
        {
            var result = InstitutionRepository.PutInstitution(institution);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/Institution/DeleteInstitution/{InstitutionCode}")]
        public ActionResult DeleteInstitution(int InstitutionCode)
        {
            var result = InstitutionRepository.DeleteInstitution(InstitutionCode);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitutionTypeList")]
        public ActionResult GetInstitutionTypeList()
        {
            var result = InstitutionRepository.GetInstitutionTypeList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitAddressDetails/{InstitutionCode}/{addressType}")]
        public ActionResult GetInstitAddressDetails(int InstitutionCode, string addressType)
        {
            var result = InstitutionRepository.GetInstitAddressDetails(InstitutionCode, addressType);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PostInstitAddress")]
        public ActionResult PostInstitAddress(InstituteAddress institutionAddr)
        {
            var result = InstitutionRepository.PostInstitAddress(institutionAddr);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PutInstitAddress")]
        public ActionResult PutInstitAddress(InstituteAddress institutionAddr)
        {
            var result = InstitutionRepository.PutInstitAddress(institutionAddr);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitContactDetails/{InstitutionCode}")]
        public ActionResult GetInstitContactDetails(int InstitutionCode)
        {
            var result = InstitutionRepository.GetInstitContactDetails(InstitutionCode);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Contact Details fetched Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PostInstitContacts")]
        public ActionResult PostInstitContacts(InstitutionContacts institutionContacts)
        {
            var result = InstitutionRepository.PostInstitContacts(institutionContacts);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Contact Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PutInstitContacts")]
        public ActionResult PutInstitContacts(InstitutionContacts institutionContacts)
        {
            var result = InstitutionRepository.PutInstitContacts(institutionContacts);
            if (result == null)
            {
                return NotFound();
            }
           // else { result = "Institution Contact Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitMobileDetails/{InstitutionCode}")]
        public ActionResult GetInstitMobileDetails(int InstitutionCode)
        {
            var result = InstitutionRepository.GetInstitMobileDetails(InstitutionCode);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Mob. Details Fetched Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PostInstitMobileDtls")]
        public ActionResult PostInstitMobileDtls(InstitutionMobContacts institutionMobContacts)
        {
            var result = InstitutionRepository.PostInstitMobileDtls(institutionMobContacts);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PutInstitMobileDtls")]
        public ActionResult PutInstitMobileDtls(InstitutionMobContacts institutionMobContacts)
        {
            var result = InstitutionRepository.PutInstitMobileDtls(institutionMobContacts);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Save Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Institution/GetInstitOwnerInfo/{InstitutionCode}")]
        public ActionResult GetInstitOwnerInfo(int InstitutionCode)
        {
            var result = InstitutionRepository.GetInstitOwnerInfo(InstitutionCode);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Owner Info. Fetched Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PostInstitOwnerInfo")]
        public ActionResult PostInstitOwnerInfo(InstitutionOwnerInfo institutionOwnerInfo)
        {
            var result = InstitutionRepository.PostInstitOwnerInfo(institutionOwnerInfo);
            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Institution Owner Info. Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Institution/PutInstitOwnerInfo")]
        public ActionResult PutInstitOwnerInfo(InstitutionOwnerInfo institutionOwnerInfo)
        {
            var result = InstitutionRepository.PutInstitOwnerInfo(institutionOwnerInfo);
            if (result == null)
            {
                return NotFound();
            }
           // else { result = "Institution Owner Info. Updated Successfully."; }
            return Ok(result);
        }
    }
}
