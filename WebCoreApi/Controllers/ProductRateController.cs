using WebCoreApi.DAORespositories;
using WebCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ProductRateController : ControllerBase
    {
        IProductRateRepository iProductRateRepository;
        public ProductRateController(IProductRateRepository _iProductRateRepository)
        {
            iProductRateRepository = _iProductRateRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/ProductRate/GetProductRateList")]
        public ActionResult GetProductRateList()
        {
            var result = iProductRateRepository.GetProductRateList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/ProductRate/GetProductRateDetailsById/{ProductRateId}")]
        public ActionResult GetProductRateDetails(int ProductRateId)
        {
            var result = iProductRateRepository.GetProductRateDetails(ProductRateId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/ProductRate/GetProductRateDetailsByName/{ProductRateName}")]
        public ActionResult GetProductRateDetailsByName(string ProductRateName)
        {
            var result = iProductRateRepository.GetProductRateDetailsByName(ProductRateName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/ProductRate/PostProductRate")]
        public ActionResult PostProductRate(ProductRate productRate)
        {
            var result = iProductRateRepository.PostProductRate(productRate);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Product Rates Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/ProductRate/PutProductRate")]
        public ActionResult PutProductRate(ProductRate productRate)
        {
            var result = iProductRateRepository.PutProductRate(productRate);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Product Rates Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/ProductRate/{ProductRateId}")]
        public ActionResult DeleteProductRate(int ProductRateId)
        {
            var result = iProductRateRepository.DeleteProductRate(ProductRateId);
            if (result == null)
            {
                return NotFound();
            }
            else { result = "Product Rates Deleted Successfully."; }
            return Ok(result);
        }
    }
}
