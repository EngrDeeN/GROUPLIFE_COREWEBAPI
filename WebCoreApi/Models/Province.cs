using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class Province
    {
        public int FSSP_PROVINCE_ID { get; set; }
        public int FSSC_COUNTRY_ID { get; set; }
        public string FSSP_PROVINCE_NAME { get; set; }
        public string FSSP_PROVINCE_SHORT_NAME { get; set; }
        public string FSSP_STATUS { get; set; }
        public int FSSP_CRUSER { get; set; }
        public DateTime FSSP_CRDATE { get; set; }

    }
}
