<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="verPerfil.aspx.cs" Inherits="Views_Aluno_verPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Meu Perfil</h1>

        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server" MaxLength="100"></asp:TextBox>

        <br />

        <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" MaxLength="60"></asp:TextBox>

        <br />

        <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
        <asp:TextBox ID="txtSenha" runat="server" MaxLength="30"></asp:TextBox>

    <br />
    <br />


    <asp:Button ID="btnEditar" runat="server" Text="Atualizar Perfil" OnClick="btnEditar_Click" />

    <br />
    <br />

    <asp:Button runat="server" Text="Descartar alteração" OnClick="Unnamed1_Click" />

    <br />
    <br />

    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>

</asp:Content>