using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntexSample.DAL;
using IntexSample.Models;

namespace IntexSample.Controllers
{
    public class CustomerAccountsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();
        static string personType = "client";

        // GET: CustomerAccounts
        public ActionResult Index(string AccountType)
        {
            if (AccountType == "client")
            {
                IEnumerable<Accounts> container = db.Database.SqlQuery<Accounts>("SELECT * FROM Accounts WHERE AccountType = 'client'");
                return View(container.ToList());
            }
            else
            {
                return View(db.CustomerAccounts.ToList());
            }
        }

        // GET: CustomerAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccount customerAccount = db.CustomerAccounts.Find(id);
            if (customerAccount == null)
            {
                return HttpNotFound();
            }
            return View(customerAccount);
        }

        // GET: CustomerAccounts/Create
        public ActionResult Create(string AccountType)
        {
            if (AccountType == "employee")
            {
                personType = "employee";
            }

            return View();
        }

        // POST: CustomerAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerID,accountID,AccountName,AccountPassword,AccountType,custFirstName,custLastName,custAddress,custCity,custState,custZip,custAreaCode,custPhoneNumber,custBalanceDue")] CustomerAccount c)
        {
            if (ModelState.IsValid)
            {
                var oPerson = db.Database.SqlQuery<Accounts>("SELECT * FROM Accounts WHERE accountID = (SELECT MAX(accountID) FROM Accounts);").First();
                c.accountID = oPerson.accountID + 1;
                db.Database.ExecuteSqlCommand("INSERT INTO Accounts (accountName,accountPassword,accountType) VALUES ('"+ c.AccountName +"','"+ c.AccountPassword +"','client')");
                db.Database.ExecuteSqlCommand("INSERT INTO Customer (custFirstName,custLastName,custAddress,custCity,custState,custZIP,custPhoneNumber,accountID,creditID,custBalanceDue) VALUES ('" + c.custFirstName + "','" + c.custLastName + "','"+ c.custAddress +"','"+ c.custCity +"','"+ c.custState +"','"+ c.custZip +"','"+ c.custPhoneNumber +"','"+ c.accountID +"',0,0)");

                return RedirectToAction("Index","Home");
            }

            return View(c);
        }

        // GET: CustomerAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccount customerAccount = db.CustomerAccounts.Find(id);
            if (customerAccount == null)
            {
                return HttpNotFound();
            }
            return View(customerAccount);
        }

        // POST: CustomerAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerID,accountID,AccountName,AccountPassword,AccountType,custFirstName,custLastName,custAddress,custCity,custState,custZip,custAreaCode,custPhoneNumber,custBalanceDue")] CustomerAccount customerAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerAccount);
        }

        // GET: CustomerAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAccount customerAccount = db.CustomerAccounts.Find(id);
            if (customerAccount == null)
            {
                return HttpNotFound();
            }
            return View(customerAccount);
        }

        // POST: CustomerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerAccount customerAccount = db.CustomerAccounts.Find(id);
            db.CustomerAccounts.Remove(customerAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
