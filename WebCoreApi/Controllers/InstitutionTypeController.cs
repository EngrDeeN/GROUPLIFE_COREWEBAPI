using Microsoft.AspNetCore.Mvc;
using WebCoreApi.Repositories;
using WebCoreApi.Models;
using WebCoreApi.DAORespositories;
using Microsoft.AspNetCore.Cors;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class InstitutionTypeController : ControllerBase
    {
        IInstitutionTypeRepository InstitutionTypeRepository;
        public InstitutionTypeController(IInstitutionTypeRepository _InstitutionTypeRepository)
        {
            InstitutionTypeRepository = _InstitutionTypeRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/InstitutionType/GetInstitutionTypeList")]
        public ActionResult GetInstitutionTypeList()
        {
            var result = InstitutionTypeRepository.GetInstitutionTypeList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Country/GetInstitutionTypeDetails/{institutionTypeId}")]
        public ActionResult GetInstitutionTypeDetails(int InstitutionTypeId)
        {
            var result = InstitutionTypeRepository.GetInstitutionTypeDetails(InstitutionTypeId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Country/PostInstitutionType")]
        public ActionResult PostInstitutionType(InstitutionType institutionType)
        {
            var result = InstitutionTypeRepository.PostInstitutionType(institutionType);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Type Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/InstitutionType/PutInstitutionType")]
        public ActionResult PutInstitutionType(InstitutionType institutionType)
        {
            var result = InstitutionTypeRepository.PutInstitutionType(institutionType);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Type Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/InstitutionType/DeleteInstitutionType/{institutionTypeId}")]
        public ActionResult DeleteInstitutionType(int institutionTypeId)
        {
            var result = InstitutionTypeRepository.DeleteInstitutionType(institutionTypeId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Institution Type Deleted Successfully."; }
            return Ok(result);
        }
    }
}
