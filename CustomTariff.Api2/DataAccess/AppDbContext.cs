using CustomTariff.Api2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomTariff.Api2.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(ConfigurationManager.AppSettings["DbConnection"])
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<TariffClass> TariffClass { get; set; }

        public DbSet<ProductN> ProductN { get; set; }

        public DbSet<ProductTariff> ProductTariff { get; set; }
    }
}