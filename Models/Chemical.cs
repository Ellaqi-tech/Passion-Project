using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//install entity famework 6
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemicalShopping.Models
{
    public class Chemical
    {
        /* describe chemical
         * name
         * product description
         * categoty
         * product code
         * price ($US)
         * Min order(Kg)
         * 
         * must reference:
         *  category
         *  
         */
        [Key]
        public int ChemicalID { get; set; }
        public string ChemicalName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCode { get; set; }
        public int Price { get; set; } // $US/kg
        public int MinOrder { get; set; } // kg

        //One Category to many Chemicals
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        //One Order to many Chemicals
        public ICollection<Order> Orders { get; set; }

        //pictures:
        //Content/Pets/{id}.{PicExtension}
        public int ChemicalPic { get; set; }
        //.PicExtension:
        public string PicExtension { get; set; }

    }
}