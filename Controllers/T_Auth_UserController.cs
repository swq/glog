using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gLog_FrontEnd.Models;
using System.Web.Security;
using gLog_FrontEnd.Filters;
using System.Web.Script.Serialization;
using System.Data.Entity.Infrastructure;

namespace gLog_FrontEnd.Controllers
{
    public class T_Auth_UserController : Controller
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();

        //
        // 登录
        public ActionResult Login()
        {
<<<<<<< .mine
            return View();
=======

            ////角色
            //var roles = new List<T_Auth_Role>
            //{
            //    new T_Auth_Role { Id = 1, Name = "系统管理员", Description = "开发人员、系统配置人员使用", OrderSort = 1, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Role { Id = 2, Name = "网站管理员", Description = "网站内容管理人员", OrderSort = 2, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now }
            //};
            //DbSet<T_Auth_Role> roleSet = db.Set<T_Auth_Role>();
            //roleSet.AddOrUpdate(t => new { t.Id }, roles.ToArray());
            //db.SaveChanges();

            ////用户
            //var users = new List<T_Auth_User>
            //{
            //    new T_Auth_User { Id = 1, LoginName = "admin", LoginPwd = "8wdJLK8mokI=", FullName="admin", Email = "terrychen@qq.com", Phone ="123456", Enabled = true, IsDeleted = false, PwdErrorCount = 0, LoginCount = 0, RegisterTime = DateTime.Now, LastLoginTime = DateTime.Now, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now }
            //};
            //DbSet<T_Auth_User> userSet = db.Set<T_Auth_User>();
            //userSet.AddOrUpdate(t => new { t.Id }, users.ToArray());
            //db.SaveChanges();

            ////用户-角色
            //var userRoles = new List<T_Auth_UserRole>
            //{
            //    new T_Auth_UserRole { UserId = 1, RoleId = 1, IsDeleted = false },
            //};
            //DbSet<T_Auth_UserRole> userRoleSet = db.Set<T_Auth_UserRole>();
            //userRoleSet.AddOrUpdate(t => new { t.UserId }, userRoles.ToArray());
            //db.SaveChanges();

            ////模块
            //var modules = new List<T_Auth_Module>
            //{
            //    new T_Auth_Module { Id = 1, ParentId = null, Name = "权限管理", LinkUrl = null, Area = null, Controller = null, Action = null, Icon = "icon-sitemap", Code = "20", OrderSort = 1, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 2, ParentId = 1, Name = "角色管理", LinkUrl = "Authen/Role/Index", Area = "Authen", Controller = "Role", Action = "Index", Icon = "", Code = "2001", OrderSort = 2, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 3, ParentId = 1, Name = "用户管理", LinkUrl = "Authen/User/Index", Area = "Authen", Controller = "User", Action = "Index", Icon = "", Code = "2002", OrderSort = 3, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 4, ParentId = 1, Name = "模块管理", LinkUrl = "Authen/Module/Index", Area = "Authen", Controller = "Module", Action = "Index", Icon = "", Code = "2003", OrderSort = 4, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 5, ParentId = 1, Name = "权限管理", LinkUrl = "Authen/Permission/Index", Area = "Authen", Controller = "Permission", Action = "Index", Icon = "", Code = "2004", OrderSort = 5, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 6, ParentId = null, Name = "系统应用", LinkUrl = null, Area = null, Controller = null, Action = null, Icon = "icon-cloud", Code = "30", OrderSort = 1, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 7, ParentId = 6, Name = "操作日志管理", LinkUrl = "SysConfig/OperateLog/Index", Area = "SysConfig", Controller = "OperateLog", Action = "Index", Icon = "", Code = "3001", OrderSort = 2, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 8, ParentId = 6, Name = "图标附录", LinkUrl = "SysConfig/Appendix/Icon", Area = "SysConfig", Controller = "Appendix", Action = "Icon", Icon = "", Code = "3002", OrderSort = 3, Description = null, IsMenu = true, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "admin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 9, ParentId = null, Name = "个人资料", LinkUrl = "Common/Profile/Index", Area = "Common", Controller = "Profile", Action = "Index", Icon = "", Code = "9001", OrderSort = 1, Description = null, IsMenu = false, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now },
            //    new T_Auth_Module { Id = 10, ParentId = null, Name = "修改密码", LinkUrl = "Common/Profile/ChangePwd", Area = "Common", Controller = "Profile", Action = "Index", Icon = "", Code = "9002", OrderSort = 1, Description = null, IsMenu = false, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now }
            //};
            //DbSet<T_Auth_Module> moduleSet = db.Set<T_Auth_Module>();
            //moduleSet.AddOrUpdate(t => new { t.Id }, modules.ToArray());
            //db.SaveChanges();

            ////权限
            //var permissions = new List<T_Auth_Permission>
            //{
            //    new T_Auth_Permission { Id = 1, Code = "Index", Name = "浏览", Icon = null, Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 2, Code = "Create", Name = "新增", Icon = "icon-plus", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 3, Code = "Edit", Name = "编辑", Icon = "icon-pencil", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 4, Code = "Delete", Name = "删除", Icon = "icon-remove", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 5, Code = "SetButton", Name = "设置按钮", Icon = "icon-legal", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 6, Code = "SetPermission", Name = "设置权限", Icon = "icon-sitemap", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 7, Code = "ChangePwd", Name = "修改密码", Icon = "icon-key", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_Permission { Id = 8, Code = "DeleteAll", Name = "删除全部", Icon = "icon-trash", Description = null, Enabled = true, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  }
            //};
            //DbSet<T_Auth_Permission> permissionSet = db.Set<T_Auth_Permission>();
            //permissionSet.AddOrUpdate(t => new { t.Id }, permissions.ToArray());
            //db.SaveChanges();

            ////模块-权限
            //var modulePermissions = new List<T_Auth_ModulePermission>
            //{
            //    new T_Auth_ModulePermission { Id = 1, ModuleId = 2, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 2, ModuleId = 2, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 3, ModuleId = 2, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 4, ModuleId = 2, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 5, ModuleId = 2, PermissionId = 6, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_ModulePermission { Id = 6, ModuleId = 3, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 7, ModuleId = 3, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 8, ModuleId = 3, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 9, ModuleId = 3, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 10, ModuleId = 3, PermissionId = 7, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_ModulePermission { Id = 11, ModuleId = 4, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 12, ModuleId = 4, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 13, ModuleId = 4, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 14, ModuleId = 4, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 15, ModuleId = 4, PermissionId = 5, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_ModulePermission { Id = 16, ModuleId = 5, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 17, ModuleId = 5, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 18, ModuleId = 5, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 19, ModuleId = 5, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_ModulePermission { Id = 20, ModuleId = 7, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 21, ModuleId = 7, PermissionId = 8, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_ModulePermission { Id = 22, ModuleId = 8, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_ModulePermission { Id = 23, ModuleId = 9, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  }
            //};

            //DbSet<T_Auth_ModulePermission> modulePermissionsSet = db.Set<T_Auth_ModulePermission>();
            //modulePermissionsSet.AddOrUpdate(t => new { t.Id }, modulePermissions.ToArray());
            //db.SaveChanges();

            ////角色-模块-权限
            //var roleModulePermissions = new List<T_Auth_RoleModulePermission>
            //{
            //     new T_Auth_RoleModulePermission { Id = 1, RoleId = 1, ModuleId = 1, PermissionId = null, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 2, RoleId = 1, ModuleId = 2, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 3, RoleId = 1, ModuleId = 2, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 4, RoleId = 1, ModuleId = 2, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 5, RoleId = 1, ModuleId = 2, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 6, RoleId = 1, ModuleId = 2, PermissionId = 6, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 7, RoleId = 1, ModuleId = 3, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 8, RoleId = 1, ModuleId = 3, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 9, RoleId = 1, ModuleId = 3, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 10, RoleId = 1, ModuleId = 3, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 11, RoleId = 1, ModuleId = 3, PermissionId = 7, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 12, RoleId = 1, ModuleId = 4, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 13, RoleId = 1, ModuleId = 4, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 14, RoleId = 1, ModuleId = 4, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 15, RoleId = 1, ModuleId = 4, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 16, RoleId = 1, ModuleId = 4, PermissionId = 5, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 17, RoleId = 1, ModuleId = 5, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 18, RoleId = 1, ModuleId = 5, PermissionId = 2, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 19, RoleId = 1, ModuleId = 5, PermissionId = 3, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 20, RoleId = 1, ModuleId = 5, PermissionId = 4, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 21, RoleId = 1, ModuleId = 6, PermissionId = null, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 22, RoleId = 1, ModuleId = 7, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 23, RoleId = 1, ModuleId = 7, PermissionId = 8, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },

            //    new T_Auth_RoleModulePermission { Id = 24, RoleId = 1, ModuleId = 8, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  },
            //    new T_Auth_RoleModulePermission { Id = 25, RoleId = 1, ModuleId = 9, PermissionId = 1, IsDeleted = false, CreateBy = "admin", CreateId = 1, CreateTime = DateTime.Now, ModifyId = 1, ModifyBy = "amdin", ModifyTime = DateTime.Now  }
            //};

            //DbSet<T_Auth_RoleModulePermission> roleModulePermissionSet = db.Set<T_Auth_RoleModulePermission>();
            //roleModulePermissionSet.AddOrUpdate(t => new { t.Id }, roleModulePermissions.ToArray());
            //db.SaveChanges();


            //Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //Module[] modules = assembly.GetModules();
            //foreach (Module module in modules)
            //{
            //    var Name = module.Name;
            //    module.Assembly.GetModules()

            //}

            return View();
>>>>>>> .r1322
        }
        //登录提交
        [HttpPost]
        public ActionResult Login(T_Auth_User model)
        {

            var newuser = new T_Auth_User  {
                  LoginName="admin",
                  LoginPwd = "123456"
            };

            db.T_Auth_User.Add(newuser);
            db.SaveChanges();


            model.LoginPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(model.LoginPwd, "MD5").ToLower();
            var user = db.T_Auth_User.FirstOrDefault(
                s => s.LoginName == model.LoginName
                    && s.LoginPwd == model.LoginPwd
                    && s.Enabled == true
                    && s.IsDeleted == false);

            if (user != null)
            {
                Session["User"] = user;
                Session.Timeout = 120;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "用户名或密码错误！";
                return View();
            }

        }
        //主页面
        [AdminLayout]
        public ActionResult Index()
        {
            return View();
        }
        //获取用户数据
        public JsonResult GetUser(int limit, int offset, string departmentname, string statu)
        {

            var t_auth_user = db.T_Auth_User.AsNoTracking().Where(s => s.IsDeleted == false)
                .Select(s => new { s.Id, s.LoginName,s.LoginPwd, s.Phone, s.Email, s.Enabled, s.FullName })
                .OrderBy(s => s.Id)
                .Skip(offset)
                .Take(limit)
                .ToList();  //.Include(t => t.T_Country).Include(t => t.T_Part);
            var total = t_auth_user.Count;
            //var rows = t_auth_user.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = t_auth_user }, JsonRequestBehavior.AllowGet);
        }
        //提交创建和修改
        [HttpPost]
        public JsonResult GetEdit(string data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var User = js.Deserialize<T_Auth_User>(data);
            if (User.Id == -1)
            {
                User.PwdErrorCount = 0;
                User.LoginCount = 0;
                User.IsDeleted = false;
                User.LoginPwd = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
                db.T_Auth_User.Add(User);
            }
            else
            {
                DbEntityEntry<T_Auth_User> dbEntry = db.Entry<T_Auth_User>(User);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.FullName).IsModified = true;
                dbEntry.Property(s => s.LoginName).IsModified = true;
                dbEntry.Property(s => s.Phone).IsModified = true;
                dbEntry.Property(s => s.Email).IsModified = true;
                dbEntry.Property(s => s.Enabled).IsModified = true;
            }
            db.SaveChanges();
            return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
        }
        //提交删除
        [HttpPost]
        public JsonResult Del(string data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Users = js.Deserialize<List<T_Auth_User>>(data);
            foreach (var temp in Users)
            {
                temp.IsDeleted = true;
                db.Entry(temp).State = EntityState.Unchanged;
                db.Entry(temp).Property(s => s.IsDeleted).IsModified = true;
            }
            var status = "success";
            if(db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }
        //提交重置密码
        [HttpPost]
        public JsonResult ResetKey(string data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var Users = js.Deserialize<List<T_Auth_User>>(data);
            foreach (var temp in Users)
            {
                temp.LoginPwd = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5").ToLower();
                DbEntityEntry<T_Auth_User> dbEntry = db.Entry<T_Auth_User>(temp);
                dbEntry.State = EntityState.Unchanged;
                dbEntry.Property(s => s.LoginPwd).IsModified = true;
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }
            return Json(new { status = status }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Set_Auther(int UserId)
        {
            var Roles = db.T_Auth_Role.AsNoTracking().Where(s => s.IsDeleted == false)
                .Select(s => new {s.Id,s.Name});
            var UserRoles = db.T_Auth_UserRole.AsNoTracking().Where(s => s.IsDeleted == false && s.UserId == UserId)
                .Select(s => new { s.UserId, s.RoleId });

            var data = (from Role in Roles
                        join UserRole in UserRoles on
                        Role.Id equals UserRole.RoleId into temps
                        from temp in temps.DefaultIfEmpty()
                        select new {id = Role.Id,Name = Role.Name,IsChecked = temp.RoleId != null ? true : false}).ToList();

            return Json(new { Msg = "success", data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save_Auther(string data, int UserId)
        {
            var Userinfo = Session["User"] as T_Auth_User;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var L_Id = js.Deserialize<List<int>>(data);

            var oldDataList = db.T_Auth_UserRole.Where(t => t.UserId == UserId && t.IsDeleted == false)
                .Select(t => t.RoleId).ToList();
            var newDataList = js.Deserialize<List<int>>(data);
            var intersectIds = oldDataList.Intersect(newDataList).ToList(); // Same Ids
            var updateIds = oldDataList.Except(intersectIds).ToList(); // Remove Ids
            var addIds = newDataList.Except(oldDataList).ToList(); // Add Ids
            //逻辑删除
            foreach (var removeId in updateIds)
            {
                var updateEntity = db.T_Auth_UserRole.AsNoTracking()
                    .FirstOrDefault(t => t.UserId == UserId && t.RoleId == removeId && t.IsDeleted == false);

                if (updateEntity != null)
                {
                    updateEntity.IsDeleted = true;
                    db.Entry(updateEntity).State = EntityState.Unchanged;
                    db.Entry(updateEntity).Property(s => s.IsDeleted).IsModified = true;
                }
            }
            //插入 & 更新
            foreach (var addId in addIds)
            {
                var updateEntity = db.T_Auth_UserRole.AsNoTracking()
                    .FirstOrDefault(t => t.UserId == UserId && t.RoleId == addId && t.IsDeleted == true);
                if (updateEntity != null)
                {
                    updateEntity.IsDeleted = false;
                    updateEntity.ModifyId = Userinfo.Id;
                    updateEntity.ModifyBy = Userinfo.LoginName;
                    db.Entry(updateEntity).State = EntityState.Unchanged;
                    db.Entry(updateEntity).Property(s => s.IsDeleted).IsModified = true;
                    db.Entry(updateEntity).Property(s => s.ModifyId).IsModified = true;
                    db.Entry(updateEntity).Property(s => s.ModifyBy).IsModified = true;
                }
                else
                {
                    var addEntity = new T_Auth_UserRole
                    {
                        UserId = UserId,
                        RoleId = addId,
                        CreateTime = DateTime.Now,
                        ModifyId = Userinfo.Id,
                        ModifyBy = Userinfo.LoginName,
                        IsDeleted = false
                    };
                    db.T_Auth_UserRole.Add(addEntity);
                }
            }
            var status = "success";
            if (db.SaveChanges() <= 0)
            {
                status = "fail";
            }

            return Json(new { Msg = status }, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /T_Auth_User/Details/5

        public ActionResult Details(int id = 0)
        {
            T_Auth_User t_auth_user = db.T_Auth_User.Find(id);
            if (t_auth_user == null)
            {
                return HttpNotFound();
            }
            return View(t_auth_user);
        }

        //
        // GET: /T_Auth_User/Create

        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.T_Country, "ID", "Country");
            ViewBag.PartID = new SelectList(db.T_Part, "ID", "FName");
            return View();
        }

        //
        // POST: /T_Auth_User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_Auth_User t_auth_user)
        {
            if (ModelState.IsValid)
            {
                db.T_Auth_User.Add(t_auth_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.T_Country, "ID", "Country", t_auth_user.CountryID);
            ViewBag.PartID = new SelectList(db.T_Part, "ID", "FName", t_auth_user.PartID);
            return View(t_auth_user);
        }

        //
        // GET: /T_Auth_User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            T_Auth_User t_auth_user = db.T_Auth_User.Find(id);
            if (t_auth_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.T_Country, "ID", "Country", t_auth_user.CountryID);
            ViewBag.PartID = new SelectList(db.T_Part, "ID", "FName", t_auth_user.PartID);
            return View(t_auth_user);
        }

        //
        // POST: /T_Auth_User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(T_Auth_User t_auth_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_auth_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.T_Country, "ID", "Country", t_auth_user.CountryID);
            ViewBag.PartID = new SelectList(db.T_Part, "ID", "FName", t_auth_user.PartID);
            return View(t_auth_user);
        }

        //
        // GET: /T_Auth_User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            T_Auth_User t_auth_user = db.T_Auth_User.Find(id);
            if (t_auth_user == null)
            {
                return HttpNotFound();
            }
            return View(t_auth_user);
        }

        //
        // POST: /T_Auth_User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Auth_User t_auth_user = db.T_Auth_User.Find(id);
            db.T_Auth_User.Remove(t_auth_user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}