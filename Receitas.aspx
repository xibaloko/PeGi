<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receitas.aspx.cs" Inherits="PeGi.Receitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/receitas-styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Receitas</h1>
    <h3>Lance suas receitas mensais</h3>

    <div class="row mt-5">
        <div class="col-md-3">
            <label for="DDLContaSelecionada" class="form-label">Conta:</label>
            <asp:DropDownList ID="DDLContaSelecionada" runat="server" CssClass="form-select">
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            <label for="TxtBoxDescricao" class="form-label">Descrição:</label>
            <input type="text" runat="server" class="form-control" id="TxtBoxDescricao" placeholder="Breve descrição da receita">
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-3">
            <label for="TxtBoxValor" class="form-label">Valor:</label>
            <input type="text" runat="server" class="form-control" id="TxtBoxValor" placeholder="Valor da receita .00">
        </div>
        <div class="col-md-3">
            <label for="TxtBoxData" class="form-label">Data:</label>
            <input type="date" runat="server" class="form-control" id="TxtBoxData" placeholder="Data do recebimento">
        </div>
        <div class="col-md-3 align-in-col">
            <asp:Button ID="BtnCadastrarConta" runat="server" CssClass="btn btn-dark align-btn" Text="Lançar" OnClick="BtnCadastrarConta_Click" />
        </div>

    </div>
</asp:Content>
