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
            <asp:DropDownList ID="DDLContaSelecionada" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="DDLContaSelecionada_SelectedIndexChanged" />
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
            <asp:Button ID="BtnLancarReceita" runat="server" CssClass="btn btn-dark align-btn" Text="Lançar" OnClick="BtnLancarReceita_Click" />
        </div>
    </div>
    <div class="row mt-5">
        <div class="col-md-9">
            <asp:GridView ID="GvLancamentosReceitas" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:BoundField HeaderText="Descrição" DataField="Descricao" />
                    <asp:BoundField HeaderText="Data Lançamento" DataField="DataLancamento" />
                    <asp:BoundField HeaderText="Valor" DataField="Valor" />
                    <asp:TemplateField HeaderText="Ação">
                        <ItemTemplate>
                            <asp:ImageButton ID="BtnDeletarLancamento" runat="server" ImageUrl="img/baseline_clear_black_24dp.png" CommandArgument='<%#Eval("IdLancamento")%>' OnCommand="BtnDeletarLancamento_Command" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row mt-3">
        <div class="col-md-9 align-in-col">
            <h5>
                <asp:Literal ID="lblTotalReceitas" runat="server" />
            </h5>
        </div>
    </div>

    <%--MODAL DELETA CONTA--%>
    <div class="modal fade" id="modalDeletaLancamento" role="dialog" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="modalExcluiLancamentoTitle" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalExcluiLancamentoTitle">Excluir Lançamento</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <h6>Tem certeza que deseja excluir esse lançamento?</h6>
                    <asp:HiddenField ID="HiddenFieldModalExcluirLanc" runat="server" />
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-primary btn-dark">Confirmar</button>--%>
                    <asp:Button ID="BtnConfirmaExclusaoLanc" runat="server" CssClass="btn btn-primary btn-danger" Text="Confirmar" OnClick="BtnConfirmaExclusaoLanc_Click" />
                    <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
