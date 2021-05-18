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
        }

        private void PreencheGridContas()
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            List<Conta> lstContas = contasService.ExibirContas(idUsuario);
        }
    }
}