
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_TA_Info
    {
        public int ID { get; set; }
        public string TA_Code { get; set; }
        public string Note_EN { get; set; }
        public string Note { get; set; }
        public string Floors { get; set; }
        public string TA_TYPE { get; set; }
        public string PJ_ID { get; set; }
        public bool IsDeleted { get; set; }
        public bool Enable { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserCode { get; set; }
        public string CreateDate { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public string ModifiedUserCode { get; set; }
        public string ModifiedDate { get; set; }
        public int SortOrder { get; set; }
    }
}
