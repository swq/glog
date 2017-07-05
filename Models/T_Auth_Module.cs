using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Auth_Module
    {
        public T_Auth_Module()
        {
            this.T_Auth_Module1 = new List<T_Auth_Module>();
            this.T_Auth_ModulePermission = new List<T_Auth_ModulePermission>();
            this.T_Auth_RoleModulePermission = new List<T_Auth_RoleModulePermission>();
        }

        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
        public int OrderSort { get; set; }
        public string Description { get; set; }
        public bool IsMenu { get; set; }
        public bool Enabled { get; set; }
        public Nullable<int> CreateId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual ICollection<T_Auth_Module> T_Auth_Module1 { get; set; }
        public virtual T_Auth_Module T_Auth_Module2 { get; set; }
        public virtual ICollection<T_Auth_ModulePermission> T_Auth_ModulePermission { get; set; }
        public virtual ICollection<T_Auth_RoleModulePermission> T_Auth_RoleModulePermission { get; set; }
    }
}
