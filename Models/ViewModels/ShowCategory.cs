using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemicalShopping.Models.ViewModels
{
    public class ShowCategory
    {
        public virtual Category category { get; set; }
        //list all chemicals in this category:
        public List<Chemical> chemicals { get; set; }
    }
}