using System;
using System.Collections.Generic;
//add:
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemicalShopping.Data;
using ChemicalShopping.Models;
using ChemicalShopping.Models.ViewModels;
using System.Diagnostics;
using System.IO;

namespace ChemicalShopping.Controllers
{
    public class ChemicalController : Controller
    {
        // GET: Chemical
        public ActionResult Index()
        {
            return View();
        }

        private ChemicalShoppingContext db = new ChemicalShoppingContext();

        public ActionResult List(int id)
        {
            //degugging:
            Debug.WriteLine("List all categories");
            //category side: list all category:
            string cate_query = "SELECT * FROM Categories ";
            List<Category> listCategories = db.Categories.SqlQuery(cate_query).ToList();

            //chemical side: one category to many chemicals:
            //get selected category:
            string main_query = "SELECT * FROM Categories WHERE CategoryID = @id";
            var pk_parameter = new SqlParameter("@id", id);
            Category Category = db.Categories.SqlQuery(main_query, pk_parameter).FirstOrDefault();

            string che_query = "SELECT * FROM Chemicals INNER JOIN Categories ON Categories.CategoryID = Chemicals.CategoryID WHERE Chemicals.CategoryID = @id";
            var fk_parameter = new SqlParameter("@id", id);
            List<Chemical> chemicals = db.Chemicals.SqlQuery(che_query, fk_parameter).ToList();

            ShowCategory Viewmodel = new ShowCategory();
            Viewmodel.category = Category;
            Viewmodel.chemicals = chemicals;

            return View(Viewmodel);
        }

        public ActionResult New()
        {
            return View();
        }

        //show chemical:
        public ActionResult Show (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //what's this?
            }

            string main_query = "SELECT* FROM Chemicals WHERE ChemicalID = @id";
            var pk_parameter = new SqlParameter("@id", id);
            Chemical Chemical = db.Chemicals.SqlQuery(main_query, pk_parameter).FirstOrDefault();
            
            if (Chemical == null)
            {
                return HttpNotFound();
            }

            string cate_query = "SELECT * FROM Categories INNER JOIN Chemicals ON Categories.CategoryID = Chemicals.CategoryID WHERE Chemicals.CategoryID = @id";
            var capk_parameter = new SqlParameter("@id", id);
            Category Category = db.Categories.SqlQuery(cate_query, capk_parameter).FirstOrDefault();

            string ord_query = "SELECT * FROM Orders INNER JOIN OrderChemicals ON Orders.OrderID = OrderChemicals.Order_OrderID WHERE OrderChemicals.Chemical_ChemicalID = @id";
            var fk_parameter = new SqlParameter("@id" ,id);
            List<Order> OrderChemicals = db.Orders.SqlQuery(ord_query, fk_parameter).ToList();

            ShowChemical viewmodel = new ShowChemical();
            viewmodel.chemical = Chemical;
            viewmodel.category = Category;
            viewmodel.orders = OrderChemicals; 

            return View(viewmodel);
        }

        //update:
        public ActionResult Update(int id)
        {
            //selected chemical info:
            string main_query = "SELECT* FROM Chemicals WHERE ChemicalID = @id";
            var pk_parameter = new SqlParameter("@id", id);
            Chemical Chemical = db.Chemicals.SqlQuery(main_query, pk_parameter).FirstOrDefault();

            string cate_query = "SELECT * FROM Categories ";
            List<Category> listCategories = db.Categories.SqlQuery(cate_query).ToList();

            UpdateChemical viewmodel = new UpdateChemical();
            viewmodel.Chemical = Chemical;
            viewmodel.Category = listCategories;
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Update (int id, string ChemicalName, int CategoryID, string ProductCode, int Price, int MinOrder, string ProductDescription)
        {
            string query = "UPDATE Chemicals SET ChemicalName=@ChemicalName, CategoryID=@CategoryID, ProductCode=@ProductCode, Price=@Price, MinOrder=@MinOrder, ProductDescription=@ProductDescription WHERE ChemicalID=@id";
            SqlParameter[] sqlparams = new SqlParameter[7];
            sqlparams[0] = new SqlParameter("@ChemicalName", ChemicalName);
            sqlparams[1] = new SqlParameter("@CategoryID", CategoryID);
            sqlparams[2] = new SqlParameter("@ProductCode", ProductCode);
            sqlparams[3] = new SqlParameter("@Price", Price);
            sqlparams[4] = new SqlParameter("@MinOrder", MinOrder);
            sqlparams[5] = new SqlParameter("@ProductDescription", ProductDescription);
            sqlparams[6] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

    }
}