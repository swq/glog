
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class TC_GeographyArea
    {
        public int ID { get; set; }
        public string Area { get; set; }
        public bool IsDeleted { get; set; }
        public bool Enable { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserCode { get; set; }
        public DateTime CreateDate { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public string ModifiedUserCode { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Note { get; set; }
        public int SortOrder { get; set; }
        public string Area_EN { get; set; }
    }
}