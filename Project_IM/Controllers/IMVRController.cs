using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_IM.Models;
using System.Web.UI.WebControls;

namespace Project_IM.Controllers
{
    public class IMVRController : Controller
    {
        private IM_Db db = new IM_Db();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult VR()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult Video1()
        {
            //取得影片清單資料
            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["ID"] == "全部影片")
                {
                    var video = (from c in db.Video
                                 select c).ToList();
                    return View(video);
                }
                else
                {
                    int id = int.Parse(Request.QueryString["ID"]);
                    var video = (from c in db.Video
                                 where c.開始地點 == id || c.結束地點 == id
                                 select c).ToList();
                    return View(video);
                }
            }

            ViewBag.HaveData = false;
            return View();
        }

        public ActionResult Video2()
        {
            //取得特定起點的影片資料
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                var video = (from c in db.Video
                             where c.開始地點 == id
                             select c).ToList();
                ViewBag.HaveData2 = true;
                return View(video);
            }
            else
            {
                ViewBag.HaveData2 = false;
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetUrl(int select)
        {
            //取得影片網址
            var videoURL = db.Video.Where(v => v.影片ID == select)
               .Select(v => v.影片網址)
               .FirstOrDefault();
            //取得地圖網址
            var imgSrc = db.Video.Where(v => v.影片ID == select)
                .Select(v => v.路徑地圖)
                .FirstOrDefault();

            string url = "<iframe src=\"" + videoURL + "\" allowfullscreen></iframe>" + "<img src=\"" + imgSrc + "\" class=\"container w-85\"/>";
            return Content(url);
        }

        public ActionResult _SelectPlace()
        {
            //取得下拉式選單地點資料
            var placeList = (from p in db.Place_name
                             select p).ToList();
            return PartialView(placeList);
        }

        public ActionResult _SelectPlace2()
        {
            //取得下拉式選單地點資料
            var placeList2 = (from p in db.Place_name
                              where p.是否起點 == true
                              select p).ToList();
            ViewBag.ID = Request.QueryString["ID"];
            return PartialView(placeList2);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
