using IntexSample.DAL;
using IntexSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IntexSample.Controllers
{
    public class HomeController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        //GET: Home
        public ActionResult Login()
        {
            ViewBag.errorMessage = "";
            return View();
        }

        //POST: Home
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            var oAccount = db.Database.SqlQuery<Accounts>
            ("SELECT * FROM [Accounts] WHERE AccountName COLLATE Latin1_General_CS_AS = '" + username + "' AND " +
            "AccountPassword COLLATE Latin1_General_CS_AS = '" + password + "'").SingleOrDefault();

            if (oAccount != null)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);

                TempData["myObject"] = oAccount;
                TempData["AccountID"] = oAccount.AccountID;

                Response.Cookies["AccountName"].Value = oAccount.AccountName;
                Response.Cookies["AccountName"].Expires = DateTime.Now.AddHours(1);

                return RedirectToAction("EmployeePortal", "Employee");
            }
            else
            {
                //error message or reduce login count
                ViewBag.errorMessage = "INVALID USERNAME OR PASSWORD";
                return View();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}