<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PeGi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- bootstrap 5 css -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">

    <title>Login</title>
</head>
<body>
    <div class="text-center mt-5">
        <form id="form1" runat="server" style="max-width: 400px; margin: auto;">
            <img class="mt-4 mb-4" src="img/cofrinho.png" height="72" alt="Pegi Logo" />
            <h1 class="h3 mb-3 font-weight-normal">Faça Login</h1>
            <%--<label for="username" class="sr-only">Usuário</label>--%>
            <input type="text" id="username" class="form-control mb-2" placeholder="Usuário" required autofocus />
            <%--<label for="senha" class="sr-only">Senha</label>--%>
            <input type="password" id="senha" class="form-control" placeholder="Senha" />
            <div class="mt-3">
                <a href="#" class="link-dark">Não possui conta?</a>
            </div>
            <div class="mt-3">
                <%--<button class="btn btn-lg btn-primary btn-dark" id="btn-entrar" runat="server" style="width:400px" onclick="">Entrar</button>--%>
                <asp:Button ID="BtnEntrar" runat="server" CssClass="btn btn-lg btn-primary btn-dark" style="width:400px" Text="Entrar" OnClick="BtnEntrar_Click" />
            </div>
        </form>
    </div>

    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
</body>
</html>
