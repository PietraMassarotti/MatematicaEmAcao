<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="verPerfil.aspx.cs" Inherits="Views_Aluno_verPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="pagina fundoCinza">
    <div class="form">
        <p class="tituloUm">Meu Perfil</p>

        <asp:Label ID="lblNome" runat="server" Text="Nome:" class="rotulo"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server" MaxLength="100" class="input cinza"></asp:TextBox>

        <asp:Label ID="lblEmail" runat="server" Text="E-mail:" class="rotulo"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" MaxLength="60" class="input cinza"></asp:TextBox>

        <asp:Label ID="lblSenha" runat="server" Text="Senha:" class="rotulo"></asp:Label>
        <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" MaxLength="30" class="input cinza" ></asp:TextBox>

        <asp:Button ID="btnEditar" runat="server" Text="Atualizar Perfil" OnClick="btnEditar_Click" class="botao amarelo"/>

        <asp:Button runat="server" Text="Descartar Alterações" OnClick="Unnamed1_Click" class="botao azul"/>

        <asp:Label ID="lblMsg" runat="server" Visible="False" class="mensagem"></asp:Label>
    </div>
</div>
        
</asp:Content>