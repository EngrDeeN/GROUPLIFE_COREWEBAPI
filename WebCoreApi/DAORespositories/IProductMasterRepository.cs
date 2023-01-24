using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IProductMasterRepository
    {
        public object GetProductList();
        public object GET_POLICY_TO_QUOTATION(string QU_PO_Code);
        public object GetProductDetails(int ProductId);
        public object GetProductDetails(string ProductName);
        public object PostProduct(ProductMaster product);
        public object PutProduct(ProductMaster product);
        public object DeleteProduct(int ProductId);
        public object GetProductFCLDetails(int ProductId);
        public object PostProductFCL(ProductFCL productFcl);
        public object PutProductFCL(ProductFCL productFcl);
        public object GetProdRelationDtls(int ProductId);
        public object PostProdRelationDtls(ProductRelationDtl productRelDtl);
        public object PutProdRelationDtls(ProductRelationDtl productRelDtl);

        public object GetRiderDetails(int FSPM_PRODUCT_TYPE);
    }
}

