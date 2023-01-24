using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface ICountryRepository
    {
        public object GetCountryList();
        public object GetCountryDetails(int countryId);
        public object PostCountry(Country country);
        public object PutCountry(Country country);
        public object DeleteCountry(int countryId);
    }
}
