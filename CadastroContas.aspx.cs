using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeGi.util;
using System.Globalization;
using Business.Models;

namespace PeGi
{
    public partial class CadastroContas : Page
    {
        readonly ContasService contasService = new ContasService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheGridContas();
            }
        }

        protected void BtnCadastrarConta_Click(object sender, EventArgs e)
        {
            string conta = nomeConta.Value;
            string saldo = saldoConta.Value;
            int tipoConta = int.Parse(DDLTipoConta.SelectedValue);
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            try
            {
                contasService.CriarConta(conta, saldo, idUsuario, tipoConta);
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao criar uma nova conta! Erro: {ex.Message}");
            }

            Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Sucesso, $"A conta: {conta} foi cadastrada com sucesso!");
            
            nomeConta.Value = string.Empty;
            saldoConta.Value = string.Empty;
            DDLTipoConta.SelectedValue = "1";

            PreencheGridContas();
        }

        private void PreencheGridContas()
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            try
            {
                List<Conta> lstContas = contasService.ExibirContas(idUsuario);
                GvContas.DataSource = lstContas;
                GvContas.DataBind();
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Sucesso, $"Ocorreu um erro ao carregar as contas! Erro: {ex.Message}");
            }
        }

        protected void BtnAlterarConta_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Modal", "openModal();", true);
        }

        protected void BtnDeletarConta_Command(object sender, CommandEventArgs e)
        {

        }
    }
}