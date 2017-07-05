using gLog_FrontEnd.DTO;
using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class ForwardController : Controller
    {
        gLog_FrontEndContext db = new gLog_FrontEndContext();

        #region 小箱
        public ActionResult CreateStillage()
        {
            return View();
        }

        public JsonResult GetDataStillage(int? StillageID)
        {
            if (StillageID == null)
            {
                return Json(new { Msg = "fail" }, JsonRequestBehavior.AllowGet);
            }
            var Head = db.Set<T_StillageHead>().AsNoTracking().FirstOrDefault(s => s.ID == StillageID);
            var Data = from l in db.Set<T_StillageData>()
                       join l1 in db.Set<T_BT_INFO>() on l.BTID equals l1.ID
                       where l.StillageID == StillageID
                       select new
                       {
                            ID = l.ID,
                            BTID = l.BTID,
                            ProID = l.ProID,
                            BT_Code = l1.BT_Code,
                            Description_EN = l1.Description_EN,
                            Description_CN = l1.Description_CN,
                            Units = l1.Units,
                            Amount = l.Amount,
                            Qty = l1.Qty,
                            margin = 0,
                            TA_Code = l1.TA_ID,
                            Card_Code =""
                       };
            var DataL = Data.ToList();
            return Json(new { Msg = "success", Data = Data, Head = Head }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateStillageSave(string AddData,string ChangeData,string DeletedData)
        {
            //添加
            if (!string.IsNullOrEmpty(AddData))
            {
                var Add = JsonConvert.DeserializeObject<List<T_StillageData>>(AddData);
                db.Set<T_StillageData>().AddRange(Add);
            }
            var ChangeCount = db.SaveChanges();
            var Msg = ChangeCount > 0 ? "success" : "fail";
            return Json(new { Msg = Msg }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 回调小箱物料
        /// </summary>
        /// <param name="data1">BT条件</param>
        /// <param name="data2">TA条件</param>
        /// <param name="ProID">工程编号</param>
        /// <returns></returns>
        public JsonResult FillData(string data1,string data2,string ProID)
        {
            var expre1 = JsonConvert.DeserializeObject<List<string>>(data1);
            var expre2 = JsonConvert.DeserializeObject<List<string>>(data2).Distinct().ToList();
            //var expre2 = JsonConvert.DeserializeObject<List<int?>>(data2).Distinct().ToList();

            var q = (from p in db.Set<T_StillageData>()
                     group p by p.BTID into g
                     select new
                     {
                         BTID = g.Key,
                         Amount = g.Sum(p => p.Amount)
                     });

            var q1 = (from l1 in
                (from l2 in db.T_BT_INFO
                 where expre1.Contains(l2.BT_Code)
                    && ProID == l2.Pro_ID
                 select l2)
                        where expre2.Contains(l1.TA_CODE)
                        select new
                        {
                            BTID = l1.ID,
                            BT_Code = l1.BT_Code,
                            Description_EN = l1.Description_EN,
                            Description_CN = l1.Description_CN,
                            Units = l1.Units,
                            Qty = l1.Qty,
                            TA_CODE = l1.TA_CODE
                        });

            var Data = (from L in q1
                         join R in q on L.BTID equals R.BTID into temps
                         from temp in temps.DefaultIfEmpty()
                         select new
                         {
                             BTID = L.BTID,
                             BT_Code = L.BT_Code,
                             Description_EN = L.Description_EN,
                             Description_CN = L.Description_CN,
                             Units = L.Units,
                             Qty = L.Qty,
                             TA_CODE = L.TA_CODE,
                             Sum_Amount = temp.Amount == null ? 0 : temp.Amount
                         }).ToList();

            //var Data = (from l1 in
            //                (from l2 in db.T_BT_INFO
            //                 where expre1.Contains(l2.BT_Code)
            //                    && ProID == l2.Pro_ID
            //                 select l2)
            //            where expre2.Contains(l1.TA_CODE)
            //            select new
            //            {
            //                BTID = l1.ID,
            //                BT_Code = l1.BT_Code,
            //                Description_EN = l1.Description_EN,
            //                Description_CN = l1.Description_CN,
            //                Units = l1.Units,
            //                Qty = l1.Qty,
            //                TA_CODE = l1.TA_CODE
            //            }).ToList();

            return Json(new { Msg = "success", Data = Data }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 创建小箱
        /// </summary>
        /// <param name="StillageH">小箱单头项</param>
        /// <returns>小箱单头表</returns>
        public JsonResult CrStillage(string StillageH)
        {
            var user = System.Web.HttpContext.Current.Session["User"] as T_Auth_User;
            var temp = JsonConvert.DeserializeObject<T_StillageHead>(StillageH);
            var bl = db.Set<T_StillageHead>().AsNoTracking().Any(s => s.DeliveryNote == temp.DeliveryNote);
            if (bl)
            {
                return Json(new { Msg = "fail"}, JsonRequestBehavior.AllowGet);
            }
            temp.Createdate = DateTime.Now;
            temp.UserID = user.Id;
            db.Set<T_StillageHead>().Add(temp);
            var ChangeCount = db.SaveChanges();
            var Data = GetSHL(temp.Pro_ID);
            var Msg = ChangeCount > 0 ? "success" : "fail";
            return Json(new { Msg = Msg, Data = Data }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 读小箱单头表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStill(string PJ_ID_)
        {
            var Data = GetSHL(PJ_ID_);
            return Json(new { Msg = "success", Data = Data }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取小箱单头表
        /// </summary>
        /// <returns></returns>
        public IQueryable<DTO_StillageHeader> GetSHL(string PJ_ID_)
        {
            var Data = (from l in db.Set<T_StillageHead>()
                        where l.Pro_ID == PJ_ID_ orderby l.Createdate descending
                        select new DTO_StillageHeader
                        {
                            ID = l.ID,
                            DeliveryNote = l.DeliveryNote,
                            Stillage_Status = l.Stillage_Status
                        });
            return Data;
        }

        public JsonResult ConfrimStill(int ID)
        {
            T_StillageHead model = new T_StillageHead();
            model.ID = ID;
            model.Stillage_Status = "已包装";
            DbEntityEntry<T_StillageHead> entry = db.Entry<T_StillageHead>(model);
            entry.State = EntityState.Unchanged;
            entry.Property("Stillage_Status").IsModified = true;
            db.SaveChanges();
            return Json(new { Msg = "success" }, JsonRequestBehavior.AllowGet);
        }
        [AdminLayout]
        public ActionResult EditStillage()
        {
            return View();
        }
        #endregion





        #region 集装箱
        [AdminLayout]
        public ActionResult HeadShipment()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StillageH"></param>
        /// <returns></returns>
        public JsonResult CreateShip(string ShipHeader)
        {
            var user = System.Web.HttpContext.Current.Session["User"] as T_Auth_User;
            var temp = JsonConvert.DeserializeObject<T_ShipHeader>(ShipHeader);
            temp.CreateDate = DateTime.Now;
            temp.UserID = user.Id;
            temp.ShipStatus = "未装箱";
            db.Set<T_ShipHeader>().Add(temp);
            var ChangeCount = db.SaveChanges();
            var Data = GetShipHL();
            var Msg = ChangeCount > 0 ? "success" : "fail";
            return Json(new { Msg = "success", Data = Data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetShip()
        {
            var Data = GetShipHL();
            return Json(new { Msg = "success", Data = Data }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取集装箱头信息
        /// </summary>
        /// <returns></returns>
        public List<DTO_ShipHL> GetShipHL()
        {
            var Data = (from l in db.Set<T_ShipHeader>()
                        select new DTO_ShipHL
                        {
                            ID = l.ID,
                            etc = l.etc,
                            ShipRef = l.ShipRef,
                            ShipStatus = l.ShipStatus
                        }).ToList();
            return Data;
        }

        public JsonResult GetDataShip(int? ShipID)
        {
            if (ShipID == null)
            {
                return Json(new { Msg = "fail" }, JsonRequestBehavior.AllowGet);
            }
            var Head = db.Set<T_ShipHeader>().AsNoTracking().
                FirstOrDefault(s => s.ID == ShipID);
            var Data = from l in db.Set<T_ShipData>()
                       join l1 in db.Set<T_StillageHead>() on l.StillageID equals l1.ID
                       where l.ShipID == ShipID
                       select new
                       {
                           ID = l.ID,
                           DeliveryNote = l1.DeliveryNote,
                           Stillage_Type = l1.Stillage_Type == "1" ? "铁架" : (l1.Stillage_Type == "2" ? "木箱" : "托盘"),
                           Stillage_Status = l1.Stillage_Status,
                           StillageID = l.StillageID
                       };
            var DataL = Data.ToList();
            return Json(new { Msg = "success", Data = Data, Head = Head }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStillageH()
        {
            var Data = (from l in db.Set<T_StillageHead>()
                        where l.Stillage_Status != "已装入集装箱" && l.Stillage_Status == "已包装"
                        select new
                        {
                            ID = l.ID,
                            DeliveryNote = l.DeliveryNote,
                            //Stillage_Status = l.Stillage_Status == "空箱" ? 1 : 20,
                            Stillage_Type = l.Stillage_Type == "1"? "铁架" : (l.Stillage_Type == "2"? "木箱" : "托盘"),
                            btn = true
                        }).ToList();

            return Json(new { Msg = "success", Data = Data }, JsonRequestBehavior.AllowGet);
        }
        #endregion





        #region 小箱添加到集装箱
        [AdminLayout]
        public ActionResult StillageShipment()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AddJson"></param>
        /// <returns></returns>
        public JsonResult Save(string items,int ShipID)
        {
            var user = System.Web.HttpContext.Current.Session["User"] as T_Auth_User;
            var ChangeCount = 0;
            
            //添加
            if (!string.IsNullOrEmpty(items))
            {
                var newData = JsonConvert.DeserializeObject<List<T_ShipData>>(items);
                var newD = newData.Select(s => new { s.ID, s.ShipID, s.StillageID }).ToList();
                var oldData = db.Set<T_ShipData>().Where(s => s.ShipID == ShipID).Select(s=>new { s.ID,s.ShipID,s.StillageID}).ToList();
                var sames = newD.Intersect(oldData).ToList();
                var addIds = newD.Except(sames).ToList();
                var dels = oldData.Except(sames).ToList();

                //删除做集装箱内小箱&&
                dels.ForEach(s => {
                    T_ShipData model = new T_ShipData();
                    model.ID = (int)s.ID;
                    DbEntityEntry<T_ShipData> entry = db.Entry<T_ShipData>(model);
                    entry.State = EntityState.Deleted;
                });
                dels.ForEach(s => {
                    T_StillageHead model = new T_StillageHead();
                    model.ID = (int)s.StillageID;
                    model.Stillage_Status = "已包装";
                    DbEntityEntry<T_StillageHead> entry = db.Entry<T_StillageHead>(model);
                    entry.State = EntityState.Unchanged;
                    entry.Property("Stillage_Status").IsModified = true;
                });
                //集装箱移箱操作
                var L_ShipData = addIds.ConvertAll<T_ShipData>(s=>new T_ShipData {
                                    Createdate = DateTime.Now,
                                    UserID = user.Id,
                                    ShipID = s.ShipID,
                                    StillageID = s.StillageID
                                });
                db.Set<T_ShipData>().AddRange(L_ShipData);
                //db.SaveChanges();
                addIds.ForEach(s => {
                    T_StillageHead model = new T_StillageHead();
                    model.ID = (int)s.StillageID;
                    model.Stillage_Status = "已装入集装箱";
                    DbEntityEntry<T_StillageHead> entry = db.Entry<T_StillageHead>(model);
                    entry.State = EntityState.Unchanged;
                    entry.Property("Stillage_Status").IsModified = true;
                });

                ChangeCount = db.SaveChanges();
            }

            var mess = ChangeCount > 0 ? "Success" : "Fail";
            return Json(new { mess = mess }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStillageBT(int StillageID)
        {
            var Data = (from l in db.Set<T_StillageData>() 
                        join l1 in db.Set<T_BT_INFO>() on l.BTID equals l1.ID
                        where l.StillageID == StillageID
                        select new
                        {
                            ID = l.ID,
                            BT_Code = l1.BT_Code,
                            Description_CN = l1.Description_CN,
                            Qty = l.Amount,
                            Units = l1.Units
                        }).ToList();
                        
            return Json(new {Msg = "success", Data = Data },JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 确认发货
        /// </summary>
        /// <param name="StillageID"></param>
        /// <returns></returns>
        public JsonResult ConfrimFH(int ShipID)
        {
            T_ShipHeader model = new T_ShipHeader();
            model.ID = ShipID;
            model.ShipStatus = "已发运";
            DbEntityEntry<T_ShipHeader> entry = db.Entry<T_ShipHeader>(model);
            entry.State = EntityState.Unchanged;
            entry.Property("ShipStatus").IsModified = true;
            var rel = db.SaveChanges();
            string Msg = "fail";
            if (rel > 0)
            { Msg = "success"; }
            
            return Json(new { Msg = Msg }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}