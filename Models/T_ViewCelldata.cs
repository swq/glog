using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gLog_FrontEnd.Models
{
    public partial class T_ViewCelldata
    {
        public int ID { get; set; }
        public string ViewGUID { get; set; }
        public string CellValue { get; set; }
        public int Cell_X { get; set; }
        public int Cell_Y { get; set; }
    }
}