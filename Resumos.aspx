<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumos.aspx.cs" Inherits="PeGi.Resumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <h1>Resumos</h1>
    <h3>Confira seu balanço por período</h3>

    <div class="row mt-5">
        <div class="col-md-3">
            <label for="DDLContaSelecionada" class="form-label">Conta:</label>
            <asp:DropDownList ID="DDLContaSelecionada" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="DDLContaSelecionada_SelectedIndexChanged" />
        </div>
        <div class="col-md-2">
            <label for="TxtBoxDataInic" class="form-label">Período de:</label>
            <input type="date" runat="server" class="form-control" id="TxtBoxDataInic">
            <asp:Label ID="LblErroDtInic" runat="server" Text="Selecione uma data inicial" ForeColor="Red" Visible="false" />
        </div>
        <div class="col-md-2">
            <label for="TxtBoxDataFim" class="form-label">Até:</label>
            <input type="date" runat="server" class="form-control" id="TxtBoxDataFim">
            <asp:Label ID="LblErroDtFim" runat="server" Text="Selecione uma data final" ForeColor="Red" Visible="false" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="BtnPesquisarPorPeriodo" runat="server" CssClass="btn btn-dark align-btn" Text="Pesquisar" OnClick="BtnPesquisarPorPeriodo_Click" ValidationGroup="PeriodoDinamico" />
        </div>
    </div>
    <div class="row mt-5">
        <h5>Resumo rápido</h5>
    </div>

    <div class="row mt-3">
        <div class="col-md-1">
            <asp:Button ID="BtnUltimos30" runat="server" CssClass="btn btn-outline-dark btn-pesq-periodo" Text="30 dias" OnClick="BtnUltimos30_Click" />
        </div>
        <div class="col-md-1">
            <asp:Button ID="BtnUltimos60" runat="server" CssClass="btn btn-outline-dark btn-pesq-periodo" Text="60 dias" OnClick="BtnUltimos60_Click" />
        </div>
        <div class="col-md-1">
            <asp:Button ID="BtnUltimos90" runat="server" CssClass="btn btn-outline-dark btn-pesq-periodo" Text="90 dias" OnClick="BtnUltimos90_Click" />
        </div>
    </div>

    <div class="row mt-5">
        <div class="col-md-9">
            <asp:GridView ID="GvResumo" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField HeaderText="Descrição" DataField="Descricao" />
                    <asp:BoundField HeaderText="Data Lançamento" DataField="DataLancamento" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Tipo Lancamento" DataField="TipoLancamento" />
                    <asp:BoundField HeaderText="Valor" DataField="Valor" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-9 align-in-col">
            <h5>
                <asp:Literal ID="lblResultado" runat="server" />
            </h5>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-9 align-in-col">
            <h5>
                <asp:Literal ID="lblSaldoConta" runat="server" />
            </h5>
        </div>
    </div>
</asp:Content>
