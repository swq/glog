using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class TC_Company
    {
        public int ID { get; set; }
        public string Company_Code { get; set; }
        public string Company { get; set; }
        public string Company_EN { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public bool Enable { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserCode { get; set; }
        public int ModifiedUserID { get; set; }
        public string ModifiedUserCode { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int SortOrder { get; set; }
        public string Note { get; set; }
    }
}
