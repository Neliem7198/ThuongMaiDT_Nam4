using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string id, string matKhau)
        {
            if (id == string.Empty || matKhau == string.Empty)
            {
                if (id == string.Empty)
                    ViewBag.TenKHError = "Vui lòng nhập tên tài khoản";
                if (matKhau == string.Empty)

                    ViewBag.MatKhauError = "Vui lòng nhập Mật khẩu";
                return View("Login");
            }
            else if (id != string.Empty && matKhau != string.Empty)
            {
                using (var db = new Models.QLPhone())
                {
                    var tk = db.TAIKHOANs.Where(i => i.TenTaiKhoan == id && i.MauKhau == matKhau).FirstOrDefault();
                    if (tk == null || tk.HienThiTK == false)
                    {
                        ViewBag.AccError = "Thông tin không đúng";
                        return View("Login");
                    }
                    else
                    {
                        Session["userID"] = tk.TenTaiKhoan.ToString();
                        Session["userName"] = tk.HoTen.ToString();
                        Models.NHANVIEN nv = db.NHANVIENs.Find(tk.TenTaiKhoan.ToString());
                        if (nv != null && nv.HienThiNV == true)
                        {
                            Session["userPrio"] = nv.ChucVuNV;
                            if(nv.ChucVuNV == "Admin")
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        //Get: DangKy
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult SignUp(string id, string pass, string ten, string email, string sdt, bool? sex, string rePass, string diaChi )
        {
            using (var db = new Models.QLPhone())
            {

                var temp = db.TAIKHOANs.Find(id);
                if (temp == null)
                {
                    if (rePass != pass)
                    {
                        ViewBag.RePassError = "Mật khẩu không trùng khớp";
                        return View("SignUp");
                    }

                    var temp2 = db.TAIKHOANs.Find(sdt);
                    bool t = Regex.IsMatch(sdt, @"[0][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]");
                    if (t == false)
                    {
                        ViewBag.PhoneError = "Chỉ nhập số từ 0-9 và số điện thoại phù hợp";
                        return View("SignUp");
                    }

                    if (IsValid(email) == false)
                    {
                        ViewBag.MailError = "Nhập đúng định đạng ***@gmal.com";
                        return View("SignUp");
                    }

                    var temp1 = db.TAIKHOANs.Find(email);
                    //if (temp1 == null)
                    //{
                    //    ViewBag.MailError = "Mail đã được sử dụng";
                    //    return View("SignUp");
                    //}

                    db.TAIKHOANs.Add(new Models.TAIKHOAN() { TenTaiKhoan = id, MauKhau = pass, Email = email, Sdt = sdt, DiaChi = diaChi, GioiTinh = sex, HoTen = ten , HienThiTK= true , Point = 0});
                    db.SaveChanges();
                    db.Dispose();

                }
                else
                {
                    ViewBag.AccEx = "Tài khoản đã được sử dụng";
                    return View("SignUp");
                }
            }
            return RedirectToAction("Login", "Login");
        }

        
    }
}