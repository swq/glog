using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class T_Auth_User
    {
        public T_Auth_User()
        {
            this.SysConfig_OperateLog = new List<SysConfig_OperateLog>();
            this.T_Auth_UserRole = new List<T_Auth_UserRole>();
        }

        public int Id { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> PartID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public bool Enabled { get; set; }
        public int PwdErrorCount { get; set; }
        public int LoginCount { get; set; }
        public Nullable<System.DateTime> RegisterTime { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public Nullable<int> CreateId { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual ICollection<SysConfig_OperateLog> SysConfig_OperateLog { get; set; }
        public virtual ICollection<T_Auth_UserRole> T_Auth_UserRole { get; set; }
    }
}
