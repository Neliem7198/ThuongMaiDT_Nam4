using DA_BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.UI;
using System.Xml.Linq;

namespace DA_BookStore.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public  ActionResult Payment()
        {
            if (Session["userID"] != null)
            {
                using (var db = new QLPhone())
                {
                    ViewBag.DsSachDeal = db.DIENTHOAIs.Where(t => t.KHUYENMAI.NgayKetThuc > DateTime.Now && t.HienThiDT == true).Take(5).ToList();
                    ViewBag.DsTL = db.DIENTHOAIs.ToList();

                    string temp = Session["userID"].ToString();

                    var query = from gh in db.CTGIOHANGs
                                join s in db.DIENTHOAIs on gh.MaDienThoai equals s.MaDienThoai
                                where gh.TenTaiKhoan == temp
                                select new {gh.SoLuongGioHang, s.MaDienThoai, s.MaKhuyenMai, s.GiaBan };

                    KHUYENMAI km = new KHUYENMAI();
                    double? tamTinh = 0;

                    foreach (var item in query)
                    {
                        km = db.KHUYENMAIs.Where(t => t.MaKhuyenMai == item.MaKhuyenMai).FirstOrDefault();
                        tamTinh += item.GiaBan * item.SoLuongGioHang * ((100 - km.PhanTramKhuyenMai) * 0.01);
                    }

                    ViewBag.TamTinh = string.Format("{0:0,0}", tamTinh);
                    ViewBag.ThanhTien = string.Format("{0:0,0}", tamTinh);

                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public string Payment(string name, string address, string phonenumber, string email, string note, string codePromote)
        {
            ViewBag.HoTen = name;
            ViewBag.DiaChi = address;
            ViewBag.SDT = phonenumber;
            ViewBag.Email = email;
            ViewBag.Note = note;
            int? a = 0;

            string tenTaiKhoan = Session["userID"].ToString();

            using (var db = new QLPhone())
            {
                var sql = from c in db.CTGIOHANGs
                          where c.TenTaiKhoan == tenTaiKhoan
                          select c;

                List<CTGIOHANG> cartTemp = sql.ToList();

                bool flag = false;
                foreach (var item in cartTemp)
                {
                    var sachTemp = db.DIENTHOAIs.Find(item.MaDienThoai);
                    string message = '"' + sachTemp.TenDienThoai + '"' + " hiện tại trong kho chỉ còn: " + sachTemp.SoLuongTon;

                    if ((sachTemp.SoLuongTon -= item.SoLuongGioHang) < 0)
                    {
                        flag = true;
                        //Response.Write(@"<script language='javascript'>alert('" + message + "');</script>");
                        Response.Write(@"<script language='javascript'>if (confirm('"+ message +"')){window.location = 'https://localhost:44379/Cart/Cart'; }</script>");
                    }
                }

                if (flag == false)
                {
                    var countSL = (from c in db.HOADONMUAHANGs select c.MaHDMua).ToList();
                    HOADONMUAHANG hd = new HOADONMUAHANG();
                    hd.MaHDMua = "HD" + countSL.Count;
                    hd.ThoiGianMua = DateTime.Now;
                    hd.TenTaiKhoan = tenTaiKhoan;
                    hd.TinhTrangThanhToan = "Chua";

                    if (codePromote != null)
                    {
                        hd.CODE = codePromote;
                    }
                    db.HOADONMUAHANGs.Add(hd);


                    int? tongTien = 0;
                    foreach (var item in cartTemp)
                    {
                       var sachTemp = db.DIENTHOAIs.Find(item.MaDienThoai);
                        sachTemp.SoLuongTon -= item.SoLuongGioHang;

                        CTHOADONMUAHANG ctHD = new CTHOADONMUAHANG();
                        ctHD.MaDienThoai = item.MaDienThoai;
                        ctHD.MaHDMua = hd.MaHDMua;
                        ctHD.SoLuongMua = item.SoLuongGioHang;
                        ctHD.GiaHienHanh = item.SoLuongGioHang * sachTemp.GiaBan;
                        tongTien += ctHD.GiaHienHanh;
                        db.CTHOADONMUAHANGs.Add(ctHD);
                    }

                    var queryCode = db.PROMOCODEs.Find(codePromote);
                    var hdmua = db.HOADONMUAHANGs.Find(hd.MaHDMua);
                    hdmua.TongTien = tongTien - queryCode.SoTienGiam;
                    a = hdmua.TongTien;
                    foreach (var item in sql)
                    {
                        var ctgh = db.CTGIOHANGs.Find(item.MaDienThoai,item.TenTaiKhoan);
                        db.Entry(ctgh).State = EntityState.Deleted;
                    }
                    
                    db.SaveChanges();
                }

            }

            return name +" Đã hoang phí "+a+"₫";
        }
    }
}