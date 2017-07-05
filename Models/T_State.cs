using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_State
    {
        public int ID { get; set; }
        public string StateName { get; set; }
        public Nullable<System.DateTime> Createtime { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
