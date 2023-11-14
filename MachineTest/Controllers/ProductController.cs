using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        DBConnection _db = new DBConnection();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View();
        }
       
        [HttpGet]
        public ActionResult List()
        {
            try
            {
                //List<Product> products = _db.Products.ToList();
                var joinQuery = from p in _db.Products
                                join c in _db.Categorys on p.CategoryName equals c.ID
                                join s in _db.SubCategorys on p.SubCategoryName equals s.ID
                                select new
                                {
                                    ID = p.ID,
                                    CategoryName = c.CategoryName,
                                    SubCategoryName = s.SubCategoryName,
                                    ProductName = p.ProductName,
                                    ShorDescription = p.ShorDescription,
                                    FullDescription = p.FullDescription,
                                    Status = p.Status
                                };

                // Pass the joined result to the view
                //return View(joinQuery.ToList());

                return Json(joinQuery.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception("Oops list is not Geted!!!" +ex.Message);
            }
          
        }
        
        [HttpGet]
        public ActionResult GetId(int id)
        {
            try
            {
                Product product = _db.Products.Where(x => x.ID == id).FirstOrDefault();
                return Json(product, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception("Oops GetId is not Geted!!!" + ex.Message);
            }
          
        }
        
        [HttpPost]
        public ActionResult Add(Product product)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return Json("Data Insert Faild!!");
                }
                else
                {
                    _db.Products.Add(product);
                    _db.SaveChanges();
                    return Json("Data Insert Successfull!!", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Oops Add is not Geted!!!" + ex.Message);
            }
          
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return Json("Data Update Faild!!");
                }
                else
                {
                    Product pro = _db.Products.Where(x => x.ID == product.ID).FirstOrDefault();
                    pro.CategoryName = product.CategoryName;
                    pro.SubCategoryName = product.SubCategoryName;
                    pro.ProductName = product.ProductName;
                    pro.Status = product.Status;
                    _db.Products.Attach(pro);
                    _db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return Json("Data Update Successfull!!!", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Oops Update is not Geted!!!" + ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Product product = _db.Products.Where(x => x.ID == id).FirstOrDefault();
                _db.Products.Remove(product);
                _db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
                return Json("Data Remove Successfull!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops Deleted is not Geted!!!" + ex.Message);
            }
           
        }
    }
}