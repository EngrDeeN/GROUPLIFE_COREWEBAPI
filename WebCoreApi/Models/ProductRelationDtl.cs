using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class ProductRelationDtl
    {
        public int FSPR_PRODRELTN_ID { get; set; }
        public int FSPM_PRODUCT_ID { get; set; }
        public int FSPR_RELTN_FSCD_DID { get; set; }
        public string FSPR_PRODRELTN_DESCR { get; set; }
        public int FSPR_RELTNCOUNT_FRM { get; set; }
        public int FSPR_RELTNCOUNT_TO { get; set; }
        public string FSPR_RELTYP_FLAG { get; set; }
        public int FSPR_PREMIUMFACTOR { get; set; }
        public int FSPR_CALC_INDX1 { get; set; }
        public int FSPR_CALC_INDX2 { get; set; }
        public int FSPR_MODAL_FACTR1 { get; set; }
        public int FSPR_MODAL_FACTR2 { get; set; }
        public string FSPR_DFF_DESCR1 { get; set; }
        public string FSPR_STATUS { get; set; }
        public int FSPR_CRUSER { get; set; }
        public DateTime FSPR_CRDATE { get; set; }

    }
}
