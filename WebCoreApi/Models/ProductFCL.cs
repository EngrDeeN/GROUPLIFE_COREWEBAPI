using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class ProductFCL
    {
        public int FSPF_PRODFCL_ID { get; set; }
        public int FSPM_PRODUCT_ID { get; set; }
        public string FSPF_PRODFCL_DESCR { get; set; }
        public int FSPF_GRPSIZE_MIN { get; set; }
        public int FSPF_GRPSIZE_MAX { get; set; }
        public int FSPF_GRPENTAGE_MIN { get; set; }
        public int FSPF_GRPENTAGE_MAX { get; set; }
        public string FSPF_FACTAMT_FLAG { get; set; }
        public int FSPF_FCL_FACTAMT { get; set; }
        public int FSPF_FCL_AMT_MAX { get; set; }
        public int FSPF_CALC_INDX1 { get; set; }
        public int FSPF_CALC_INDX2 { get; set; }
        public int FSPF_MODAL_FACTR1 { get; set; }
        public int FSPF_MODAL_FACTR2 { get; set; }
        public string FSPF_DFF_DESCR1 { get; set; }
        public string FSPF_STATUS { get; set; }
        public int FSPF_CRUSER { get; set; }
        public DateTime FSPF_CRDATE { get; set; }
    }
}
