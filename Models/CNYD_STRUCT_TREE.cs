
using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class CNYD_STRUCT_TREE
    {
        public int ID_ { get; set; }
        public string CASCADE_ID_ { get; set; }
        public string STRUCT_KEY_ { get; set; }
        public string STRUCT_NAME_ { get; set; }
        public int STRUCT_TYPEID { get; set; }
        public Nullable<int> PARENT_ID_ { get; set; }
        public bool IS_LEAF_ { get; set; }
        public bool IS_AUTO_EXPAND_ { get; set; }
        public string ICON_NAME_ { get; set; }
        public Nullable<int> SORT_NO_ { get; set; }
        public string PJ_ID_ { get; set; }
        public bool IsDeleted { get; set; }
        public bool Enable { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserCode { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public string ModifiedUserCode { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string Note { get; set; }
        public string STRUCT_NAME_EN { get; set; }
        public bool MAT_STATUS { get; set; }
        //MAT_STATUS
    }
}
