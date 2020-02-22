using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemicalShopping.Models.ViewModels
{
    public class UpdateChemical
    {
        //when update a Chemical, need a list of Category
        public Chemical Chemical { get; set; }
        public List<Category> Category { get; set; }
    }
}