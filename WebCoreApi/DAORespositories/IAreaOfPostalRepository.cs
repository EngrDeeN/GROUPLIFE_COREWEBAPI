using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IAreaOfPostalRepository
    {
        public object GetAreaOfPostalList();
        public object GetAreaOfPostalDetails(int areaOfPostalId);
        public object GetAreaOfPostalDtlByPostalCode(int postalCodeId );
        public object PostAreaOfPostal(AreaOfPostal areaOfPostal);
        public object PutAreaOfPostal(AreaOfPostal areaOfPostal);
        public object DeleteAreaOfPostal(int areaOfPostalId);
    }
}
