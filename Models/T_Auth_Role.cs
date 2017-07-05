using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Auth_Role
    {
        public T_Auth_Role()
        {
            this.T_Auth_RoleModulePermission = new List<T_Auth_RoleModulePermission>();
            this.T_Auth_UserRole = new List<T_Auth_UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderSort { get; set; }
        public bool Enabled { get; set; }
        public Nullable<int> CreateId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual ICollection<T_Auth_RoleModulePermission> T_Auth_RoleModulePermission { get; set; }
        public virtual ICollection<T_Auth_UserRole> T_Auth_UserRole { get; set; }
    }
}
