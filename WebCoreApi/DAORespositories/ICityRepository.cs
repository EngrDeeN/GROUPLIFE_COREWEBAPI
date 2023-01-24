using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface ICityRepository
    {
        public object GetCityList();
        public object GetCityDetails(int cityId);
        public object GetCityDetailsByProvCont(int provinceId, int countryId);
        public object PostCity(City city);
        public object PutCity(City city);
        public object DeleteCity(int cityId);
    }
}
