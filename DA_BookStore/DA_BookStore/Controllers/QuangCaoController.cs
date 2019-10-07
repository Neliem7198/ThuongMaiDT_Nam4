using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class QuangCaoController : Controller
    {

        //HIEN THI QUANG CAO
        [HttpGet]
        public ActionResult QuangCaoManage(int index = 0)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    List<Models.QUANGCAO> lst = db.QUANGCAOs.Where(t => t.HienThiQC == true).ToList();
                    ViewBag.DsQC = lst.Skip(15 * index).Take(15);
                }

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult QuangCaoManage(string maQC, int index)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    List<Models.QUANGCAO> lst = db.QUANGCAOs.Where(t => t.HienThiQC == true && t.TenQC.Contains(maQC)).ToList();
                    ViewBag.DsQC = lst.Skip(15 * index).Take(15);
                }

                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        //SUA QUANG CAO
        [HttpGet]
        public ActionResult QCDetail(string id = "")
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    Models.QUANGCAO qc = db.QUANGCAOs.Find(id);
                    ViewBag.QC = qc;
                    Session["quangcaoID"] = id;
                    ViewBag.DsTL = db.THELOAIs.ToList();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult QCUpdate(string tenQuangCao, HttpPostedFileBase hinhQuangCao, DateTime ngayBatDau, DateTime ngayHet, string chuSoHuuQuangCao, string sdtChuQuangCao, string emailChuQuangCao, string loaiQuangCao,string vitriQC)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {

                using (var db = new Models.BookStore())
                {
                    Models.QUANGCAO qc = db.QUANGCAOs.Find(Session["quangcaoID"]);
                    qc.TenQC = tenQuangCao;

                    //kiem tra ngay bat dau va ngay ket thuc 
                    int sosanhdate = DateTime.Compare(ngayBatDau, ngayHet);
                    if (sosanhdate == 0 || sosanhdate > 0)
                    {
                        return RedirectToAction("AddQuangCao", "QuangCao");
                    }
                    else
                    {
                        qc.NgayBatDauQC = ngayBatDau;
                        qc.NgayHetQC = ngayHet;
                    }

                    qc.ChuSoHuuQC = chuSoHuuQuangCao;
                    qc.EmailChuQC = emailChuQuangCao;
                    qc.LoaiQC = loaiQuangCao;
                    qc.SdtChuQC = sdtChuQuangCao;
                    if (vitriQC == "null")
                    {
                        qc.ViTriQuangCao = null;
                    }
                    else
                        qc.ViTriQuangCao = vitriQC;
                    if (hinhQuangCao != null)
                    {
                        try
                        {
                            string _path = "";
                            if (hinhQuangCao.ContentLength > 0)
                            {
                                string _fileName = System.IO.Path.GetFileName(hinhQuangCao.FileName);
                                _path = System.IO.Path.Combine(Server.MapPath("~/Image/QuangCao"), _fileName);
                                hinhQuangCao.SaveAs(_path);
                            }
                            qc.HinhQC = "Image/QuangCao/" + hinhQuangCao.FileName;
                        }
                        catch { }

                    }
                    db.Entry(qc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.QC = qc;
                }
                return RedirectToAction("QuangCaoManage");
            }

            return RedirectToAction("Index", "Home");
        }


        //XOA QUANG CAO
        public ActionResult QCDelete(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    Models.QUANGCAO qc = db.QUANGCAOs.Find(id);
                    qc.HienThiQC = false;
                    qc.ViTriQuangCao = null;
                    db.Entry(qc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("QuangCaoManage");
            }
            return RedirectToAction("Index", "Home");
        }

        //THEM QUANG CAO
        [HttpGet]
        public ActionResult AddQuangCao()
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
        public ActionResult AddQuangCao(string tenQC, HttpPostedFileBase hinhQC, DateTime ngayBatDauQC, DateTime ngayHetQC, string chuSoHuuQC, string sdtChuQC, string emailChuQC, string loaiQC, string vitriQuangCao)
        {

            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
               
                
                    using (var db = new Models.BookStore())
                    {
                        Models.QUANGCAO qc = new Models.QUANGCAO();

                        int slQC = db.QUANGCAOs.ToList().Count + 1;
                        var maQuangCao = "QC" + slQC.ToString().PadLeft(8, '0');

                        qc.MaQuangCao = maQuangCao;
                        qc.TenQC = tenQC.ToString();

                        qc.ChuSoHuuQC = chuSoHuuQC;
                        qc.SdtChuQC = sdtChuQC;
                        qc.EmailChuQC = emailChuQC;
                        qc.LoaiQC = loaiQC;

                        if (vitriQuangCao == "null")
                        {
                            qc.ViTriQuangCao = null;
                        }
                        else
                            qc.ViTriQuangCao = vitriQuangCao;

                         qc.HienThiQC = true;
                        //kiem tra ngay bat dau va ngay ket thuc 
                        int sosanhdate = DateTime.Compare(ngayBatDauQC, ngayHetQC);
                        if (sosanhdate == 0 || sosanhdate > 0)
                        {
                            return RedirectToAction("AddQuangCao");
                        }
                        else
                        {
                            qc.NgayBatDauQC = ngayBatDauQC;
                            qc.NgayHetQC = ngayHetQC;
                        }
                        if (hinhQC != null)
                        {
                            try
                            {
                                string _path = "";
                                if (hinhQC.ContentLength > 0)
                                {
                                    string _fileName = System.IO.Path.GetFileName(hinhQC.FileName);
                                    _path = System.IO.Path.Combine(Server.MapPath("~/Image/QuangCao"), _fileName);
                                    hinhQC.SaveAs(_path);
                                }
                                qc.HinhQC = "Image/QuangCao/" + hinhQC.FileName;
                            }
                            catch { }
                        }
                        db.QUANGCAOs.Add(qc);
                        db.SaveChanges();

                        return RedirectToAction("QuangCaoManage");
                    }
                
            }
            return RedirectToAction("Index","Home");
        }

        //GET BANNER
        public string getBanner()
        {
            using (var db = new Models.BookStore())
            {
                int count = db.QUANGCAOs.Where(i => i.ViTriQuangCao == "vitri0").Count();
                if (count > 0)
                {
                    Models.QUANGCAO banner = db.QUANGCAOs.Where(i => i.ViTriQuangCao == "vitri0").First();
                    return banner.HinhQC.ToString();
                }
                return "Image/banner.png";
            }
        }
    }
}