using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Progress
    {
        public int ID { get; set; }
        public string ProgressName { get; set; }
        public Nullable<System.DateTime> Createtime { get; set; }
        public bool IsDelete { get; set; }
    }
}
