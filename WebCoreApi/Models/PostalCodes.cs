using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class PostalCodes
    {
        public int FSPS_POSTAL_ID { get; set; }
        public string FSPS_POSTAL_CODE { get; set; }
        public string FSPS_POSTAL_DESCRIPTION { get; set; }
        public int FSSC_COUNTRY_ID { get; set; }
        public int FSSP_PROVINCE_ID { get; set; }
        public int FSCT_CITY_ID { get; set; }
        public string FSPS_STATUS { get; set; }
        public int FSPS_CRUSER { get; set; }
        public DateTime FSPS_CRDATE { get; set; }
    }
}
