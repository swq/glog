using gLog_FrontEnd.Filters;
using gLog_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Controllers
{
    public class ReportController : Controller
    {
        gLog_FrontEndContext db = new gLog_FrontEndContext();
        // GET: Chart
        #region TA进度

        [AdminLayout]
        public ActionResult TA_ProgressIndex()
        {
            //request.Headers.Set("host", "glog");
            return View();
        }
        #endregion

        #region BT发运信息

        [AdminLayout]
        public ActionResult BT_Forward()
        {
            return View();
        }

        public JsonResult GetData(string TA_Code)
        {
            if (TA_Code == null)
            {
                return Json(new { Msg = "null" }, JsonRequestBehavior.AllowGet);
            }

            var q1 = from l in db.Set<T_StillageData>()
                     join l1 in db.Set<T_StillageHead>()
                     on l.StillageID equals l1.ID into temps
                     from temp in temps.DefaultIfEmpty()
                     select new
                     {
                         StillageDate = temp.Actual_Packing_Date,
                         StillageCode = temp.DeliveryNote,
                         StillageID = temp.ID,
                         Weight = temp.Weight,
                         Width = temp.Width,
                         Length = temp.Length,
                         Height = temp.Height,
                         StillType = temp.Stillage_Type,
                         BTID = l.BTID,
                         Qty = l.Amount

                     };

            var q2 = from l in q1 join l1 in db.Set<T_ShipData>()
                     on l.StillageID equals l1.StillageID into temps
                     from temp in temps.DefaultIfEmpty()
                     select new
                     {
                         StillageDate = l.StillageDate,
                         StillageCode = l.StillageCode,
                         BTID = l.BTID,
                         T_ShipData_ID = temp.ID,
                         ShipID = temp.ShipID,
                         Weight = l.Weight,
                         Width = l.Width,
                         Length = l.Length,
                         Height = l.Height,
                         StillType = l.StillType,
                         Qty = l.Qty
                     };

            var q3 = from l in q2
                     join l1 in db.Set<T_ShipHeader>()
                       on l.ShipID equals l1.ID into temps
                     from temp in temps.DefaultIfEmpty()
                     select new
                     {
                         StillageDate = l.StillageDate,
                         StillageCode = l.StillageCode,
                         BTID = l.BTID,
                         ShipCode = temp.ShipRef,
                         PC = temp.etc,
                         ShipDate = temp.CreateDate,
                         Weight = l.Weight,
                         Width = l.Width,
                         Length = l.Length,
                         Height = l.Height,
                         StillType = l.StillType,
                         Qty = l.Qty
                     };
            var Data = (from l in q3
                    join l1 in db.T_BT_INFO
                    on l.BTID equals l1.ID into temps
                    from temp in temps.DefaultIfEmpty()
                    where temp.TA_CODE == TA_Code
                        select new
                    {
                        ID = temp.ID == null ? 0 : temp.ID,
                        BT_Code = temp.BT_Code,
                        Comments = temp.Comments,
                        Description_EN = temp.Description_EN,
                        Description_CN = temp.Description_CN,
                        Drawing = temp.Drawing,
                        Order = temp.Order,
                        Units = temp.Units,
                        //Qty = temp.Qty,
                        Specification = temp.Specification,
                        StillageDate = l.StillageDate,
                        StillageCode = l.StillageCode,
                        ShipCode = l.ShipCode,
                        PC = l.PC,
                        ShipDate = l.ShipDate,
                        TA_Code = temp.TA_CODE,
                        Weight = l.Weight,
                        Width = l.Width,
                        Length = l.Length,
                        Height = l.Height,
                        StillType = l.StillType == "1"?"铁架":(l.StillType == "2" ? "木箱" : "托盘"),
                        Qty = l.Qty
                      }).ToList();

            return Json(new { Msg = "null", Data = Data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 查询BT发运信息
        [AdminLayout]
        public ActionResult Search_BT_Forward()
        {
            return View();
        }
        public JsonResult GetBTData(string BT_Code,string Pro_ID)
        {

            if (BT_Code == null)
            {
                return Json(new { Msg = "null" }, JsonRequestBehavior.AllowGet);
            }

            var q1 = from l in db.Set<T_StillageData>()
                     join l1 in db.Set<T_StillageHead>()
                     on l.StillageID equals l1.ID into temps
                     from temp in temps.DefaultIfEmpty()
                     select new
                     {
                         StillageDate = temp.Actual_Packing_Date,
                         StillageCode = temp.DeliveryNote,
                         StillageID = temp.ID,
                         Weight = temp.Weight,
                         Width = temp.Width,
                         Length = temp.Length,
                         Height = temp.Height,
                         BTID = l.BTID,
                         StillType = temp.Stillage_Type,
                         Qty = l.Amount

                     };

            var q2 = from l in q1
                     join l1 in db.Set<T_ShipData>()
        on l.StillageID equals l1.StillageID into temps
                     from temp in temps.DefaultIfEmpty()
                     select new
                     {
                         StillageDate = l.StillageDate,
                         StillageCode = l.StillageCode,
                         BTID = l.BTID,
                         T_ShipData_ID = temp.ID,
                         ShipID = temp.ShipID,
                         Weight = l.Weight,
                         Width = l.Width,
                         Length = l.Length,
                         Height = l.Height,
                         StillType = l.StillType,
                         Qty = l.Qty
                     };

            var q3 = from l in q2
                     join l1 in db.Set<T_ShipHeader>()
                       on l.ShipID equals l1.ID into temps
                     from temp in temps.DefaultIfEmpty()
                     select new
                     {
                         StillageDate = l.StillageDate,
                         StillageCode = l.StillageCode,
                         BTID = l.BTID,
                         ShipCode = temp.ShipRef,
                         PC = temp.etc,
                         ShipDate = temp.CreateDate,
                         Weight = l.Weight,
                         Width = l.Width,
                         Length = l.Length,
                         Height = l.Height,
                         StillType = l.StillType,
                         Qty = l.Qty
                     };
            var Data = (from l in q3
                        join l1 in db.T_BT_INFO
                        on l.BTID equals l1.ID into temps
                        from temp in temps.DefaultIfEmpty()
                        where temp.BT_Code.Contains(BT_Code) && temp.Pro_ID == Pro_ID
                        select new
                        {
                            ID = temp.ID == null ? 0 : temp.ID,
                            BT_Code = temp.BT_Code,
                            Comments = temp.Comments,
                            Description_EN = temp.Description_EN,
                            Description_CN = temp.Description_CN,
                            Drawing = temp.Drawing,
                            Order = temp.Order,
                            Units = temp.Units,
                            //Qty = temp.Qty,
                            Specification = temp.Specification,
                            StillageDate = l.StillageDate,
                            StillageCode = l.StillageCode,
                            ShipCode = l.ShipCode,
                            PC = l.PC,
                            ShipDate = l.ShipDate,
                            TA_Code = temp.TA_CODE,
                            Weight = l.Weight,
                            Width = l.Width,
                            Length = l.Length,
                            Height = l.Height,
                            StillType = l.StillType == "1" ? "铁架" : (l.StillType == "2" ? "木箱" : "托盘"),
                            Qty = l.Qty
                        }).ToList();
            return Json(new { Msg = "null", Data = Data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
