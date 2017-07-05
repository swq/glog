using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gLog_FrontEnd.Models
{
    public partial class T_ViewInfo
    {
        
        public int ID { get; set; }
        public string Pro_id { get; set; }
        public string View_Name { get; set; }
        public string Strut_Type { get; set; }
        public string Note { get; set; }
        public bool Enable { get; set; }
        public bool IsDelete { get; set; }
        public string Path { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ViewGUID { get; set; }

    }
}