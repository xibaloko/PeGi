<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumos.aspx.cs" Inherits="PeGi.Resumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Resumos</h1>
    <h3>Confira seu balanço por período</h3>

    <div class="row mt-5">
        <div class="col-md-3">
            <label for="DDLContaSelecionada" class="form-label">Conta:</label>
            <asp:DropDownList ID="DDLContaSelecionada" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="DDLContaSelecionada_SelectedIndexChanged" />
        </div>
        <div class="col-md-6">
            <label for="TxtBoxDescricao" class="form-label">Descrição:</label>
            <input type="text" runat="server" class="form-control" id="TxtBoxDescricao" placeholder="Breve descrição da receita">
        </div>
    </div>
</asp:Content>
