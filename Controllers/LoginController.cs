using SistemaDeVendas.Models.Login;
using SistemaDeVendas.Models.Usuarios;
using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVendas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Erro"] != null)
                ViewBag.Erro = Session["Erro"].ToString();
            Response.Cookies["inf_user"].Expires = DateTime.Now.AddDays(-1);
            return View();
        }

        [HttpPost]
        public void ChecarLogin()
        {
            var usuario = new Usuarios();

            usuario.Email = Request["email"];
            usuario.Senha = Sha1.Criptografar(Request["password"]);

            Response.Cookies["inf_user"].Expires = DateTime.Now.AddDays(-1);

            if (usuario.Login())
            {
                Session["Logado"] = "OK";
                Session.Remove("Erro");

                HttpCookie cookie = Request.Cookies["inf_user"];
                if (cookie.Value == null)
                {
                    cookie = new HttpCookie("inf_user");
                    cookie.Path = "/";

                    cookie.Values.Add("Id_Usuario", usuario.Id_Usuario.ToString());
                    cookie.Values.Add("NomeUsuario", usuario.NomeUsuario.ToString());
                    cookie.Values.Add("Email", usuario.Email.ToString());
                    cookie.Values.Add("Bloqueio", usuario.Bloqueio.ToString());
                    cookie.Values.Add("FK_Grupo", usuario.FK_Grupo.ToString());
                    cookie.Values.Add("Dt_Criacao", usuario.Dt_Criacao.ToString());
                    cookie.Values.Add("Dt_AlteracaoSenha", usuario.Dt_AlteracaoSenha.ToString());
                    cookie.Values.Add("Dt_Bloqueio", usuario.Dt_Bloqueio.ToString());

                    cookie.Expires = DateTime.Now.AddMinutes(360d);
                    cookie.HttpOnly = true;

                    Response.Cookies.Add(cookie);

                    Response.Redirect(Url.Action("Index", "Home"));
                }

            }

        }

        public void ControleLogin(int? grupo)
        {
            switch (grupo)
            {
                case 1:
                    Response.Redirect(Url.Action("Index", "Home"));
                    break;
            }

        }
    }
}