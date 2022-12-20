using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVendas.Models.Login
{
    public class Sha1
    {
        public static string Criptografar(string senha)
        {
            var senhaCriptografada = string.Empty;
            var senhaBytes = System.Text.Encoding.UTF8.GetBytes(senha);
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var senhaCriptografadaBytes = sha1.ComputeHash(senhaBytes);
            senhaCriptografada = Convert.ToBase64String(senhaCriptografadaBytes);
            return senhaCriptografada;
        }
    }
}