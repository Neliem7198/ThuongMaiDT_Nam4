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
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();

                    Session["bookID"] = id;

                    ViewBag.id = id;
                    Models.DIENTHOAI s = db.DIENTHOAIs.Where(t => t.MaDienThoai == id).FirstOrDefault();

                    ViewBag.DienThoai = s;

                    if (s.HienThiDT == false)
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
                        db.CTXEMs.Add(new Models.CTXEM() { MaDienThoai = id, TenTaiKhoan = Session["userID"].ToString(), NgayXem = DateTime.Now });
                        db.SaveChanges();
                    }
                    s.SoLanTruyCap += 1;
                    db.SaveChanges();
                }
            }
            catch { }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBookDetail(string tenDienThoai, string manHinh, string cameraSau, string cameraTruoc, string hdh, string cpu, string giaBan, string gioiThieuDienThoai, string tl1, string soLuongTon, HttpPostedFileBase hinh)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    Models.DIENTHOAI dt = db.DIENTHOAIs.Find(Session["bookID"]);
                    dt.TenDienThoai = tenDienThoai;
                    dt.ManHinh = manHinh;
                    dt.CameraSau = cameraSau;
                    dt.CameraTruoc = cameraTruoc;
                    dt.HeDieuHanh = hdh;
                    dt.CPU = cpu;
                    dt.GiaBan = int.Parse(giaBan);
                    dt.GioiThieuDienThoai = gioiThieuDienThoai;

                    dt.SoLuongTon = int.Parse(soLuongTon);

                    dt.MaHangSanXuat = (tl1 == "null") ? null : tl1;
                   

                    if (hinh != null)
                    {
                        try
                        {
                            string _path = "";
                            if (hinh.ContentLength > 0)
                            {
                                string _fileName = System.IO.Path.GetFileName(hinh.FileName);
                                _path = System.IO.Path.Combine(Server.MapPath("~/Image/ "), _fileName);
                                hinh.SaveAs(_path);
                            }

                            dt.HinhDienThoai = "Image/DienThoai/" + hinh.FileName;
                        }
                        catch
                        {

                        }
                    }

                    db.Entry(dt).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                Session["bookEdit"] = null;
                return RedirectToAction("Detail", "Book", new { id = Session["BookID"].ToString() });
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
                using (var db = new Models.QLPhone())
                {
                    Models.DIENTHOAI s = db.DIENTHOAIs.Find(id);
                    s.HienThiDT = false;
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
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                    List<Models.DIENTHOAI> lst = db.DIENTHOAIs.Where(t => t.HienThiDT == true).ToList();
                    ViewBag.DsDT = lst.Skip(15 * index).Take(15);
                    ViewBag.slDT = lst.Count();
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
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                    List<Models.DIENTHOAI> lst = db.DIENTHOAIs.Where(t => t.HienThiDT == true && t.TenDienThoai.Contains(id)).ToList();
                    ViewBag.DsDT = lst.Skip(15 * index).Take(15);
                    ViewBag.slDT = lst.Count();
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
                using (var db = new Models.QLPhone())
                {
                    ViewBag.DsTL = db.HANGSANXUATs.ToList();
                }

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult AddBook(string tenDienThoai, string manHinh, string cameraSau, string cameraTruoc, string hdh, string cpu, string giaBan, string gioiThieuDienThoai, string tl1, string soLuongTon, HttpPostedFileBase hinh)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.QLPhone())
                {
                    Models.DIENTHOAI dt = new Models.DIENTHOAI();
                    int slDT = db.DIENTHOAIs.ToList().Count() + 1;

                    var maDT = "DT" + slDT.ToString().PadLeft(8, '0');

                    dt.MaDienThoai = maDT;
                    dt.TenDienThoai = tenDienThoai;
                    dt.ManHinh = manHinh;
                    dt.CameraSau = cameraSau;
                    dt.CameraTruoc = cameraTruoc;
                    dt.HeDieuHanh = hdh;
                   
                    dt.CPU = cpu;
                    dt.GiaBan = int.Parse(giaBan);
                    dt.SoLanTruyCap = 0;
                    dt.GioiThieuDienThoai = gioiThieuDienThoai;
                    dt.SoLuongTon = int.Parse(soLuongTon);
                    dt.NgayPhatHanh = DateTime.Today;
                    dt.MaHangSanXuat = tl1;
                    dt.HienThiDT = true;
                   
                    if (hinh != null)
                    {
                        try
                        {
                            string _path = "";
                            if (hinh.ContentLength > 0)
                            {
                                string _fileName = System.IO.Path.GetFileName(hinh.FileName);
                                _path = System.IO.Path.Combine(Server.MapPath("~/Image/DienThoai"), _fileName);
                                hinh.SaveAs(_path);
                            }
                            dt.HinhDienThoai = "Image/DienThoai/" + hinh.FileName;
                        }
                        catch {}
                    }
                    db.DIENTHOAIs.Add(dt);
                    db.SaveChanges();

                    return RedirectToAction("Detail", "Book", new { id = maDT });
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}