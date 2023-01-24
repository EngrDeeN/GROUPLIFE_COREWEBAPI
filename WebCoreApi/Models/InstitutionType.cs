using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class InstitutionType
    {
        public int FSIT_INSTITYP_ID { get; set; }
        public int FSIT_INSTITYP_DESCR { get; set; }
        public int FSIT_INSTITYP_SHORT_DESCR { get; set; }
        public int FSIT_STATUS { get; set; }
        public int FSIT_CRUSER { get; set; }
        public int FSIT_CRDATE { get; set; }
        public int FSIT_CHKUSER { get; set; }
        public int FSIT_CHKDATE { get; set; }
    }
}
