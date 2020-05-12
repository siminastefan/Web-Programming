using System.Web.Mvc;
using Assignment9.DataAbstractionLayer;
using Assignment9.Models;

namespace Assignment9.Controllers
{
    public class LoginController : Controller
    {
        // GET
        
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                string username = Request.Params["username"];
                string password = Request.Params["password"];
                var userDal = new UserDal();
                var obj = userDal.GetUser(username, password);
                if (obj != null)
                {
                    Session["UserID"] = obj.Id.ToString();
                    Session["Username"] = obj.Username;
                    return RedirectToAction("HomePage", "Main");
                }
            }

            return View();
        }
    }
}