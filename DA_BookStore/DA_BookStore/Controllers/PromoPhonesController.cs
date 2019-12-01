using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class PromoPhonesController : Controller
    {
        // GET: PromoPhones
        public ActionResult Index()
        {
            using (var db = new Models.QLPhone())
            {
                ViewBag.DsSachDeal = db.DIENTHOAIs.Where(t => t.KHUYENMAI.NgayKetThuc > DateTime.Now && t.HienThiDT == true).Take(5).ToList();
                ViewBag.DsTL = db.HANGSANXUATs.ToList();
                ViewBag.DsQC = db.QUANGCAOs.ToList();
            }

            return View();
        }
    }
}