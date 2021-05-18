using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PeGi.util
{
    public class SessaoUsuario
    {
        public static void CriarSessao(Page page, Usuario user) => page.Session["UsuarioLogado"] = user;

        public static Usuario RecuperarSessao(Page page) => (Usuario)page.Session["UsuarioLogado"];

        public static void LogoutUsuario(Page page) => page.Session.Remove("UsuarioLogado");
    }
}