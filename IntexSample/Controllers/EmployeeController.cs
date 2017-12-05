using IntexSample.DAL;
using IntexSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntexSample.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Employee
        public ActionResult EmployeePortal()
        {
            //Redirect if not an employee

            string AccountName = Server.HtmlEncode(Request.Cookies["AccountName"].Value);

            //int accountnumber = (int)TempData["AccountID"];
            var oAccount = db.Database.SqlQuery<Accounts>("SELECT * from Accounts WHERE AccountName = '" + AccountName + "';").First();
            //string userType = db.Database.SqlQuery<User>("SELECT userType from Web_User WHERE userID = " + usernumber + ";").First().ToString();

            if (oAccount.AccountType == "employee")
            {
                return View();
            }
            else
            {
                return RedirectToAction("ClientPortal","Client");
            }
        }
    }
}