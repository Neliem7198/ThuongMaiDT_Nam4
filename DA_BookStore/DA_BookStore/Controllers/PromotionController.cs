using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class PromotionController : Controller
    {
        [HttpGet]
        public ActionResult DetailPromotion(string id = "")
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    Models.KHUYENMAI km = db.KHUYENMAIs.Find(id);
                    ViewBag.KhuyenMai = km;
                    Session["promotionID"] = id;
                    km = db.KHUYENMAIs.Where(t => t.MaKhuyenMai == id).FirstOrDefault();
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                }
                return View();

            }
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult PromotionManage(int index = 0)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                    List<Models.KHUYENMAI> lst = db.KHUYENMAIs.Where(t => t.HienThiKM == true).ToList();
                    ViewBag.DsKM = lst.Skip(15 * index).Take(15);
                    ViewBag.slKM = lst.Count();
                }

                return View();
            }
            return RedirectToAction("Home", "Home");
        }
        [HttpPost]
        public ActionResult PromotionManage(string id, int index)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                    List<Models.KHUYENMAI> lst = db.KHUYENMAIs.Where(t => t.HienThiKM == true && t.TenKhuyenMai.Contains(id)).ToList();
                    ViewBag.DsS = lst.Skip(15 * index).Take(15);
                    ViewBag.slS = lst.Count();
                }

                return View();
            }
            return RedirectToAction("Home", "Home");
        }

        [HttpGet]
        public ActionResult AddPromotion()
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                }

                return View();
            }
            return RedirectToAction("Home", "Home");
        }
        [HttpPost]
        public ActionResult AddPromotion(string tenKhuyenMai, string ngayBatDau, string ngayKetThuc, string phanTramKhuyenMai, List<string> dsTL)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    Models.KHUYENMAI km = new Models.KHUYENMAI();
                    int slKM = db.KHUYENMAIs.ToList().Count() + 1;
                        
                    var maKM = "KM" + slKM.ToString().PadLeft(8, '0');

                    km.MaKhuyenMai = maKM;
                    km.TenKhuyenMai = tenKhuyenMai;
                    km.NgayBatDau = DateTime.Parse(ngayBatDau);
                    km.NgayKetThuc = DateTime.Parse(ngayKetThuc);
                    km.PhanTramKhuyenMai = byte.Parse(phanTramKhuyenMai);
                    km.HienThiKM = true;

                    db.KHUYENMAIs.Add(km);
                    db.SaveChanges();

                    UpdateBookPromotion(maKM, dsTL);

                    return RedirectToAction("PromotionManage", "Promotion");
                }
            }
            return RedirectToAction("Home", "Home");
        }

        public ActionResult DeletePromotion(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    Models.KHUYENMAI km = db.KHUYENMAIs.Find(id);
                    km.HienThiKM = false;

                    List<Models.DIENTHOAI> listS = db.DIENTHOAIs.Where(s => s.MaKhuyenMai == id).ToList();
                    foreach (var item in listS)
                    {
                        item.MaKhuyenMai = null;
                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("PromotionManage", "Promotion");

            }
            return RedirectToAction("Home", "Home");
        }

        //[HttpGet]
        //public ActionResult PromotionUpdate(string id)
        //{
        //    if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
        //    {
        //        using (var db = new Models.QLPhone())
        //        {
        //            ViewBag.DsTL = db.HANGSANXUATs.ToList();

        //            Session["promotionID"] = id;

        //            ViewBag.id = id;
        //            Models.KHUYENMAI km = db.KHUYENMAIs.Where(t => t.MaKhuyenMai == id).FirstOrDefault();

        //            ViewBag.KhuyenMai = km;

        //            if (km.HienThiKM == false)
        //                return RedirectToAction("Home", "Home");
        //        }
               
        //    }
        //    return View();
        //}
        [HttpPost]
        public ActionResult UpdatePromotion(string tenKhuyenMai, string ngayBatDau, string ngayKetThuc, string phanTramKhuyenMai, List<string> dsTL)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    Models.KHUYENMAI km = db.KHUYENMAIs.Find(Session["promotionID"]);
                    km.TenKhuyenMai = tenKhuyenMai;
                    km.NgayBatDau = DateTime.Parse(ngayBatDau);
                    km.NgayKetThuc = DateTime.Parse(ngayKetThuc);
                    km.PhanTramKhuyenMai = byte.Parse(phanTramKhuyenMai);
                    km.HienThiKM = true;

                    db.Entry(km).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    UpdateBookPromotion(km.MaKhuyenMai, dsTL);
                }
                return RedirectToAction("PromotionManage", "Promotion");
            }
            return RedirectToAction("Home", "Home");
        }

        private void UpdateBookPromotion(string maKM, List<string> dsTL)
        {
            using (var db = new Models.QLPhone())
            {
                List<Models.DIENTHOAI> listS = db.DIENTHOAIs.ToList();

                foreach (var s in listS)
                {
                    if (s.MaKhuyenMai == maKM)
                    {
                        s.MaKhuyenMai = null;
                        db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    }
                }

                foreach (var tl in dsTL)
                {
                    foreach (var s in listS)
                    {
                        if (s.MaHangSanXuat == tl)
                        {
                            s.MaKhuyenMai = maKM;
                            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                        }
                    }
                }
                db.SaveChanges();
            }
        }
    }
}