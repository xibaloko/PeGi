<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="PeGi.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- bootstrap 5 css -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
    <title>Cadastro</title>
</head>
<body>
    <div class="text-center mt-5">
        <form id="form1" runat="server" style="max-width: 40%; margin: auto;">
            <img class="mt-4 mb-4" src="img/cofrinho.png" height="72" alt="Pegi Logo" />
            <h1 class="h3 mb-3 font-weight-normal">Cadastre-se</h1>

            <div class="row">
                <div class="col-md-4">
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="nome">Nome:</span>
                        <input id="nomeUsuario" runat="server" type="text" class="form-control" aria-describedby="nome"/>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="sobrenome">Sobrenome:</span>
                        <input id="sobrenomeUsuario" runat="server" type="text" class="form-control" aria-describedby="sobrenome"/>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="email">E-mail:</span>
                        <input id="emailUsuario" runat="server" type="text" class="form-control" aria-describedby="email"/>
                    </div>
                </div>
            </div>
           
            <div class="row mt-3">
                <div class="col-md-12" style="text-align:right;">
                    <asp:Button ID="BtnCadastrar" runat="server" CssClass="btn btn-lg btn-primary btn-dark" Style="width: 150px" Text="Confirmar" OnClick="BtnCadastrar_Click"  />
                    <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-lg btn-outline-dark" Style="width: 150px" Text="Cancelar" OnClick="BtnCancelar_Click"  />
                </div>
            </div>
            
        </form>
    </div>

    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
</body>
</html>
