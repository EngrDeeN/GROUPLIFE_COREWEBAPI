using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IProvinceRepository
    {
        public object GetProvinceList();
        public object GetProvinceDetails(int provinceId);
        public object GetProvinceDetailsByCont(int countryId);
        public object PostProvince(Province province);
        public object PutProvince(Province province);
        public object DeleteProvince(int provinceId);
    }
}
