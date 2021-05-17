using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static PeGi.util.Mensagem;

namespace PeGi
{
    public partial class Login : Page
    {
        readonly LoginService loginService = new LoginService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void Logar()
        {
            if (string.IsNullOrEmpty(username.Value) || string.IsNullOrEmpty(senha.Value))
            {
                ExibirMensagem(this, TipoMensagem.Alerta, "Usuário ou Senha não informados!");
                username.Value = string.Empty;
                senha.Value = string.Empty;
                username.Focus();
                return;
            }
            else
            {
                if (loginService.ValidarUsuario(username.Value, senha.Value))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    ExibirMensagem(this, TipoMensagem.Alerta, "Usuário ou Senha inválido!");
                }
            }
        }
    }
}