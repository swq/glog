
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_StillageData
    {
        public int ID { get; set; }
        public Nullable<int> BTID { get; set; }
        public Nullable<int> Amount { get; set; }
        public string ProID { get; set; }
        public int StillageID { get; set; }
    }
}
