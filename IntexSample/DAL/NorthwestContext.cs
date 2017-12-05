using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntexSample.Models;
using System.Data.Entity;

namespace IntexSample.DAL
{
    public class NorthwestContext : DbContext
    {
        public NorthwestContext() : base("NorthwestContext")
        {

        }

        public DbSet<Accounts> Account { get; set; }

        public System.Data.Entity.DbSet<IntexSample.Models.CustomerAccount> CustomerAccounts { get; set; }
    }
}