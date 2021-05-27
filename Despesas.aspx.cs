using Business.Models;
using Business.Services;
using PeGi.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeGi
{
    public partial class Despesas : Page
    {
        readonly DespesasService despesasService = new DespesasService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDDListContas();
                TxtBoxData.Value = DateTime.Now.ToString("yyyy-MM-dd");
                CarregarGridLancamentos();
            }

            LblErroDescricao.Visible = false;
            LblErroData.Visible = false;
            LblErroSaldo.Visible = false;
            LblErroSaldoNDecimal.Visible = false;
        }

        private void CarregaDDListContas()
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            List<DDListConta> lstContas = despesasService.CarregaListaContas(idUsuario);

            DDLContaSelecionada.DataValueField = "IdConta";
            DDLContaSelecionada.DataTextField = "NomeConta";
            DDLContaSelecionada.DataSource = lstContas;
            DDLContaSelecionada.DataBind();
        }

        private void CarregarGridLancamentos()
        {
            int idConta = int.Parse(DDLContaSelecionada.SelectedValue);
            List<Lancamento> lstLancamentos = despesasService.ExibirLancamentos(idConta);

            try
            {
                GvLancamentosDespesas.DataSource = lstLancamentos;
                GvLancamentosDespesas.DataBind();
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao carregar os lançamentos! Erro: {ex.Message}");
            }

            if (lstLancamentos.Count == 0)
                lblTotalDespesas.Visible = false;
            else
            {
                lblTotalDespesas.Visible = true;
                decimal totalDespesas = lstLancamentos.Sum(x => x.Valor);
                lblTotalDespesas.Text = $"Total Despesas: R$ {totalDespesas}";
            }
        }

        protected void DDLContaSelecionada_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGridLancamentos();
        }

        protected void BtnLancarDespesa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxDescricao.Value))
            {
                LblErroDescricao.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(TxtBoxData.Value))
            {
                LblErroData.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(TxtBoxValor.Value))
            {
                LblErroSaldo.Visible = true;
                return;
            }

            if (UsoGeral.CampoNaoDecimal(TxtBoxValor.Value))
            {
                LblErroSaldoNDecimal.Visible = true;
                return;
            }

            int idConta = int.Parse(DDLContaSelecionada.SelectedValue);
            string descricao = TxtBoxDescricao.Value;
            string valor = TxtBoxValor.Value;
            string datalancamento = TxtBoxData.Value;

            try
            {
                despesasService.LancarDespesa(idConta, descricao, valor, datalancamento);
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao carregar fazer o lançamento! Erro: {ex.Message}");
            }

            TxtBoxDescricao.Value = string.Empty;
            TxtBoxValor.Value = string.Empty;

            CarregarGridLancamentos();
        }

        protected void BtnDeletarLancamento_Command(object sender, CommandEventArgs e)
        {
            HiddenFieldModalExcluirLanc.Value = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "myModal", ";$(function() {openModalDeletarLancDes();});", true);
        }

        protected void BtnConfirmaExclusaoLanc_Click(object sender, EventArgs e)
        {
            int idLancamento = int.Parse(HiddenFieldModalExcluirLanc.Value);

            try
            {
                despesasService.ExcluirLancamento(idLancamento);
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao excluir o lançamento! Erro: {ex.Message}");
            }

            CarregarGridLancamentos();
        }
    }
}