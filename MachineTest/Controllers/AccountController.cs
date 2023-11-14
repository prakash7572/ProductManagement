using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductManagement.Controllers
{
    public class AccountController : Controller
    {
        DBConnection _db = new DBConnection();
        public ActionResult Admin()
        {
            return View();  
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult LoginAuth(LoginVM model)
        {
            try
            {
                Profile login = _db.Profiles.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (login != null)
                {
                    FormsAuthentication.SetAuthCookie(login.Password, false);
                    return RedirectToAction("Admin", "Account");
                }
                else
                {
                    TempData["ERROR"] = "Invaild Email & Password!!!";
                    return View("Login", model);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult LogOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public ActionResult ChangePassword() {
        
        return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _db.Profiles.Where(x => x.Password == model.CurrentPassword).FirstOrDefault();

                    if (user != null && model.NewPassword == model.ConfirmPassword)
                    {
                        user.Password = model.NewPassword;
                        _db.Profiles.Attach(user);
                        _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("Login", "Account");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}