using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Auth_ModulePermission
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }
        public Nullable<int> CreateId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual T_Auth_Module T_Auth_Module { get; set; }
        public virtual T_Auth_Permission T_Auth_Permission { get; set; }
    }
}
