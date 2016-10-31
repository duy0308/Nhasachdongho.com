using DevExpress.Web.Mvc;
using Models.EF;
using NHASACHDONGHO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ADMINSITE.Controllers
{
    [XAdmin]
    public class HomeController : dbController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Slide()
        {
            ViewBag.Sildes = db.M1Slide.ToList();
            return View();
        }
        //THÊM MỚI SLIDES
        [HttpPost]
        public ActionResult Slide([Bind(Include = "ID,Image,DisplayOrder,Link,Description")] M1Slide m1Slide)
        {
            if (ModelState.IsValid)
            {
                db.M1Slide.Add(m1Slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Slide","Home");
        }
        //XÓA SLIDES
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M1Slide m1Slide = db.M1Slide.Find(id);
            if (m1Slide == null)
            {
                return HttpNotFound();
            }

            db.M1Slide.Remove(m1Slide);
            db.SaveChanges();

            return Json(m1Slide, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            var model = db.M1About.Find(1);
            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult About(M1About model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("About");
            }
            return View(model);
        }
        public ActionResult Footer()
        {
            var model = db.M1Footer.Find(1);
            return View(model);
        }
      
        [HttpPost, ValidateInput(false)]
        public ActionResult Footer(M1Footer model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Footer");
            }
            return View(model);
        }
        public ActionResult Logo()
        {
            ViewBag.Logo = db.M1SystemConfig.Find(1).Value;
            ViewBag.LogoMobi = db.M1SystemConfig.Find(2).Value;
            return View();
        }
        [HttpPost]
        public ActionResult Logo(string logo, string logomobi)
        {
            var model1 = db.M1SystemConfig.Find(1);
            var model2 = db.M1SystemConfig.Find(2);
            if (ModelState.IsValid)
            {
                model1.Value = logo; 
                db.Entry(model1).State = EntityState.Modified;
                db.SaveChanges();
                /*********************************/
                model2.Value = logomobi;
                db.Entry(model2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Logo");
            }
            return View();
        }
        public ActionResult Dongbo()
        {

            return View();
        }
        public ActionResult DongboSoluongGiaban()
        {
            DataNhasachModel dbNhasach = new DataNhasachModel();
            DataContextModel dbM1Shop = new DataContextModel();
            /**********************************************************************************************/
            //THỰC HIỆN ĐỒNG BỘ CÁC MẶT HÀNG
            /**********************************************************************************************/
            var Mathang = dbNhasach.MATHANGs.Select(s=>s.MHCODE).ToList();
            int SoSP = 0;
            foreach (var p in Mathang)
            {
                var MHCODE = p;//LẤY MÃ CODE SẢN PHẨM TRONG PHẦN MỀM
                var Sodong = dbM1Shop.M1Product.Where(x => x.Code == MHCODE).Count();//KIỂM TRA XEM TRÊN WEB CÓ CHƯA
                if (Sodong > 0)//NẾU CHƯA CÓ THÌ THÊM MỚI
                {
                    var mathangSoft = dbNhasach.MATHANGs.Single(x => x.MHCODE == p);
                    int Sanpham_SL = (int)mathangSoft.SOLUONG;
                    /**********************************************************/
                    M1Product Pros = dbM1Shop.M1Product.Single(x => x.Code == p);
                    Pros.Price = mathangSoft.GIABANLE ?? 0;
                    Pros.Quantity = Sanpham_SL;
                    dbM1Shop.SaveChanges();
                    SoSP++;
                }
            }
            ViewBag.Soluong = SoSP;
            return View();
        }
        public ActionResult Mathang()
        {
            DataNhasachModel dbNhasach = new DataNhasachModel();
            DataContextModel dbM1Shop = new DataContextModel();
            /**********************************************************************************************/
            //THỰC HIỆN ĐỒNG BỘ CÁC MẶT HÀNG
            /**********************************************************************************************/
            var Mathang = dbNhasach.MATHANGs.ToList();
            int SoSP = 0;
            foreach (var p in Mathang)
                {
                    var MHCODE = p.MHCODE;//LẤY MÃ CODE SẢN PHẨM TRONG PHẦN MỀM
                    var Sodong = dbM1Shop.M1Product.Where(x => x.Code == MHCODE).Count();//KIỂM TRA XEM TRÊN WEB CÓ CHƯA
                    if (Sodong == 0)//NẾU CHƯA CÓ THÌ THÊM MỚI
                    {
                        //XỬ LÝ SỐ LƯỢNG SẢN PHẨM TRUYỀN VÀO
                        int Sanpham_SL = 0;
                        try { Sanpham_SL = int.Parse(p.SOLUONG.ToString()); }
                        catch { Sanpham_SL = 0; }
                        //XỬ LÝ CHUYỂN ĐỔI ACTIVE
                        var trangthai = false;
                            if (p.Actives != null && p.Actives != 0) trangthai = true;
                            else trangthai = false;

                        var ShowHome = false;
                            if (p.Home != null && p.Home != 0) ShowHome = true;
                            else ShowHome = false;
                    //KHAI BÁO VÀO THÊM MỚI MẶT HÀNG
                    #region 
                    /**********************************************************/
                    M1Product Pros = new M1Product
                    {
                        Name = p.mhName,
                        Code = p.MHCODE,
                        NameWEB = p.mhName,
                        SeoTitle = XulyChuoi.Xoadau(p.mhName + ""),
                        MetaTitle = p.mhName,
                        Description = p.CAUHINH,
                        MetaKeywords = p.mhName,
                        MetaDescriptions = p.Details,
                        Image = p.images,
                        Price = p.GIABANLE ?? 0,
                        PromotionPrice = 0,
                        IncludedVAT = false,
                        Quantity = Sanpham_SL,
                        CategoryID = p.MHLID,
                        SupplierID = 1,
                        Detail = p.Details,
                        CreatedDate = p.CREATED,
                        CreatedBy = p.USERID,
                        ModifiedDate = p.UPDATED,
                        ModifiedBy = p.USERID,
                        Status = trangthai,
                        Showhome = ShowHome,
                        Is_special = false,
                        ViewCount = p.views ?? 0,
                        Discount = 0,
                        Warranty = 0,
                        TopHot = DateTime.Now,
                        Tags = null
                        };
                        #endregion
                        dbM1Shop.M1Product.Add(Pros);
                        SoSP++;
                    }
                }
                dbM1Shop.SaveChanges();
                ViewBag.Soluong = SoSP;
            return View();
        }
        public ActionResult MathangLoai()
        {
            DataNhasachModel dbNhasach = new DataNhasachModel();
            DataContextModel dbM1Shop = new DataContextModel();
            /**********************************************************************************************/
            //THỰC HIỆN ĐỒNG BỘ LOẠI MẶT HÀNG
            /**********************************************************************************************/
            #region
            //LẤY TẤT CẢ MẶT HÀNG CÓ ACTIVE KHÁC 0
            var LoaiMathang = dbNhasach.MATHANGLOAIs.ToList();
            int sodong = LoaiMathang.Count();
            //DUYET QUA TAT LOAI MAT HANG
            int i = 0;
            foreach (var item in LoaiMathang)
            {
                //Lấy ID MATHANGLOAI
                int idMHL = int.Parse(item.ID.ToString());
                var SoluongCate = dbM1Shop.M1ProductCategory.Where(x => x.ID == idMHL).Count();
                //Kiểm tra có Loại mặt hàng này chưa, không có thì thêm mới vào
                if (SoluongCate <= 0)
                {
                    bool Kichhoat = false;
                    if (item.Activate != 0 && item.Activate != null) Kichhoat = true;
                    else Kichhoat = false;
                    bool ShowTrangchu = false;
                    if (item.home != 0 && item.home != null) ShowTrangchu = true;
                    else ShowTrangchu = false;
                    /*****************************************************/
                    M1ProductCategory Category = new M1ProductCategory
                    {
                        ID = item.ID,
                        ParentID = item.PARENTID,
                        Name = item.MHLTEN,
                        NameWEB = item.TenWeb,
                        Image = null,
                        DisplayOrder = item.Postion,
                        Level = item.LEVEL,
                        Code = item.MHLCODE,
                        SeoTitle = XulyChuoi.Xoadau(item.TenWeb + ""),
                        MetaTitle = item.TenWeb,
                        MetaKeywords = item.TenWeb,
                        MetaDescriptions = item.TenWeb,
                        Status = Kichhoat,
                        ShowOnHome = ShowTrangchu,
                        CreatedDate = item.CREATED,
                        CreatedBy = item.USERID,
                        ModifiedDate = item.UPDATED,
                        ModifiedBy = item.USERID,
                        Descriptions = item.MOTA,
                        Note = item.GHICHU,
                        Path = item.PATH,
                        Tags = null,
                    };
                    dbM1Shop.M1ProductCategory.Add(Category);//THÊM MỚI
                    i++;
                }
            }
            dbM1Shop.SaveChanges();
            ViewBag.Soluong = i;
            #endregion
            return View();
        }
    }
    
}
public enum HeaderViewRenderMode { Full, Title }