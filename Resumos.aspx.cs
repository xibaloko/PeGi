using Business.Models;
using Business.Services;
using PeGi.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace PeGi
{
    public partial class Resumos : Page
    {
        readonly ResumoService resumoService = new ResumoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDDListContas();
                TxtBoxDataFim.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }

            LblErroDtInic.Visible = false;
            LblErroDtFim.Visible = false;
        }

        private void CarregaDDListContas()
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            List<DDListConta> lstContas = resumoService.CarregaListaContas(idUsuario);

            DDLContaSelecionada.DataValueField = "IdConta";
            DDLContaSelecionada.DataTextField = "NomeConta";
            DDLContaSelecionada.DataSource = lstContas;
            DDLContaSelecionada.DataBind();
        }

        protected void DDLContaSelecionada_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvResumo.DataSource = null;
            GvResumo.DataBind();

            lblResultado.Text = string.Empty;
            lblSaldoConta.Text = string.Empty;
        }

        protected void BtnPesquisarPorPeriodo_Click(object sender, EventArgs e)
        {
            string dataInicio = TxtBoxDataInic.Value;
            string dataFim = TxtBoxDataFim.Value;

            if (string.IsNullOrEmpty(dataInicio))
            {
                LblErroDtInic.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(dataFim))
            {
                LblErroDtFim.Visible = true;
                return;
            }

            ExibeResultado(dataInicio, dataFim);

            TxtBoxDataInic.Value = string.Empty;
            TxtBoxDataFim.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void BtnUltimos30_Click(object sender, EventArgs e)
        {
            string dataInicio = DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd");
            string dataFim = DateTime.Today.ToString("yyyy-MM-dd");

            ExibeResultado(dataInicio, dataFim);
        }

        protected void BtnUltimos60_Click(object sender, EventArgs e)
        {
            string dataInicio = DateTime.Today.AddDays(-60).ToString("yyyy-MM-dd");
            string dataFim = DateTime.Today.ToString("yyyy-MM-dd");

            ExibeResultado(dataInicio, dataFim);
        }

        protected void BtnUltimos90_Click(object sender, EventArgs e)
        {
            string dataInicio = DateTime.Today.AddDays(-90).ToString("yyyy-MM-dd");
            string dataFim = DateTime.Today.ToString("yyyy-MM-dd");

            ExibeResultado(dataInicio, dataFim);
        }

        private void ExibeResultado(string dataInicio, string dataFim)
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;
            int idConta = int.Parse(DDLContaSelecionada.SelectedValue);

            try
            {
                List<Resumo> resumo = resumoService.ExibirResumo(idConta, dataInicio, dataFim);

                GvResumo.DataSource = resumo;
                GvResumo.DataBind();

                decimal totalDespesas = resumo.FindAll(x => x.TipoLancamento == "Despesa").Sum(x => x.Valor);
                decimal totalReceitas = resumo.FindAll(x => x.TipoLancamento == "Receita").Sum(x => x.Valor);
                decimal resultadoPeriodo = CalculaResultado(totalReceitas, totalDespesas);
                decimal saldoConta = resumoService.RetornarSaldoConta(idUsuario, idConta);

                lblResultado.Text = $"Resultado: R$ {resultadoPeriodo}";
                lblSaldoConta.Text = $"Saldo Atual: R$ {saldoConta}";
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao carregar o resumo! Erro: {ex.Message}");
            }
        }

        private decimal CalculaResultado(decimal valorReceita, decimal valorDespesa) => valorReceita - valorDespesa;
    }
}