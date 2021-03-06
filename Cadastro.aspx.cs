using Business.Services;
using System;
using System.Web.UI;
using static PeGi.util.Mensagem;

namespace PeGi
{
    public partial class Cadastro : Page
    {
        readonly CadastroService cadastroService = new CadastroService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(primeiroNome.Value) || string.IsNullOrEmpty(sobrenomeUsuario.Value) || string.IsNullOrEmpty(emailUsuario.Value) || string.IsNullOrEmpty(username.Value) || string.IsNullOrEmpty(password.Value) || string.IsNullOrEmpty(confirmaPassword.Value))
            {
                ExibirMensagem(this, TipoMensagem.Erro, "Preencha todos os campos!");
                return;
            }

            string usuario = username.Value;
            string senha = password.Value;
            string confirmaSenha = confirmaPassword.Value;

            if (senha != confirmaSenha)
            {
                ExibirMensagem(this, TipoMensagem.Alerta, "Senhas informadas não compatíveis");
                return;
            }

            if (cadastroService.UsuarioJaExiste(usuario))
            {
                ExibirMensagem(this, TipoMensagem.Alerta, "Nome de usuário informado ja existe");
                return;
            }

            string nome = primeiroNome.Value;
            string sobrenome = sobrenomeUsuario.Value;
            string email = emailUsuario.Value;

            try
            {
                cadastroService.CadastrarNovoUsuario(nome, sobrenome, email, usuario, senha);
            }
            catch (Exception ex)
            {
                ExibirMensagem(this, TipoMensagem.Erro, $"Não foi possível cadastrar! Erro: {ex.Message}");
            }

            Response.Redirect("~/Login.aspx");
            
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        
    }
}