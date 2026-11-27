<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/entrada.master" AutoEventWireup="true" CodeFile="cadastro.aspx.cs" Inherits="Views_Aluno_cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="form">
    <h2>Formulário de Cadastro</h2>

    <p>Nome:</p>
    <asp:TextBox ID="txtNome" runat="server" class="input cinza"></asp:TextBox>

    <p>E-mail:</p>
    <asp:TextBox ID="txtEmail" runat="server" class="input cinza"></asp:TextBox>

    <p>Senha:</p>
    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" class="input cinza"></asp:TextBox>

    <br />
    <asp:Button runat="server" ID="btnCadastro" Text="Cadastrar-se" OnClick="btnCadastro_Click" class="botao amarelo"/>

    <asp:Label runat="server" ID="lblMsg" Text="Label" Visible="false"></asp:Label>

    <p class="textoBotao">Voltar para o formulário de Login</p>
    <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" class="botao azul"/>
</div>

</asp:Content>

