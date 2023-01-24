using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class QuotationProcessUnitRate
    {
        public int FGQH_QUOTATHDR_ID { get; set; }
        public int FPQR_EVENT_ID { get; set; }
        public int FSPR_PRODRELTN_ID { get; set; }
        public float FPQR_SYSTMUNIT_RATE { get; set; }
        public float FPQR_USERUNIT_RATE { get; set; }
        public float FPQR_USERNET_RATE { get; set; }
        public float fpqr_rirate { get; set; }
        public int FPQR_CRUSER { get; set; }
        public string FPQR_BASPLN_FLAG { get; set; }
        public DateTime FPQR_CRDATE { get; set; }

        public string FPQR_SYSUSR_RATE_FLAG { get; set; }


    }
}
