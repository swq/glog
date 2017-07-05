namespace gLog_FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CNYDWBS.SysConfig_OperateLog",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 19, scale: 0, identity: true),
                        Area = c.String(maxLength: 50),
                        Controller = c.String(maxLength: 50),
                        Action = c.String(maxLength: 50),
                        IPAddress = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        LogTime = c.DateTime(),
                        LoginName = c.String(maxLength: 50),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CNYDWBS.T_Auth_User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "CNYDWBS.T_Auth_User",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        LoginName = c.String(maxLength: 50),
                        LoginPwd = c.String(maxLength: 50),
                        FullName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        PartID = c.Decimal(precision: 10, scale: 0),
                        CountryID = c.Decimal(precision: 10, scale: 0),
                        Enabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        PwdErrorCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LoginCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        RegisterTime = c.DateTime(),
                        LastLoginTime = c.DateTime(),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CNYDWBS.T_Country", t => t.CountryID)
                .ForeignKey("CNYDWBS.T_Part", t => t.PartID)
                .Index(t => t.CountryID)
                .Index(t => t.PartID);
            
            CreateTable(
                "CNYDWBS.T_Auth_UserRole",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CNYDWBS.T_Auth_Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("CNYDWBS.T_Auth_User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "CNYDWBS.T_Auth_Role",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                        OrderSort = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Enabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CNYDWBS.T_Auth_RoleModulePermission",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ModuleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PermissionId = c.Decimal(precision: 10, scale: 0),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CNYDWBS.T_Auth_Module", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("CNYDWBS.T_Auth_Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "CNYDWBS.T_Auth_Module",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ParentId = c.Decimal(precision: 10, scale: 0),
                        Name = c.String(maxLength: 50),
                        LinkUrl = c.String(maxLength: 100),
                        Area = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        Icon = c.String(maxLength: 100),
                        Code = c.String(maxLength: 10),
                        OrderSort = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Description = c.String(maxLength: 100),
                        IsMenu = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Enabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CNYDWBS.T_Auth_Module", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "CNYDWBS.T_Auth_ModulePermission",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ModuleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PermissionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CNYDWBS.T_Auth_Module", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("CNYDWBS.T_Auth_Permission", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "CNYDWBS.T_Auth_Permission",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Code = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        SortOrder = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Icon = c.String(maxLength: 100),
                        Description = c.String(maxLength: 100),
                        Enabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        CreateId = c.Decimal(precision: 10, scale: 0),
                        CreateBy = c.String(maxLength: 50),
                        CreateTime = c.DateTime(),
                        ModifyId = c.Decimal(precision: 10, scale: 0),
                        ModifyBy = c.String(maxLength: 50),
                        ModifyTime = c.DateTime(),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CNYDWBS.T_Country",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Country = c.String(nullable: false, maxLength: 250),
                        Country_EN = c.String(maxLength: 250),
                        Createtime = c.DateTime(),
                        IsDelete = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "CNYDWBS.T_User",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Ghcode = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        PartID = c.Decimal(precision: 10, scale: 0),
                        CountryID = c.Decimal(precision: 10, scale: 0),
                        Createtime = c.DateTime(),
                        IsDelete = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("CNYDWBS.T_Country", t => t.CountryID)
                .ForeignKey("CNYDWBS.T_Part", t => t.PartID)
                .Index(t => t.CountryID)
                .Index(t => t.PartID);
            
            CreateTable(
                "CNYDWBS.T_Part",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CompanyID = c.Decimal(precision: 10, scale: 0),
                        FParentID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FLevel = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FName = c.String(nullable: false, maxLength: 200),
                        FName_EN = c.String(maxLength: 200),
                        Createtime = c.DateTime(),
                        FIsDelete = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("CNYDWBS.T_Company", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "CNYDWBS.T_Company",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Company_Code = c.String(maxLength: 20),
                        Company = c.String(maxLength: 100),
                        Company_EN = c.String(maxLength: 100),
                        Createtime = c.DateTime(),
                        IsDelete = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "CNYDWBS.T_Project",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProjectName = c.String(maxLength: 50),
                        ProjectCode = c.String(maxLength: 50),
                        CompanyID = c.Decimal(precision: 10, scale: 0),
                        Createtime = c.DateTime(),
                        Isdeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("CNYDWBS.T_Company", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "CNYDWBS.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        version = c.Decimal(precision: 10, scale: 0),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "CNYDWBS.T_CardType",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CardType = c.String(maxLength: 50),
                        IsDeleted = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "CNYDWBS.T_Progress",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProgressName = c.String(maxLength: 50),
                        Createtime = c.DateTime(),
                        IsDelete = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "CNYDWBS.T_State",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        StateName = c.String(maxLength: 50),
                        Createtime = c.DateTime(),
                        IsDelete = c.Decimal(precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CNYDWBS.SysConfig_OperateLog", "UserId", "CNYDWBS.T_Auth_User");
            DropForeignKey("CNYDWBS.T_Auth_User", "PartID", "CNYDWBS.T_Part");
            DropForeignKey("CNYDWBS.T_Auth_User", "CountryID", "CNYDWBS.T_Country");
            DropForeignKey("CNYDWBS.T_User", "PartID", "CNYDWBS.T_Part");
            DropForeignKey("CNYDWBS.T_Part", "CompanyID", "CNYDWBS.T_Company");
            DropForeignKey("CNYDWBS.T_Project", "CompanyID", "CNYDWBS.T_Company");
            DropForeignKey("CNYDWBS.T_User", "CountryID", "CNYDWBS.T_Country");
            DropForeignKey("CNYDWBS.T_Auth_UserRole", "UserId", "CNYDWBS.T_Auth_User");
            DropForeignKey("CNYDWBS.T_Auth_UserRole", "RoleId", "CNYDWBS.T_Auth_Role");
            DropForeignKey("CNYDWBS.T_Auth_RoleModulePermission", "RoleId", "CNYDWBS.T_Auth_Role");
            DropForeignKey("CNYDWBS.T_Auth_RoleModulePermission", "ModuleId", "CNYDWBS.T_Auth_Module");
            DropForeignKey("CNYDWBS.T_Auth_ModulePermission", "PermissionId", "CNYDWBS.T_Auth_Permission");
            DropForeignKey("CNYDWBS.T_Auth_ModulePermission", "ModuleId", "CNYDWBS.T_Auth_Module");
            DropForeignKey("CNYDWBS.T_Auth_Module", "ParentId", "CNYDWBS.T_Auth_Module");
            DropIndex("CNYDWBS.SysConfig_OperateLog", new[] { "UserId" });
            DropIndex("CNYDWBS.T_Auth_User", new[] { "PartID" });
            DropIndex("CNYDWBS.T_Auth_User", new[] { "CountryID" });
            DropIndex("CNYDWBS.T_User", new[] { "PartID" });
            DropIndex("CNYDWBS.T_Part", new[] { "CompanyID" });
            DropIndex("CNYDWBS.T_Project", new[] { "CompanyID" });
            DropIndex("CNYDWBS.T_User", new[] { "CountryID" });
            DropIndex("CNYDWBS.T_Auth_UserRole", new[] { "UserId" });
            DropIndex("CNYDWBS.T_Auth_UserRole", new[] { "RoleId" });
            DropIndex("CNYDWBS.T_Auth_RoleModulePermission", new[] { "RoleId" });
            DropIndex("CNYDWBS.T_Auth_RoleModulePermission", new[] { "ModuleId" });
            DropIndex("CNYDWBS.T_Auth_ModulePermission", new[] { "PermissionId" });
            DropIndex("CNYDWBS.T_Auth_ModulePermission", new[] { "ModuleId" });
            DropIndex("CNYDWBS.T_Auth_Module", new[] { "ParentId" });
            DropTable("CNYDWBS.T_State");
            DropTable("CNYDWBS.T_Progress");
            DropTable("CNYDWBS.T_CardType");
            DropTable("CNYDWBS.sysdiagrams");
            DropTable("CNYDWBS.T_Project");
            DropTable("CNYDWBS.T_Company");
            DropTable("CNYDWBS.T_Part");
            DropTable("CNYDWBS.T_User");
            DropTable("CNYDWBS.T_Country");
            DropTable("CNYDWBS.T_Auth_Permission");
            DropTable("CNYDWBS.T_Auth_ModulePermission");
            DropTable("CNYDWBS.T_Auth_Module");
            DropTable("CNYDWBS.T_Auth_RoleModulePermission");
            DropTable("CNYDWBS.T_Auth_Role");
            DropTable("CNYDWBS.T_Auth_UserRole");
            DropTable("CNYDWBS.T_Auth_User");
            DropTable("CNYDWBS.SysConfig_OperateLog");
        }
    }
}
