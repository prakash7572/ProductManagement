using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        DBConnection _db = new DBConnection();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            TempData["id"]= id;
            return View();
        }

        public ActionResult List()
        {
            try
            {
                List<Category> list = _db.Categorys.ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops list is not List!!!" + ex.Message);
            }

        }
        [HttpGet]
        public ActionResult GetId(int id)
        {
            try
            {
                Category category = _db.Categorys.Where(x => x.ID == id).FirstOrDefault();
                return Json(category, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops GetId is not Geted!!!" + ex.Message);
            }

        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return Json("Data Insert faild**");
                }
                else
                {
                    _db.Categorys.Add(category);
                    _db.SaveChanges();
                    return Json("Data Successfull Insert !!", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Oops Add is not Geted!!!" + ex.Message);
            }

        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return Json("Data Update faild !!");
                }
                else
                {
                    Category cate = _db.Categorys.Where(x => x.ID == category.ID).FirstOrDefault();
                    cate.CategoryName = category.CategoryName;
                    cate.Status = category.Status;
                    _db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return Json("Data Update Successfull !!", JsonRequestBehavior.AllowGet);
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
                Category category = _db.Categorys.Where(x => x.ID == id).FirstOrDefault();
                _db.Categorys.Remove(category);
                _db.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
                return Json("Data Remove Successfull !!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops Delete is not Geted!!!" + ex.Message);
            }
           
        }
        [HttpGet]
        public ActionResult CategoryDrop()
        {
            var categoryDrops = (from c in _db.Categorys
                                 select new CategoryDrop
                                 { ID = c.ID, CategoryName = c.CategoryName }).OrderBy(x => x.CategoryName).ToList();
            return Json(categoryDrops, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SubCategoryDrop()
        {
            var SubcategoryDrops = (from c in _db.SubCategorys select new SubCategoryDrop  { ID = c.ID, SubCategoryName = c.SubCategoryName }).ToList();
            
            return Json(SubcategoryDrops, JsonRequestBehavior.AllowGet);
        }
    }

}