using System;

namespace WebCoreApi.Models
{
    public class City
    {
        public int FSCT_CITY_ID { get; set; }
        public int FSSP_PROVINCE_ID { get; set; }
        public int FSSC_COUNTRY_ID { get; set; }
        public string FSCT_CITY_NAME { get; set; }
        public string FSCT_CITY_SHORT_NAME { get; set; }
        public string FSCT_CITY_DIAL_CODE { get; set; }
        public string FSCT_STATUS { get; set; }
        public int FSCT_CRUSER { get; set; }
        public DateTime FSCT_CRDATE { get; set; }
    }
}
