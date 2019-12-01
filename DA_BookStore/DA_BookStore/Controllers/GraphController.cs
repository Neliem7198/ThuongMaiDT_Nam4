using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    //public class GraphController : Controller
    //{
    //    public ActionResult Index()
    //    {
    //        if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
    //        {
    //            using (var db = new Models.QLPhone())
    //            {
    //                ViewBag.DsSach = db.DIENTHOAIs.ToList();
    //                ViewBag.DsTL = db.HANGSANXUATs.ToList();
    //            }
    //            return View();
    //        }
    //        return RedirectToAction("Index", "Home");
    //    }
    //    [HttpGet]
    //    public string GraphPromo(int day = 30)
    //    {
    //        if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
    //        {
    //            using (var db = new Models.QLPhone())
    //            {
    //                List<Models.Temp.PromoView> listPromo = new List<Models.Temp.PromoView>();
    //                DateTime timeUp = DateTime.Now.AddDays(day);
    //                DateTime timeDown = DateTime.Now.AddDays(-day);

    //                db.KHUYENMAIs.Where(t => t.NgayKetThuc < timeUp && t.NgayBatDau > timeDown).ToList()
    //                        .ForEach(t => listPromo
    //                                        .Add(new Models.Temp.PromoView(t.TenKhuyenMai, t.NgayBatDau, t.NgayKetThuc, t.PhanTramKhuyenMai ?? 0)));

    //                var grpPromo = new Models.Temp.Group { group = "Khuyến mãi", data = listPromo };
    //                var listGrp = new List<Models.Temp.Group>() { grpPromo };

    //                return JsonConvert.SerializeObject(listGrp);

    //            }
    //        }
    //        return ":)";
    //    }
    //    [HttpGet]
    //    public string GraphHistory(int day = 30)
    //    {
    //        if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
    //        {
    //            using (var db = new Models.QLPhone())
    //            {
    //                Dictionary<string, double> dctCT = new Dictionary<string, double>();
    //                var minDay = DateTime.Now.AddDays(-day);

    //                var query = from ctxem in db.CTXEMs
    //                            join s in db.DIENTHOAIs on ctxem.MaDienThoai equals s.MaDienThoai
    //                            where ctxem.NgayXem >= minDay
    //                            select new { s.TenDienThoai, s.SoLuongTon, s.MaDienThoai };

    //                foreach (var item in query)
    //                {
    //                    if (!dctCT.Keys.Contains(item.MaDienThoai + " " + item.TenDienThoai + " (" + item.SoLuongTon + ")"))
    //                        dctCT.Add(item.MaDienThoai + " " + item.TenDienThoai + " (" + item.SoLuongTon + ")", 1);
    //                    else
    //                        dctCT[item.MaDienThoai + " " + item.TenDienThoai + " (" + item.SoLuongTon + ")"] += 1;
    //                }

    //                var test = new Models.Temp.HistoryView();

    //                foreach (var item in dctCT)
    //                {
    //                    var text = item.Key.Split(' ').ToArray();
    //                    var sl = text[text.Count() - 1];
    //                    var id = text[0];
    //                    var name = item.Key.Replace(" " + sl, "")
    //                                        .Replace(id + " ", " ");
    //                    sl = sl.Replace("(", "").Replace(")", "");
    //                    test.children.Add(new Models.Temp.HistoryView.temp(name, item.Value, int.Parse(sl), id));
    //                }
    //                test.children.Sort();

    //                return JsonConvert.SerializeObject(test);
    //            }
    //        }
    //        return ":)";
    //    }
    //    [HttpGet]
    //    public string GraphGroupDataCustomer()
    //    {
    //        if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
    //        {
    //            using (var db = new Models.QLPhone())
    //            {
    //                // get customer and total bill
    //                var cus = db.HOADONMUAHANGs.GroupBy(t => t.TenTaiKhoan)
    //                    .Select(t => new
    //                    {
    //                        TenTK = t.Select(g => g.TenTaiKhoan).FirstOrDefault(),
    //                        TongTien = t.Sum(g => g.TongTien)
    //                    }).OrderBy(t => t.TongTien).ToList();

    //                // group customer via total bill
    //                Dictionary<string, int> grp1 = new Dictionary<string, int>(); // below 200k
    //                Dictionary<string, int> grp2 = new Dictionary<string, int>(); // 200k - 1.000k
    //                Dictionary<string, int> grp3 = new Dictionary<string, int>(); // > 1.000k
    //                foreach (var item in cus)
    //                {
    //                    if (item.TongTien >= 1000000)
    //                        grp3.Add(item.TenTK, item.TongTien ?? -1);
    //                    else if (item.TongTien >= 200000)
    //                        grp2.Add(item.TenTK, item.TongTien ?? -1);
    //                    else
    //                        grp1.Add(item.TenTK, item.TongTien ?? -1);
    //                }
    //                List<object> test = new List<object>() { grp1, grp2, grp3 };

    //                //get list book per group customer
    //                var lstTemp = db.CTHOADONMUAHANGs.Where(t => grp1.Keys.Contains(t.HOADONMUAHANG.TenTaiKhoan))
    //                    .Select(t => new { TL1 = t.DIENTHOAI.MaHangSanXuat}).ToList();
    //                Dictionary<string, int> lst1 = new Dictionary<string, int>();
    //                foreach (var item in lstTemp)
    //                {
    //                    if (item.TL1 != null)
    //                    {
    //                        if (lst1.Keys.Contains(item.TL1))
    //                            lst1[item.TL1] += 1;
    //                        else
    //                            lst1.Add(item.TL1, 1);
    //                    }
    //                    //if (item.TL2 != null)
    //                    //{
    //                    //    if (lst1.Keys.Contains(item.TL2))
    //                    //        lst1[item.TL2] += 1;
    //                    //    else
    //                    //        lst1.Add(item.TL2, 1);
    //                    //}
    //                    //if (item.TL3 != null)
    //                    //{
    //                    //    if (lst1.Keys.Contains(item.TL3))
    //                    //        lst1[item.TL3] += 1;
    //                    //    else
    //                    //        lst1.Add(item.TL3, 1);
    //                    //}
    //                }

    //                lstTemp = db.CTHOADONMUAHANGs.Where(t => grp2.Keys.Contains(t.HOADONMUAHANG.TenTaiKhoan))
    //                   .Select(t => new { TL1 = t.DIENTHOAI.MaHangSanXuat}).ToList();
    //                Dictionary<string, int> lst2 = new Dictionary<string, int>();
    //                foreach (var item in lstTemp)
    //                {
    //                    if (item.TL1 != null)
    //                    {
    //                        if (lst2.Keys.Contains(item.TL1))
    //                            lst2[item.TL1] += 1;
    //                        else
    //                            lst2.Add(item.TL1, 1);
    //                    }
    //                    //if (item.TL2 != null)
    //                    //{
    //                    //    if (lst2.Keys.Contains(item.TL2))
    //                    //        lst2[item.TL2] += 1;
    //                    //    else
    //                    //        lst2.Add(item.TL2, 1);
    //                    //}
    //                    //if (item.TL3 != null)
    //                    //{
    //                    //    if (lst2.Keys.Contains(item.TL3))
    //                    //        lst2[item.TL3] += 1;
    //                    //    else
    //                    //        lst2.Add(item.TL3, 1);
    //                    //}
    //                }

    //                lstTemp = db.CTHOADONMUAHANGs.Where(t => grp3.Keys.Contains(t.HOADONMUAHANG.TenTaiKhoan))
    //                                    .Select(t => new { TL1 = t.DIENTHOAI.MaHangSanXuat}).ToList();
    //                Dictionary<string, int> lst3 = new Dictionary<string, int>();
    //                foreach (var item in lstTemp)
    //                {
    //                    if (item.TL1 != null)
    //                    {
    //                        if (lst3.Keys.Contains(item.TL1))
    //                            lst3[item.TL1] += 1;
    //                        else
    //                            lst3.Add(item.TL1, 1);
    //                    }
    //                    //if (item.TL2 != null)
    //                    //{
    //                    //    if (lst3.Keys.Contains(item.TL2))
    //                    //        lst3[item.TL2] += 1;
    //                    //    else
    //                    //        lst3.Add(item.TL2, 1);
    //                    //}
    //                    //if (item.TL3 != null)
    //                    //{
    //                    //    if (lst3.Keys.Contains(item.TL3))
    //                    //        lst3[item.TL3] += 1;
    //                    //    else
    //                    //        lst3.Add(item.TL3, 1);
    //                    //}
    //                }

    //                List<Dictionary<string, int>> grpListTheLoaiXem = new List<Dictionary<string, int>>() { lst1, lst2, lst3 };
    //                List<Models.Temp.GroupCusView> test2 = new List<Models.Temp.GroupCusView>();
    //                List<Models.HANGSANXUAT> dsTL = db.HANGSANXUATs.ToList();
    //                foreach (var item in grpListTheLoaiXem)
    //                {
    //                    foreach (var t in item)
    //                    {
    //                        foreach (var tl in dsTL)
    //                        {
    //                            if (tl.MaHangSanXuat == t.Key)
    //                            {
    //                                test2.Add(new Models.Temp.GroupCusView("Group " + (grpListTheLoaiXem.IndexOf(item) + 1), tl.TenHangSanXuat, t.Value));
    //                                break;
    //                            }
    //                        }

    //                    }
    //                }

    //                return JsonConvert.SerializeObject(test2);
    //            }
    //        }
    //        return ":)";
    //    }
    //    [HttpGet]
    //    public string GraphGroupBill()
    //    {
    //        if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
    //        {
    //            using (var db = new Models.QLPhone())
    //            {
    //                DateTime dateStart = new DateTime(DateTime.Now.Year, 1, 1);

    //                var lstHD = db.HOADONMUAHANGs.Where(t => t.ThoiGianMua > dateStart)
    //                    .Select(t => new { t.TinhTrangThanhToan, t.ThoiGianMua }).ToList();

    //                List<int> lstMonth = new List<int>();
    //                List<Models.Temp.BillView> lst = new List<Models.Temp.BillView>();


    //                foreach (var hd in lstHD)
    //                {
    //                    if (!lstMonth.Contains(hd.ThoiGianMua.Value.Month))
    //                    {
    //                        lstMonth.Add(hd.ThoiGianMua.Value.Month);
    //                        lst.Add(new Models.Temp.BillView(hd.ThoiGianMua.Value.Month, hd.TinhTrangThanhToan));
    //                    }
    //                    else
    //                    {
    //                        foreach (var a in lst)
    //                        {
    //                            if (a.month == hd.ThoiGianMua.Value.Month)
    //                            {
    //                                a.addValue(hd.TinhTrangThanhToan);
    //                                break;
    //                            }
    //                        }
    //                    }
    //                }
    //                lst.Sort();
    //                return JsonConvert.SerializeObject(lst);
    //            }
    //        }
    //        return ":)";
    //    }

    //}
}