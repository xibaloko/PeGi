using Business.Models;
using Business.Services;
using PeGi.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeGi
{
    public partial class Default : Page
    {
        readonly DefaultService defaultService = new DefaultService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarContas();
            }
        }

        private void CarregarContas()
        {
            int idUsuario = SessaoUsuario.RecuperarSessao(Page).IdUsuario;

            try
            {
                List<Conta> lstContas = defaultService.ExibirContas(idUsuario);

                if (lstContas.Count > 0)
                {
                    GvContas.DataSource = lstContas;
                    GvContas.DataBind();

                    decimal saldoGeral = lstContas.Sum(x => x.Saldo);

                    lblSaldoGeral.Text = $"Saldo geral: R$ {saldoGeral}";

                    PnlContas.Visible = true;
                }
                else
                {
                    PnlContas.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Mensagem.ExibirMensagem(this, Mensagem.TipoMensagem.Erro, $"Ocorreu um erro ao carregar as contas! Erro: {ex.Message}");
            }
        }
    }
}