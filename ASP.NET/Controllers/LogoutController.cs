using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}