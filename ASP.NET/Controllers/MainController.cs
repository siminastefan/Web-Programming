using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Assignment9.DataAbstractionLayer;
using Assignment9.Models;

namespace Assignment9.Controllers
{
    public class MainController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return GetUsers();
        }

        public string TestController()
        {
            return "Testing the MainController .. OK!";
        }

        public ActionResult GetUsers()
        {
            UserDal userDal = new UserDal();
            List<User> users = userDal.GetAllUsers();
            ViewData["users"] = users;
            return View("ViewGetUsers");
        }

        public ActionResult HomePage()
        {
            if (Session["UserID"] != null)
                return View();
            return RedirectToAction("Login", "Login");
        }

        public string GetRecipes()
        {
            RecipeDal recipeDal = new RecipeDal();
            List<Recipe> recipes = recipeDal.GetAllRecipes();
            ViewData["recipes"] = recipes;

            string result = "<table><thead><th>ID</th><th>Author</th><th>Name</th><th>Type</th><th>Description</th></thead>";

            foreach (Recipe recipe in recipes)
            {
                result += "<tr>" +
                          "<td>" + recipe.Id + "</td>" +
                          "<td>" + recipe.Author + "</td>" +
                          "<td>" + recipe.Name + "</td>" +
                          "<td>" + recipe.Type + "</td>" +
                          "<td>" + recipe.Description + "</td>" +
                          "</tr>";
            }

            result += "</table>";
            return result;
        }

        public string FilterRecipesByType()
        {
            string type = Request.Params["type"];
            
            RecipeDal recipeDal = new RecipeDal();
            List<Recipe> recipes = recipeDal.GetAllRecipesByType(type);
            ViewData["recipes"] = recipes;

            string result = "<table><thead><th>ID</th><th>Author</th><th>Name</th><th>Type</th><th>Description</th></thead>";

            foreach (Recipe recipe in recipes)
            {
                result += "<tr>" +
                          "<td>" + recipe.Id + "</td>" +
                          "<td>" + recipe.Author + "</td>" +
                          "<td>" + recipe.Name + "</td>" +
                          "<td>" + recipe.Type + "</td>" +
                          "<td>" + recipe.Description + "</td>" +
                          "</tr>";
            }

            result += "</table>";
            return result;
        }

        public ActionResult AddRecipe()
        {
            return View("AddNewRecipe");
        }

        public ActionResult SaveRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.Author = Request.Params["author"];
            recipe.Name = Request.Params["name"];
            recipe.Type = Request.Params["type"];
            recipe.Description = Request.Params["description"];
            
            RecipeDal recipeDal = new RecipeDal();
            recipeDal.SaveRecipe(recipe);
            return RedirectToAction("AddRecipe");
        }

        public ActionResult DeleteRecipe()
        {
            return View("DeleteRecipe");
        }

        public ActionResult RemoveRecipe()
        {
            RecipeDal recipeDal = new RecipeDal();
            recipeDal.DeleteRecipe(Int32.Parse(Request.Params["id"]));
            return RedirectToAction("DeleteRecipe");
        }

        public ActionResult UpdateRecipe()
        {
            return View("UpdateRecipe");
        }

        public ActionResult ChangeRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.Id = Int32.Parse(Request.Params["id"]);
            recipe.Author = Request.Params["author"];
            recipe.Name = Request.Params["name"];
            recipe.Type = Request.Params["type"];
            recipe.Description = Request.Params["description"];
            
            RecipeDal recipeDal = new RecipeDal();
            recipeDal.UpdateRecipe(recipe);
            return RedirectToAction("UpdateRecipe");
        }
    }
}