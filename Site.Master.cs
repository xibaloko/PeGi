using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeGi.util;

namespace PeGi
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = SessaoUsuario.RecuperarSessao(Page);

                BVUsuario.Text = $"Olá, {user.Nome}!";
            }
        }

        protected void BtnSairApp_Click(object sender, EventArgs e)
        {
            SessaoUsuario.LogoutUsuario(Page);

            Response.Redirect("~/Login.aspx");
        }
    }
}