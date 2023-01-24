using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class GROWTH_RATE
    {
        public int FSPGR_PRODGRTHRAT_ID { get; set; }
        public int FSPM_PRODUCT_ID { get; set; }
        public string FSPGR_GROWTH_DESCRIP { get; set; }
        public string FSPGR_GROWTH_SHORT_DESC { get; set; }
        public int FSPGR_GROWTH_RATE { get; set; }
        public DateTime FSPGR_EFFCTDATE_FROM { get; set; }
        public DateTime FSPGR_EFFCTDATE_TO { get; set; }
        public int FSPGR_REAL_RATE { get; set; }
        public string FSPGR_INFLTCUM_CONTRYN { get; set; }
        public string FSPGR_STATUS { get; set; }
        public DateTime FSPGR_FLXFLD_DATE { get; set; }
        public string FSPGR_FLXFLD_VCHAR { get; set; }
        public int FSPGR_FLXFLD_NUMBER { get; set; }
        public int FSPGR_CRUSER { get; set; }
        public DateTime FSPGR_CRDATE { get; set; }
        public int FSPGR_CHKUSER { get; set; }
        public DateTime FSPGR_CHKDATE { get; set; }
        public int FSPGR_AUTHUSER { get; set; }
        public DateTime FSPGR_AUTHDATE { get; set; }
        public int FSPGR_CNCLUSER { get; set; }
        public DateTime FSPGR_CNCLDATE { get; set; }
        public string FSPGR_AUDIT_COMMENTS { get; set; }
        public string FSPGR_USER_IPADDR { get; set; }
    }
}
