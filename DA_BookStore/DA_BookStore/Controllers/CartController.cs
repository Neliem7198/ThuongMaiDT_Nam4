using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class CartController : Controller
    {
        public ActionResult GetToCart(int soLuong)
        {

            if (Session["userID"] != null)
            {
                using (var db = new Models.QLPhone())
                {
                    Models.CTGIOHANG ct = new Models.CTGIOHANG();
                    ct.MaDienThoai = Session["bookID"].ToString();
                    ct.TenTaiKhoan = Session["userID"].ToString();
                    Models.CTGIOHANG ct2 = db.CTGIOHANGs.Find(ct.MaDienThoai, ct.TenTaiKhoan);
                    if (ct2 != null)
                    {
                        ct2.SoLuongGioHang += short.Parse(soLuong.ToString());
                        db.Entry(ct2).State = EntityState.Modified;
                    }
                    else
                    {
                        ct2 = new Models.CTGIOHANG();
                        ct2.MaDienThoai = ct.MaDienThoai;
                        ct2.TenTaiKhoan = ct.TenTaiKhoan;
                        ct2.SoLuongGioHang = short.Parse(soLuong.ToString());
                        db.CTGIOHANGs.Add(ct2);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["userID"] == null)
                return RedirectToAction("Login", "Login");
            using (var db = new Models.QLPhone())
            {
                ViewBag.DsSachDeal = db.DIENTHOAIs.Where(t => t.KHUYENMAI.NgayKetThuc > DateTime.Now && t.HienThiDT == true).Take(5).ToList();
                ViewBag.DsTL = db.HANGSANXUATs.ToList();
                List<Models.CTGIOHANG> ct = new List<Models.CTGIOHANG>();
                string temp = Session["userID"].ToString();


                var query = from gh in db.CTGIOHANGs
                            join s in db.DIENTHOAIs on gh.MaDienThoai equals s.MaDienThoai
                            where gh.TenTaiKhoan == temp
                            select new { s.HinhDienThoai, s.TenDienThoai, gh.SoLuongGioHang, s.MaDienThoai, s.MaKhuyenMai, s.GiaBan };

                List<Models.Temp.CTGIOHANGViewModel> ctgh = new List<Models.Temp.CTGIOHANGViewModel>();
                Models.KHUYENMAI km = new Models.KHUYENMAI();


                foreach (var item in query)
                {
                    Models.Temp.CTGIOHANGViewModel cttemp = new Models.Temp.CTGIOHANGViewModel();
                    cttemp.HinhDienThoai = item.HinhDienThoai;
                    cttemp.TenDienThoai = item.TenDienThoai;
                    cttemp.SoLuongGioHang = item.SoLuongGioHang;
                    cttemp.MaDienThoai = item.MaDienThoai;
                    using (var dbtemp = new Models.QLPhone())
                    {
                        km = dbtemp.KHUYENMAIs.Where(t => t.MaKhuyenMai == item.MaKhuyenMai).FirstOrDefault();
                        if (km != null)
                        {
                            cttemp.GiaBan = item.GiaBan * item.SoLuongGioHang * ((100 - km.PhanTramKhuyenMai) * 0.01);
                            cttemp.TietKiem = item.GiaBan * item.SoLuongGioHang * (km.PhanTramKhuyenMai * 0.01);
                        }
                        else
                        {
                            cttemp.GiaBan = item.GiaBan * item.SoLuongGioHang;
                            cttemp.TietKiem = item.GiaBan * item.SoLuongGioHang;
                        }
                    }
                    ctgh.Add(cttemp);
                }

                ViewBag.DsCTGH = ctgh;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Cart(string id)
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult DeleteItemCart()
        {
            string idDT = Request.QueryString["id"].ToString();
            if (Session["userID"] == null && Session["userID"].Equals(""))
            {
                return RedirectToAction("Login", "Login");
            }
            string idKhach = Session["userID"].ToString();
            using (var db = new Models.QLPhone())
            {
                var sql = from c in db.CTGIOHANGs
                          where c.MaDienThoai == idDT && c.TenTaiKhoan == idKhach
                          select c;

                var sql2 = sql.FirstOrDefault();
                db.Entry(sql2).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Cart", "Cart");
        }

    }
}