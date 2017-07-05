using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Auth_Permission
    {
        public T_Auth_Permission()
        {
            this.T_Auth_ModulePermission = new List<T_Auth_ModulePermission>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public Nullable<int> CreateId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual ICollection<T_Auth_ModulePermission> T_Auth_ModulePermission { get; set; }
    }
}
