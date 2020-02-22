using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemicalShopping.Models.ViewModels
{
    public class ShowChemical
    {
        //individual chemical
        public virtual Chemical chemical { get; set; }
        public virtual Category category { get; set; }

        //multiple Orders
        public List<Order> orders { get; set; }

        //one category
        public List<Category> categories { get; set; }
    }
}