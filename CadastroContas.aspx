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
    <div class="row mt-5">
        <div class="col-md-6">
            <asp:GridView ID="GvContas" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField HeaderText="Nome Conta" DataField="NomeConta" />
                    <asp:BoundField HeaderText="Tipo Conta" DataField="TipoConta" />
                    <asp:BoundField HeaderText="Saldo (R$)" DataField="Saldo" />
                    <asp:TemplateField HeaderText="Ação">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnAlterarConta" runat="server" ImageUrl="img/baseline_settings_black_24dp.png" CommandArgument='<%#Eval("IdConta")%>' OnCommand="BtnAlterarConta_Command" />
                            <asp:ImageButton ID="BtnDeletarConta" runat="server" ImageUrl="img/baseline_clear_black_24dp.png" CommandArgument='<%#Eval("IdConta")%>' OnCommand="BtnDeletarConta_Command" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
            Launch static backdrop modal
        </button>--%>
    </div>

    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Understood</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
