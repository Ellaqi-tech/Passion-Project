using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemicalShopping.Models
{
    public class Order
    {
        /* 1. describe a order
         * 2. volume/quantity (Kg)
         * 3. total cost ($US)
         * 4. issue date
         * 5. promo code
         * 
         * A Order should reference:
         * 1. Chemicals
         * 2. CompanyID
         */
        [Key]
        public int OrderID { get; set; }
        public int Quantity { get; set; } //Kg
        public int Total { get; set; } //$US
        public DateTime IssueDate { get; set; }
        public string PromoCode { get; set; }

        //Many Chemical to many Orders
        public ICollection<Chemical> Chemicals { get; set; }

        //One Company to many Orders
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

    }

}