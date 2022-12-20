using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Logado"] != null && Session["Logado"].ToString() == "OK")
            {
                return View();
            }
            
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}