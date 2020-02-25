using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemicalShopping.Models
{
    public class Company
    {
        /* describe a company
         * name
         * address
         * maybe promo code for company
         */
        [Key]
        public int CompanylID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string companyPromo { get; set; }

        //One Company to many Orders
        public ICollection<Order> Orders { get; set; }
    }
}