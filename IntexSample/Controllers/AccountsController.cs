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
    public class AccountsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();
        static string personType = "client";

        // GET: Accounts
        public ActionResult Index(string AccountType)
        {
            if (AccountType == "client")
            {
                IEnumerable<Accounts> container = db.Database.SqlQuery<Accounts>("SELECT * FROM Accounts WHERE AccountType = 'client'");
                return View(container.ToList());
            }
            else
            {
                return View(db.Account.ToList());
            }
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Account.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // GET: Accounts/Create
        public ActionResult Create(string AccountType)
        {
            if(AccountType == "employee")
            {
                personType = "employee";
            }
            
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,AccountName,AccountPassword,AccountType")] Accounts accounts)
        {
            accounts.AccountType = personType;
            personType = "client";

            var oPerson = db.Database.SqlQuery<Accounts>("SELECT * FROM Accounts WHERE accountID = (SELECT MAX(accountID) FROM Accounts);").First();
            accounts.accountID = oPerson.accountID + 1;
            if (ModelState.IsValid)
            {
                //db.Database.ExecuteSqlCommand("INSERT INTO Accounts('accountID','accountName','accountPassword','accountType') VALUES("+ accounts.accountID +",'"+ accounts.AccountName +"','"+ accounts.AccountPassword +"','"+ accounts.AccountType +"')");
                db.Database.ExecuteSqlCommand("INSERT INTO Customer (custFirstName,custLastName,custAddress,custCity,custState,custZIP,custAreaCode,custPhoneNumber,accountID,creditID,salesRepID,custBalanceDue) VALUES ('" +  +','')");

                return RedirectToAction("Index","Home");
            }

            return View(accounts);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Account.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,AccountName,AccountPassword,AccountType")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accounts);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Account.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounts accounts = db.Account.Find(id);
            db.Account.Remove(accounts);
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
