using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class Country
    {
        public int FSSC_COUNTRY_ID { get; set; }
        public string FSSC_COUNTRY_NAME { get; set; }
        public string FSSC_COUNTRY_SHORT_NAME { get; set; }
        public string FSSC_COUNTRY_NATIONALITY { get; set; }
        public string FSSC_COUNTRY_DIAL_CODE { get; set; }
        public string FSSC_FATF_LISTED_YN { get; set; }
        public string FSSC_GREY_LISTED_YN { get; set; }
        public string FSSC_BLACK_LISTED_YN { get; set; }
        public string FSSC_STATUS { get; set; }
        public int FSSC_CRUSER { get; set; }
        public DateTime FSSC_CRDATE { get; set; }
    }
}
