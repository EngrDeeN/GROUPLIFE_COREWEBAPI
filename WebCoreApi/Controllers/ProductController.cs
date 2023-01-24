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
    public class ProductController : ControllerBase
    {
        IProductMasterRepository iProductRepository;
        public ProductController(IProductMasterRepository _iProductRepository)
        {
            iProductRepository = _iProductRepository;
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GetProductList")]
        public ActionResult GetProductList()
        {
            var result = iProductRepository.GetProductList();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GetRiderDetails/{PRODUCT_TYPE}")]
        public ActionResult GetRiderDetails(int PRODUCT_TYPE)
        {
            var result = iProductRepository.GetRiderDetails(PRODUCT_TYPE);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }        

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GetProductDetailsById/{ProductId}")]
        public ActionResult GetProductDetailsById(int ProductId)
        {
            var result = iProductRepository.GetProductDetails(ProductId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GetProductDetails/{ProductName}")]
        public ActionResult GetProductDetails(string ProductName)
        {
            var result = iProductRepository.GetProductDetails(ProductName);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Product/PostProduct")]
        public ActionResult PostProduct(ProductMaster Product)
        {
            var result = iProductRepository.PostProduct(Product);

            if (result == null)
            {
                return NotFound();
            }
            else { result = " - Product Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Product/PutProduct")]
        public ActionResult PutProduct(ProductMaster product)
        {
            var result = iProductRepository.PutProduct(product);

            if (result == null)
            {
                return NotFound();
            }
            else { result = " - Product Updated Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpDelete]
        [Route("api/Product/DeleteProduct/{ProductId}")]
        public ActionResult DeleteAreaOfPostal(int ProductId)
        {
            var result = iProductRepository.DeleteProduct(ProductId);

            if (result == null)
            {
                return NotFound();
            }
            else { result = " - Product Deleted Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GetProductFCLDetails/{ProductId}")]
        public ActionResult GetProductFCLDetails(int ProductId)
        {
            var result = iProductRepository.GetProductFCLDetails(ProductId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Product/PostProductFCL")]
        public ActionResult PostProductFCL(ProductFCL productFcl)
        {
            var result = iProductRepository.PostProductFCL(productFcl);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Product Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Product/PutProductFCL")]
        public ActionResult PutProductFCL(ProductFCL productFcl)
        {
            var result = iProductRepository.PutProductFCL(productFcl);

            if (result == null)
            {
                return NotFound();
            }
            else { result = " - Product FCL updated successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GetProdRelationDtls/{ProductId}")]
        public ActionResult GetProdRelationDtls(int ProductId)
        {
            var result = iProductRepository.GetProdRelationDtls(ProductId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Product/PostProdRelationDtls")]
        public ActionResult PostProdRelationDtls(ProductRelationDtl prodRelationDtl)
        {
            var result = iProductRepository.PostProdRelationDtls(prodRelationDtl);

            if (result == null)
            {
                return NotFound();
            }
            //else { result = "Product Saved Successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpPost]
        [Route("api/Product/PutProdRelationDtls")]
        public ActionResult PutProdRelationDtls(ProductRelationDtl prodRelationDtl)
        {
            var result = iProductRepository.PutProdRelationDtls(prodRelationDtl);

            if (result == null)
            {
                return NotFound();
            }
            else { result = " - Product relation details updated successfully."; }
            return Ok(result);
        }

        [EnableCors("GlobalWebPolicy")]
        [HttpGet]
        [Route("api/Product/GET_POLICY_TO_QUOTATION/{QU_PO_Code}")]
        public ActionResult GetCode(string QU_PO_Code)
        {
            var result = iProductRepository.GET_POLICY_TO_QUOTATION(QU_PO_Code);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}