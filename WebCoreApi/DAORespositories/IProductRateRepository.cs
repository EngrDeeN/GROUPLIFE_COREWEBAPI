using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IProductRateRepository
    {
        public object GetProductRateList();
        public object GetProductRateDetails(int ProductRateId);
        public object GetProductRateDetailsByName(string ProductRateName);
        public object PostProductRate(ProductRate productRate);
        public object PutProductRate(ProductRate productRate);
        public object DeleteProductRate(int productRateId);
    }
}
