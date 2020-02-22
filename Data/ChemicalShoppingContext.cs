using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChemicalShopping.Data
{
    public class ChemicalShoppingContext : DbContext //what this for?
    {
        public ChemicalShoppingContext() : base("name=ChemicalShoppingContext") //?
        {
        }
        public System.Data.Entity.DbSet<ChemicalShopping.Models.Chemical> Chemicals { get; set; }
        public System.Data.Entity.DbSet<ChemicalShopping.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<ChemicalShopping.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<ChemicalShopping.Models.Company> Companies { get; set; }
    }
}