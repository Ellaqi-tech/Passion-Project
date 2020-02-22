using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemicalShopping.Models.ViewModels
{
    public class ListCategories
    {
        public List<Category> listCategories { get; set; }
        //public Category SelectedCategory { get; set; }
        public List<Chemical> chemicals { get; set; }
    }
}