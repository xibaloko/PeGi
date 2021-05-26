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
    public partial class Receitas : Page
    {
        readonly ReceitasService receitasService = new ReceitasService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDDListContas();
                TxtBoxData.Value = DateTime.Now.ToString("yyyy-MM-dd");
                CarregarGridLancamentos();
            }
        }

        private void CarregarGridLancamentos()
        {
            int idConta = int.Parse(DDLContaSelecionada.SelectedValue);
            List<Lancamento> lstLancamentos = receitasService.ExibirLancamentos(idConta);

            try
            {
                GvLancamentosReceitas.DataSource = lstLancamentos;
                GvLancamentosReceitas.DataBind();
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao carregar os lançamentos! Erro: {ex.Message}");
            }

            if (lstLancamentos.Count == 0)
                lblTotalReceitas.Visible = false;
            else
            {
                lblTotalReceitas.Visible = true;
                decimal totalReceitas = lstLancamentos.Sum(x => x.Valor);
                lblTotalReceitas.Text = $"Total Receitas: R$ {totalReceitas}";
            }
            
        }

        private void CarregaDDListContas()
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            List<DDListConta> lstContas = receitasService.CarregaListaContas(idUsuario);

            DDLContaSelecionada.DataValueField = "IdConta";
            DDLContaSelecionada.DataTextField = "NomeConta";
            DDLContaSelecionada.DataSource = lstContas;
            DDLContaSelecionada.DataBind();
        }

        protected void DDLContaSelecionada_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarGridLancamentos();
        }

        protected void BtnLancarReceita_Click(object sender, EventArgs e)
        {
            int idConta = int.Parse(DDLContaSelecionada.SelectedValue);
            string descricao = TxtBoxDescricao.Value;
            string valor = TxtBoxValor.Value;
            string datalancamento = TxtBoxData.Value;

            try
            {
                receitasService.LancarReceita(idConta, descricao, valor, datalancamento);
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
            ScriptManager.RegisterStartupScript(this, GetType(), "myModal", ";$(function() {openModalDeletarLancRec();});", true);
        }

        protected void BtnConfirmaExclusaoLanc_Click(object sender, EventArgs e)
        {
            int idLancamento = int.Parse(HiddenFieldModalExcluirLanc.Value);

            try
            {
                receitasService.ExcluirLancamento(idLancamento);
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao excluir o lançamento! Erro: {ex.Message}");
            }

            CarregarGridLancamentos();
        }

        
    }
}