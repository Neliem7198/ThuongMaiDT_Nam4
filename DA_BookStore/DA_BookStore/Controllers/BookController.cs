using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Detail(string id)
        {
            if (Session["bookEdit"] != null && Session["bookID"].ToString() != id)
                Session["bookEdit"] = null;

            try
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();

                    Session["bookID"] = id;

                    ViewBag.id = id;
                    Models.SACH s = db.SACHes.Where(t => t.MaSach == id).FirstOrDefault();

                    ViewBag.Sach = s;

                    if (s.HienThiS == false)
                        return RedirectToAction("Index", "Home");

                    Models.KHUYENMAI km = db.KHUYENMAIs.Where(t => t.MaKhuyenMai == s.MaKhuyenMai).FirstOrDefault();
                    if (km != null)
                    {
                        ViewBag.KhuyenMai = km;

                        ViewBag.TietKiem = s.GiaBan * (km.PhanTramKhuyenMai * 0.01);
                        ViewBag.GiaBanHienTai = s.GiaBan * ((100 - km.PhanTramKhuyenMai) * 0.01);
                    }

                   
                    if (Session["userID"] != null)
                    {
                        db.CTXEMSACHes.Add(new Models.CTXEMSACH() { MaSach = id, TenTaiKhoan = Session["userID"].ToString(), NgayXemSach = DateTime.Now });
                        db.SaveChanges();
                    }
                    s.SoLanTruyCap += 1;
                    db.SaveChanges();
                }
            }
            catch {}
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBookDetail(string tenSach, string tacGia, string sku, string giaBan, string gioiThieuSach, string tl1, string tl2, string tl3, string soLuong, HttpPostedFileBase hinh )
        {
        	if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
	            using (var db = new Models.BookStore())
	            {
	                Models.SACH s = db.SACHes.Find(Session["bookID"]);
	                s.TenSach = tenSach;
	                s.TenTacGia = tacGia;
	                s.SKU = sku;
	                s.GiaBan = int.Parse(giaBan);
	                s.GioiThieuSach = gioiThieuSach;

                    s.SoLuongTon = int.Parse(soLuong);

                    s.MaTL1 = (tl1 == "null") ? null : tl1;
                    if (tl2 != tl1 || tl2 == null)
                        s.MaTL2 = (tl2 == "null")? null : tl2;
                    if ((tl3 != tl2 && tl3 != tl1) || tl3 == null)
                        s.MaTL3 = (tl3 == "null") ? null : tl3;

                    if (hinh != null)
	                {
                        try
                        {
                            string _path = "";
	                        if (hinh.ContentLength > 0)
	                        {
	                            string _fileName = System.IO.Path.GetFileName(hinh.FileName);
	                            _path = System.IO.Path.Combine(Server.MapPath("~/Image/Book"), _fileName);
	                            hinh.SaveAs(_path);
	                        }

	                        s.HinhSach = "Image/Book/" + hinh.FileName;
                        }
                        catch
                        {

                        }
                    }

	                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
	                db.SaveChanges();
	            }
	            Session["bookEdit"] = null;
	            return RedirectToAction("Detail","Book", new { id = Session["BookID"].ToString() });
	        }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult BookEdit(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                Session["bookEdit"] = "sua";
                return RedirectToAction("Detail", "Book", new { id = id });
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult BookDelete(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    Models.SACH s = db.SACHes.Find(id);
                    s.HienThiS = false;
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("BookManage", "Book");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult BookManage(int index = 0)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    List<Models.SACH> lst = db.SACHes.Where(t => t.HienThiS == true).ToList();
                    ViewBag.DsS = lst.Skip(15*index).Take(15);
                    ViewBag.slS = lst.Count();
                }

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult BookManage(string id, int index)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    List<Models.SACH> lst = db.SACHes.Where(t => t.HienThiS == true && t.TenSach.Contains(id)).ToList();
                    ViewBag.DsS = lst.Skip(15*index).Take(15);
                    ViewBag.slS = lst.Count();
                }

                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                }

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult AddBook(string tenSach, string tacGia, string sku, string giaBan, string gioiThieuSach, HttpPostedFileBase hinh, string tl1, string tl2, string tl3, string soLuong)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    Models.SACH s = new Models.SACH();
                    int slS = db.SACHes.ToList().Count() + 1;

                    var maSach = "S" + slS.ToString().PadLeft(9, '0');

                    s.MaSach = maSach;
                    s.TenSach = tenSach;
                    s.TenTacGia = tacGia;
                    s.SKU = sku;
                    s.GiaBan = int.Parse(giaBan);
                    s.GioiThieuSach = gioiThieuSach;
                    s.MaNhaXuatBan = "NXB0000001";
                    s.SoLanTruyCap = 0;
                    s.SoLuongTon = int.Parse(soLuong);
                    s.NgayXuatBan = DateTime.Today;

                    s.MaTL1 = tl1;
                    if (tl2 != tl1 && tl2 != "null")
                        s.MaTL2 = tl2;
                    if (tl3 != tl1 && tl3 != tl2 && tl3 != "null")
                        s.MaTL3 = tl3;

                    s.HienThiS = true;
                    if (hinh != null)
                    {
                        try
                        {
                            string _path = "";
                            if (hinh.ContentLength > 0)
                            {
                                string _fileName = System.IO.Path.GetFileName(hinh.FileName);
                                _path = System.IO.Path.Combine(Server.MapPath("~/Image/Book"), _fileName);
                                hinh.SaveAs(_path);
                            }
                            s.HinhSach = "Image/Book/" + hinh.FileName;
                        }
                        catch{}
                    }

                   
                    db.SACHes.Add(s);
                    db.SaveChanges();

                    return RedirectToAction("Detail", "Book", new { id = maSach });
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}