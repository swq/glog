using System;
using System.Collections.Generic;

namespace gLog_FrontEnd.Models
{
    public partial class SysConfig_OperateLog
    {
        public long Id { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> LogTime { get; set; }
        public string LoginName { get; set; }
        public int UserId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public virtual T_Auth_User T_Auth_User { get; set; }
    }
}
