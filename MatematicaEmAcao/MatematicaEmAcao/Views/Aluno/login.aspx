<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/entrada.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Views_Aluno_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="form">
    <h2>Formulário de Login</h2>

    <p>E-mail:</p>
    <asp:TextBox ID="txtEmail" runat="server" class="cinza"></asp:TextBox>

    <p>Senha</p>
    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" class="cinza"></asp:TextBox>

    <br />
    <br />

    <asp:Button runat="server" ID="btnLogin" Text="Entrar" OnClick="btnLogin_Click" class="botao amarelo"/>

    <br />
    <br />

    <asp:Label runat="server" ID="lblMsg" Text="Label" Visible="false"></asp:Label>

    <p>Ainda não possui uma conta? Cadastre-se!</p>
    <asp:Button runat="server" ID="btnCadastro" Text="Cadastrar-se" OnClick="btnCadastro_Click" class="botao azulEscuro"/>

</div>
    
</asp:Content>

