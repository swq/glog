using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Part
    {
        public T_Part()
        {
        }

        public int ID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public int FParentID { get; set; }
        public int FLevel { get; set; }
        public string FName { get; set; }
        public string FName_EN { get; set; }
        public Nullable<System.DateTime> Createtime { get; set; }
        public bool FIsDelete { get; set; }
    }
}
