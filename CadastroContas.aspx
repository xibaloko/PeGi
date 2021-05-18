<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroContas.aspx.cs" Inherits="PeGi.CadastroContas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/cadastro-contas-styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastro de Contas</h1>
    <div class="row mt-5">
        <div class="col-md-3">
            <label for="nomeConta" class="form-label">Nome Conta:</label>
            <input type="text" runat="server" class="form-control" id="nomeConta" placeholder="Nome da conta">
        </div>
        <div class="col-md-3">
            <label for="DDLTipoConta" class="form-label">Tipo Conta:</label>
            <asp:DropDownList ID="DDLTipoConta" runat="server" CssClass="form-select">
                <asp:ListItem Selected="True" Value="1" Text="Caixa" />
                <asp:ListItem Value="2" Text="Conta Corrente" />
                <asp:ListItem Value="3" Text="Poupança" />
                <asp:ListItem Value="4" Text="Investimentos" />
            </asp:DropDownList>
        </div>
    </div>
     <div class="row mt-3">
        <div class="col-md-3">
            <label for="saldoConta" class="form-label">Saldo Atual:</label>
            <input type="text" runat="server" class="form-control" id="saldoConta" placeholder="Saldo da conta .00">
        </div>
         <div class="col-md-3 align-in-col">
            <%--<button type="button" class="btn btn-dark align-btn">Cadastrar</button>--%>
             <asp:Button ID="BtnCadastrarConta" runat="server" CssClass="btn btn-dark align-btn" Text="Cadastrar" OnClick="BtnCadastrarConta_Click" />
        </div>
    </div>
</asp:Content>
