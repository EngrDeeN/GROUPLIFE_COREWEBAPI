using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class AreaOfPostal
    {
        public int FSAP_AREA_ID { get; set; }
        public string FSAP_AREA_DESCRIPTION { get; set; }
        public string FSAP_AREA_SHORT_DESCR { get; set; }
        public int FSPS_POSTAL_ID { get; set; }
        public string FSAP_GEO_LONGITUDE { get; set; }
        public string FSAP_GEO_LATITUDE { get; set; }
        public string FSAP_STATUS { get; set; }
        public int FSAP_CRUSER { get; set; }
        public DateTime FSAP_CRDATE { get; set; }
    }
}
