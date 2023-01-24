using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class GlobalParameters
    {
        public int FSCD_SYS_CODE_DID { get; set; }
        public string FSCH_SYS_CODE { get; set; }
        public string FSCD_SYS_CODE_TYPE { get; set; }
        public string FSCD_SYS_CODE_VALUE { get; set; }
        public string FSCD_SYS_CODE_DESCR { get; set; }
        public string FSCD_SYS_CODE_SHORT { get; set; }
        public int FSCD_SYS_PARENT_DID { get; set; }
        public string FSCD_STATUS { get; set; }
        public int FSCD_SYS_RANGEFM { get; set; }
        public int FSCD_SYS_RANGETO { get; set; }
        public int FSCD_CRUSER { get; set; }
        public DateTime FSCD_CRDATE { get; set; }

    }
}
