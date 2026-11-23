<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/entrada.master" AutoEventWireup="true" CodeFile="cadastro.aspx.cs" Inherits="Views_Aluno_cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Formulário de Cadastro</h2>

    <p>Nome:</p>
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>

    <p>E-mail:</p>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

    <p>Senha</p>
    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>

    <br />
    <br />

    <asp:Button runat="server" ID="btnCadastro" Text="Cadastrar-se" OnClick="btnCadastro_Click" />

    <asp:Label runat="server" ID="lblMsg" Text="Label" Visible="false"></asp:Label>

    <p>Voltar para tela de login</p>
    <asp:Button runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click" />

</asp:Content>

