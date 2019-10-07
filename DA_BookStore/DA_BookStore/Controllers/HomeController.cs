using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new Models.BookStore())
            {
                ViewBag.DsSachDeal = db.SACHes.Where(t => t.KHUYENMAI.NgayKetThuc > DateTime.Now && t.HienThiS == true).Take(5).ToList();
                ViewBag.DsTL = db.THELOAIs.ToList();
                ViewBag.DsQC = db.QUANGCAOs.ToList();
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Purchase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Purchase(string idSach )
        {
            //string idKhach = Session["userID"].ToString();
            //using (var db = new Models.BookStore())
            //{
            //    Models.CTGIOHANG ct = new Models.CTGIOHANG();
            //    ct = db.CTGIOHANGs.Where(t => t.MaSach == idSach && t.TenTaiKhoan == idKhach).FirstOrDefault();
            //    ViewBag.cccc = idSach;
            //    db.Entry(ct).State = EntityState.Deleted;
            //    db.SaveChanges();
            //}
            return RedirectToAction("Index", "Home");
        }
    }
}