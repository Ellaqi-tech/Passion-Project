using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemicalShopping.Models
{
    public class Category
    {
        /* describe a category
         * name
         */
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //One Category to many Chemicals
        public ICollection<Chemical> Chemicals { get; set; }

    }
}