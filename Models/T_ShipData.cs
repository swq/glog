
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_ShipData
    {
        public int ID { get; set; }
        public Nullable<int> StillageID { get; set; }
        public DateTime Createdate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ShipID { get; set; }
    }
}
