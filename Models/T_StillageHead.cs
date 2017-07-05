
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_StillageHead
    {
        public int ID { get; set; }
        public string DeliveryNote { get; set; }
        public string Goods_PreparedBy { get; set; }
        public string Goods_PreparedFor { get; set; }
        public string Shipping { get; set; }
        public Nullable<DateTime> Planned_Packing_Date { get; set; }
        public Nullable<DateTime> Actual_Packing_Date { get; set; }
        public string Stillage_Status { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Stillage_Type { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<int> Height { get; set; }
        public string Comments { get; set; }
        public Nullable<DateTime> Createdate { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Pro_ID { get; set; }
    }
}