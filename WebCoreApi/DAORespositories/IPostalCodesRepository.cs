using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IPostalCodesRepository
    {
        public object GetPostalCodeList();
        public object GetPostalCodeDetails(int postalCodeId);
        public object GetPostCodeDtlByCtyProvCont(int cityId, int provinceId, int countryId);
        public object PostPostalCode(PostalCodes postalCodes);
        public object PutPostalCode(PostalCodes postalCodes);
        public object DeletePostalCode(int postalCodeId);
    }
}
