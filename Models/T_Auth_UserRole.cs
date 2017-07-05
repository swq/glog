using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Auth_UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Nullable<int> CreateId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual T_Auth_Role T_Auth_Role { get; set; }
        public virtual T_Auth_User T_Auth_User { get; set; }
    }
}
