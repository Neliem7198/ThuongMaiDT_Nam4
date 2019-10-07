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
            using (var db = new Models.BookStore())
            {
                List<Models.SACH> lst = new List<Models.SACH>();
                if (!tl)
                {
                    lst = db.SACHes.Where(t => t.TenSach.Contains(search) && t.HienThiS == true).ToList();
                }
                else
                {
                    lst = db.SACHes.Where(t => t.MaTL1 == search || t.MaTL2 == search || t.MaTL3 == search).ToList();
                    ViewBag.TenTL = db.THELOAIs.Find(search).TenTheLoai;
                }

                ViewBag.SoLuong = lst.Count;
                ViewBag.DsSach = lst.Skip(12 * ((index == 0) ? 0 : index - 1)).Take(12);
                ViewBag.DsTL = db.THELOAIs.ToList();
            }

            ViewBag.TenSach = search;
            ViewBag.Index = index;
            return View();
        }
    }
}