using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface IGrowthRateRepository
    {
        public object GET_GROWTH_RATE_LIST();
        public object GET_GROWTH_RATE_DETAILS(int growthID);
        public object GET_GROWTH_RATE_DETAILS_BY_DESCP(string growthDescp);
        public object GET_GROWTH_RATE_DETAILS_BY_PRODUCT(int productID, int growthRate);
        public object POST_GROWTH_RATES(GROWTH_RATE growth_rate);
        public object UPDATE_GROWTH_RATES(GROWTH_RATE growth_rate);

    }
}
