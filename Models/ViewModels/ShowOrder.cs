using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemicalShopping.Models.ViewModels
{
    public class ShowOrder
    {
        //one individual order
        public virtual Order order { get; set; }
        // a list of companies have orders
        public List<Company> companies { get; set; }

        //ADD Chemical to an Oreder (Dropdown list)
        public List<Chemical> all_chemicals { get; set; }
    }
}