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
                ViewBag.Id_Usuario = Request.Cookies["inf_user"]["Id_Usuario"];
                ViewBag.NomeUsuario = Request.Cookies["inf_user"]["NomeUsuario"];
                ViewBag.Email = Request.Cookies["inf_user"]["Email"];
                ViewBag.Bloqueio = Request.Cookies["inf_user"]["Bloqueio"];
                ViewBag.FK_Grupo = Request.Cookies["inf_user"]["FK_Grupo"];
                ViewBag.Dt_Criacao = Request.Cookies["inf_user"]["Dt_Criacao"];
                ViewBag.Dt_AlteracaoSenha = Request.Cookies["inf_user"]["Dt_AlteracaoSenha"];
                ViewBag.Dt_Bloqueio = Request.Cookies["inf_user"]["Dt_Bloqueio"];
                
                return View();
            }
            
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}