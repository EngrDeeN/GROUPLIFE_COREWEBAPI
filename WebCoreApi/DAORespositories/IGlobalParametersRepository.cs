using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IGlobalParametersRepository
    {
        public object GetGlobalParamByCategory(string categoryCode);
        public object GetGlobalParamByCatType(string categoryCode, string typeCode);
        public object GetLocationList(int FSCH_SYS_CODE_HID);
        public object GetCurrencyList( );
        //public object GetGlobalParamByCategory(int categoryId);

        //public object GetGlobalParameterDetails(int parameterId);
        //public object PostGlobalParameter(GlobalParameters globalParameters);
        //public object PutGlobalParameter(GlobalParameters globalParameters);
        //public object DeleteGlobalParameter(int parameterId);
    }
}
