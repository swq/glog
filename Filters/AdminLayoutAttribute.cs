using gLog_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Filters
{
    public class AdminLayoutAttribute : ActionFilterAttribute 
    {
        private gLog_FrontEndContext db = new gLog_FrontEndContext();
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var user = HttpContext.Current.Session["User"] as T_Auth_User;

            if (user != null)
            {
                //顶部菜单
                ((ViewResult)filterContext.Result).ViewBag.LoginName = user.LoginName;

                ((ViewResult)filterContext.Result).ViewBag.GHCODE = user.FullName;

                //((ViewResult)filterContext.Result).ViewBag.UserID = user.Id;
                //左侧菜单
                ((ViewResult)filterContext.Result).ViewBag.SidebarMenuModel = InitSidebarMenu(user);

                ////面包屑
                //((ViewResult)filterContext.Result).ViewBag.BreadCrumbModel = InitBreadCrumb(filterContext);

                //按钮
                InitButton(user, filterContext);

            }
        }

        private List<SidebarMenuModel> InitSidebarMenu(T_Auth_User user)
        {

            var entity = db.T_Auth_UserRole.
                Where(s=>s.UserId==user.Id).Select(t => t.RoleId);

            List<int> RoleIds = entity.ToList();
            
            var model = new List<SidebarMenuModel>();

            //取出所有选中的节点
            var parentModuleIdList = db.T_Auth_RoleModulePermission
                .Where(t => RoleIds.Contains(t.RoleId) && t.PermissionId == null && t.IsDeleted == false)
                .Select(t => t.ModuleId).Distinct();
            var childModuleIdList = db.T_Auth_RoleModulePermission
                .Where(t => RoleIds.Contains(t.RoleId) && t.PermissionId != null && t.IsDeleted == false)
                .Select(t => t.ModuleId).Distinct();

            foreach (var pmId in parentModuleIdList)
            {
                //取出父菜单
                var parentModule = db.T_Auth_Module.FirstOrDefault(t => t.Id == pmId);
                if (parentModule != null)
                {
                    var sideBarMenu = new SidebarMenuModel
                    {
                        Id = parentModule.Id,
                        ParentId = parentModule.ParentId,
                        Name = parentModule.Name,
                        Code = parentModule.Code,
                        Icon = parentModule.Icon,
                        LinkUrl = parentModule.LinkUrl,
                    };

                    //取出子菜单
                    foreach (var cmId in childModuleIdList)
                    {
                        var childModule = db.T_Auth_Module.FirstOrDefault(t => t.Id == cmId);
                        if (childModule != null && childModule.ParentId == sideBarMenu.Id)
                        {
                            var childSideBarMenu = new SidebarMenuModel
                            {
                                Id = childModule.Id,
                                ParentId = childModule.ParentId,
                                Name = childModule.Name,
                                Code = childModule.Code,
                                Icon = childModule.Icon,
                                Area = childModule.Area,
                                Controller = childModule.Controller,
                                Action = childModule.Action
                            };
                            sideBarMenu.ChildMenuList.Add(childSideBarMenu);
                        }
                    }

                    //子菜单排序
                    sideBarMenu.ChildMenuList = sideBarMenu.ChildMenuList.OrderBy(t => t.Code).ToList();
                    model.Add(sideBarMenu);
                }
                //父菜单排序
                model = model.OrderBy(t => t.Code).ToList();
            }

            return model;
        }

        private void InitButton(T_Auth_User user, ResultExecutingContext filterContext)
        {
            var roleIds = db.T_Auth_UserRole.Where(s=>s.UserId == user.Id).Select(t => t.RoleId);
            var controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
            var action = filterContext.RouteData.Values["action"].ToString().ToLower();
            var modules = db.T_Auth_Module.Where(t => t.Controller != null).ToList();
            var module = modules.FirstOrDefault(s => s.Controller.ToLower() == controller);
            if (module != null)
            {
                var permissionIds = db.T_Auth_RoleModulePermission
                    .Where(t => roleIds.Contains(t.RoleId) && t.ModuleId == module.Id)
                    .Select(t => t.PermissionId)
                    .Distinct().ToList();
                foreach (var permissionId in permissionIds)
                {
                    var entity = db.T_Auth_Permission.FirstOrDefault(t => t.Id == permissionId && t.Enabled == true && t.IsDeleted == false);
                    if (entity != null)
                    {
                        var btnButton = new 
                        {
                            Id = entity.Code,
                            Icon = entity.Icon,
                            Text = entity.Name
                        };
                        if (entity.Code.ToLower() == "create")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.Create = btnButton;
                        }
                        else if (entity.Code.ToLower() == "edit")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.Edit = btnButton;
                        }
                        else if (entity.Code.ToLower() == "delete")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.Delete = btnButton;
                        }
                        else if (entity.Code.ToLower() == "setbutton")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.SetButton = btnButton;
                        }
                        else if (entity.Code.ToLower() == "setpermission")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.SetPermission = btnButton;
                        }
                        else if (entity.Code.ToLower() == "changepwd")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.ChangePwd = btnButton;
                        }
                        else if (entity.Code.ToLower() == "deleteall")
                        {
                            ((ViewResult)filterContext.Result).ViewBag.DeleteAll = btnButton;
                        }
                    }
                }
            }
        }
    }
}