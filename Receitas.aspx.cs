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
    public partial class Receitas : Page
    {
        readonly ReceitasService receitasService = new ReceitasService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDDListContas();
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

        protected void BtnCadastrarConta_Click(object sender, EventArgs e)
        {

        }
    }
}