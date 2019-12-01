using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string search, int index = 0, bool tl = false)
        {
            using (var db = new Models.QLPhone())
            {
                List<Models.DIENTHOAI> lst = new List<Models.DIENTHOAI>();
                if (!tl)
                {
                    lst = db.DIENTHOAIs.Where(t => t.TenDienThoai.Contains(search) && t.HienThiDT == true).ToList();
                }
                else
                {
                    lst = db.DIENTHOAIs.Where(t => t.MaHangSanXuat == search && t.HienThiDT == true /*|| t.MaTL2 == search || t.MaTL3 == search*/).ToList();
                    ViewBag.TenTL = db.HANGSANXUATs.Find(search).TenHangSanXuat;
                }

                ViewBag.SoLuong = lst.Count;
                ViewBag.DsSach = lst.Skip(12 * ((index == 0) ? 0 : index - 1)).Take(12);
                ViewBag.DsTL = db.HANGSANXUATs.ToList();
            }

            ViewBag.TenSach = search;
            ViewBag.Index = index;
            return View();
        }
    }
}