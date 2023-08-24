using CheckBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CheckBox.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db= new LoginDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["User"];
            if(cookie != null)
            {
                ViewBag.Username = cookie["Username"].ToString();
                ViewBag.Password = cookie["Password"].ToString();
            }
            else
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            HttpCookie cookie = new HttpCookie("User");
            if (ModelState.IsValid==true)
            {
                if(u.Remeberme ==true )
                {
                    
                    cookie["Username"] = u.Username;
                    cookie["Password"]=u.Password;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Request.Cookies.Add(cookie); 
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Request.Cookies.Add(cookie);
                }

            var raw = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
                if (raw != null)
                {
                    Session["username"] = u.Username;
                    TempData["Message"] = "<script>alert('Login SuccessFully')</script>";
                    return RedirectToAction("Index","Dashboard");

                }
                else
                {
                    TempData["Message"] = "<script>alert('Login Failed')</script>";
                }
            }
            return View();
        }
    }
}