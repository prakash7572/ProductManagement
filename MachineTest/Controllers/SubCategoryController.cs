using MachineTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MachineTest.Controllers
{
    [Authorize]
    public class SubCategoryController : Controller
    {
        DBConnection _db = new DBConnection();
        // GET: SubCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult List()
        {
            try
            {
                var joinQuery = from c in _db.Categorys
                                join sc in _db.SubCategorys on c.ID equals sc.CategoryName
                                select new
                                {
                                    ID = c.ID,
                                    CategoryName = c.CategoryName,
                                    SubCategoryName = sc.SubCategoryName,
                                    Status = sc.Status
                                };
                //return View(joinQuery.ToList());
                //List<SubCategory> subCategories = _db.SubCategorys.ToList();
                return Json(joinQuery, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops List is not Geted!!!" + ex.Message);

            }
        }
        [HttpGet]
        public ActionResult GetId(int id)
        {
            try
            {
                SubCategory subCategory = _db.SubCategorys.Where(x => x.ID == id).FirstOrDefault();
                return Json(subCategory, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops GetID is not Geted!!!" + ex.Message);
            }

        }

        [HttpPost]
        public ActionResult Add(SubCategory subCategory)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return Json("Data Insert Faild***", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _db.SubCategorys.Add(subCategory);
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
        public ActionResult Update(SubCategory subCategory)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return Json("Data Update Faild!!", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SubCategory sub = _db.SubCategorys.Where(x => x.ID == subCategory.ID).FirstOrDefault();
                    if (sub != null)
                    {
                        sub.CategoryName = subCategory.CategoryName;
                        sub.SubCategoryName = subCategory.SubCategoryName;
                        sub.Status = subCategory.Status;
                        _db.SubCategorys.Attach(sub);
                        _db.Entry(sub).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();
                        return Json("Data Update Successfull!!", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("Data Update failed!!", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw new Exception("Oops Add is not Geted!!!" + ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            try
            {
                SubCategory sub = _db.SubCategorys.Where(x => x.ID == id).FirstOrDefault();
                _db.SubCategorys.Remove(sub);
                _db.Entry(sub).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
                return Json("Data Remove Successfull!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception("Oops Remove is not Geted!!!" + ex.Message);
            }

        }

    }
}
