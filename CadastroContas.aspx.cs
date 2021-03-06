using Business.Services;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using PeGi.util;
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

            LblErroNomeConta.Visible = false;
            LblErroSaldo.Visible = false;
            LblErroSaldoNDecimal.Visible = false;
        }

        protected void BtnCadastrarConta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nomeConta.Value))
            {
                LblErroNomeConta.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(saldoConta.Value))
            {
                LblErroSaldo.Visible = true;
                return;
            }

            if (UsoGeral.CampoNaoDecimal(saldoConta.Value))
            {
                LblErroSaldoNDecimal.Visible = true;
                return;
            }


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
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao carregar as contas! Erro: {ex.Message}");
            }
        }

        protected void BtnAlterarConta_Command(object sender, CommandEventArgs e)
        {
            // PEGANDO O IDCONTA PARA ALTERAÇÃO
            HiddenFieldIdConta.Value = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "myModal", ";$(function() {openModalAlteraConta();});", true);
        }

        protected void BtnConfirmaAlteraConta_Click(object sender, EventArgs e)
        {
            int idConta = int.Parse(HiddenFieldIdConta.Value);
            string nomeConta = ModalAlteraNomeConta.Value;
            int idTipoConta = int.Parse(DDLModalAlteraTipoConta.SelectedValue);

            try
            {
                contasService.AlterarConta(idConta, nomeConta, idTipoConta);
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao alterar a conta! Erro: {ex.Message}");
            }

            PreencheGridContas();
        }

        protected void BtnDeletarConta_Command(object sender, CommandEventArgs e)
        {
            // PEGANDO O IDCONTA PARA ALTERAÇÃO
            HiddenFieldModalExcluirConta.Value = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "myModal", ";$(function() {openModalExcluirConta();});", true);
        }

        protected void BtnConfirmaExclusaoConta_Click(object sender, EventArgs e)
        {
            int idConta = int.Parse(HiddenFieldModalExcluirConta.Value);
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            try
            {
                contasService.DeletarConta(idConta, idUsuario);
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao excluir a conta! Erro: {ex.Message}");
            }

            PreencheGridContas();
        }
    }
}