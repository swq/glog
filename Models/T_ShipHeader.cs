
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_ShipHeader
    {
        public int ID { get; set; }
        public string ShipRef { get; set; }
        public string ShipFrom { get; set; }
        public string ShipTo { get; set; }
        public string ShipType { get; set; }
        public string Forwarder { get; set; }
        public string Size { get; set; }
        public string SenderAddr { get; set; }
        public string PickAddr { get; set; }
        public string ContactSender { get; set; }
        public string ReceiveAddr { get; set; }
        public string DeliveryAddr { get; set; }
        public string ContactReceiver { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public string etc { get; set; }
        public string ShipStatus { get; set; }
    }
}
