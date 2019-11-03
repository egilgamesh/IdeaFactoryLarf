using Ideas_Factory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ideas_Factory.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Ideas_Factory.Models.loginuser userModel)
        {
            using (ideasFacctoryDBEntities db = new ideasFacctoryDBEntities())
            {
                var userDetails = db.loginusers.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.Id;
                    //Response.Cookies["userID"].Value = userDetails.Id.ToString();
                    Session["userName"] = userDetails.username;

                    HttpCookie UserCookies = new HttpCookie("userinfo");
                    UserCookies.Value = userDetails.Id.ToString();
                    UserCookies.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(UserCookies);

                    return RedirectToAction("Index", "Home");
                }
            }


        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
