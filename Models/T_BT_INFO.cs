
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_BT_INFO
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> TA_ID { get; set; }
        public string Pro_ID { get; set; }
        public string BT_Code { get; set; }
        public string Description_EN { get; set; }
        public string Description_CN { get; set; }
        public string Units { get; set; }
        public Nullable<int> Qty { get; set; }
        public string Drawing { get; set; }
        public string Comments { get; set; }
        public string Dimension { get; set; }
        public string Specification { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
        public string ListNO { get; set; }
        public string TA_CODE { get; set; }
        public string TA_DES { get; set; }
        public string BTType { get; set; }
    }
}