using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//add
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using ChemicalShopping.Data;
using ChemicalShopping.Models;
using ChemicalShopping.Models.ViewModels;
using System.Diagnostics;
using System.IO;

namespace ChemicalShopping.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        private ChemicalShoppingContext db = new ChemicalShoppingContext();
        public ActionResult List()
        {
            //degugging:
            Debug.WriteLine("List all categories");
            //category side: list all category:
            string cate_query = "SELECT * FROM Categories";
            List<Category> listCategories = db.Categories.SqlQuery(cate_query).ToList();

            return View(listCategories);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string CateName)
        {
            string query = "INSERT INTO Categories (CategoryName) values (@CateName)";
            var parameter = new SqlParameter("@CateName", CateName);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }

        //update:
        public ActionResult Update (int id)
        {
            string query = "SELECT * FROM Categories WHERE CategoryID = @id";
            var parameter = new SqlParameter("@id", id);
            Category selectedcategory = db.Categories.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedcategory);
        }
        [HttpPost]
        public ActionResult Update (int id, string CateName)
        {
            string query = "UPDATE Categories SET CategoryName = @CateName WHERE CategoryID = @id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@CateName", CateName);
            sqlparams[1] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

        //delete:
        public ActionResult Deletecomfirm(int id)
        {
            string query = "SELECT * FROM Categories WHERE CategoryID = @id";
            var parameter = new SqlParameter("@id", id);
            Category selectedcategory = db.Categories.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedcategory);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "DELETE FROM Categories WHERE CategoryID = @id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            string refrequery = "UPDATE Chemicals SET CategoryID = '' WHERE CategoryID = @id";
            db.Database.ExecuteSqlCommand(refrequery, param);
            return RedirectToAction("List");
        }
        //show:
        public ActionResult Show(int id)
        {
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
    }
}