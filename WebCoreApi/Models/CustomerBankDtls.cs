﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi.Models
{
    public class CustomerBankDtls
    {
        public int FSCU_CUSTOMER_CODE { get; set; }
        public string FSBK_BANK_NAME { get; set; }
        public string FSCB_BRANCH_NAME { get; set; }
        public string FSCB_ACCOUNT_TITLE { get; set; }
        public string FSCB_ACCOUNT_NO { get; set; }
        public string FSCB_ACCOUNT_TYPE { get; set; }
        public string FSCB_STATUS { get; set; }
        public int FSCB_CRUSER { get; set; }
        public int FSCB_SERIAL_NO { get; set; }
        public int FSCB_ACCOUNT_CATGRY { get; set; }
        public DateTime FSCB_CRDATE { get; set; }
    }
}
