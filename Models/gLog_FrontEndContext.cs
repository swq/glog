using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using gLog_FrontEnd.Models.Mapping;

namespace gLog_FrontEnd.Models
{

    public partial class gLog_FrontEndContext : DbContext
    {



        public gLog_FrontEndContext()
            : base("Name=gLog_FrontEndContext")

        {
            //this.Database.Initialize(false);
        }

        public DbSet<SysConfig_OperateLog> SysConfig_OperateLog { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<T_Auth_Module> T_Auth_Module { get; set; }
        public DbSet<T_Auth_ModulePermission> T_Auth_ModulePermission { get; set; }
        public DbSet<T_Auth_Permission> T_Auth_Permission { get; set; }
        public DbSet<T_Auth_Role> T_Auth_Role { get; set; }
        public DbSet<T_Auth_RoleModulePermission> T_Auth_RoleModulePermission { get; set; }
        public DbSet<T_Auth_User> T_Auth_User { get; set; }
        public DbSet<T_Auth_UserRole> T_Auth_UserRole { get; set; }
        public DbSet<T_CardType> T_CardType { get; set; }
        public DbSet<T_Part> T_Part { get; set; }
        public DbSet<T_Progress> T_Progress { get; set; }
        public DbSet<T_State> T_State { get; set; }
        public DbSet<CNYD_STRUCT_TREE> CNYD_STRUCT_TREE { get; set; }
<<<<<<< .mine
=======
        public DbSet<TC_ProjectState> TC_ProjectState { get; set; }
        public DbSet<TC_ProjectType> TC_ProjectType { get; set; }
        public DbSet<TC_GeographyArea> TC_GeographyArea { get; set; }
        public DbSet<T_TA_Info> T_TA_Info { get; set; }
        public DbSet<TC_Country> TC_Country { get; set; }
>>>>>>> .r1375
        public DbSet<T_TA_STRUCT> T_TA_STRUCT { get; set; }
        public DbSet<T_UserPro> T_UserPro { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysConfig_OperateLogMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new T_Auth_ModuleMap());
            modelBuilder.Configurations.Add(new T_Auth_ModulePermissionMap());
            modelBuilder.Configurations.Add(new T_Auth_PermissionMap());
            modelBuilder.Configurations.Add(new T_Auth_RoleMap());
            modelBuilder.Configurations.Add(new T_Auth_RoleModulePermissionMap());
            modelBuilder.Configurations.Add(new T_Auth_UserMap());
            modelBuilder.Configurations.Add(new T_Auth_UserRoleMap());
            modelBuilder.Configurations.Add(new T_CardTypeMap());
            modelBuilder.Configurations.Add(new T_CompanyMap());
            modelBuilder.Configurations.Add(new T_CountryMap());
            modelBuilder.Configurations.Add(new T_PartMap());
            modelBuilder.Configurations.Add(new T_ProgressMap());
            modelBuilder.Configurations.Add(new T_ProjectMap());
            modelBuilder.Configurations.Add(new T_StateMap());
            modelBuilder.Configurations.Add(new T_UserMap());

            modelBuilder.HasDefaultSchema("CNYDWBS");
        }
    }
}
