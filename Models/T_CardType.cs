using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_CardType
    {
        public int ID { get; set; }
        public string CardType { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
