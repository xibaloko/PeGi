<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PeGi.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1>Seja bem-vindo ao PeGi</h1>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-md-12">
            <h3 class="fst-italic">Pequenas Economias Grandes Investimentos</h3>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-6">
            <h5 class="fw-light lh-base">O PeGi é um sistema gerenciador de contas muito versátil, 
            nele você pode cadastrar quantas contas quiser, lançar receitas, despesas e 
            conferir seus resultados por período.
            </h5>
        </div>
    </div>
    <asp:Panel ID="PnlContas" runat="server">
        <div class="row mt-5">
            <div class="col-md-9">
                <asp:GridView ID="GvContas" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField HeaderText="Nome Conta" DataField="NomeConta" />
                        <asp:BoundField HeaderText="Tipo da Conta" DataField="TipoConta" />
                        <asp:BoundField HeaderText="Saldo" DataField="Saldo" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-9 align-in-col">
                <h5>
                    <asp:Literal ID="lblSaldoGeral" runat="server" />
                </h5>
            </div>
        </div>
    </asp:Panel>



</asp:Content>
