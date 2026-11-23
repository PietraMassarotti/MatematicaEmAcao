<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="verPerfil.aspx.cs" Inherits="Views_Aluno_verPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p class="tituloUm">Meu Perfil</p>
    <br />
    <div class="form">
        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server" MaxLength="100" class="input cinza"></asp:TextBox>

        <br />
        <br />

        <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" MaxLength="60" class="input cinza"></asp:TextBox>

        <br />
        <br />

        <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
        <asp:TextBox ID="txtSenha" runat="server" MaxLength="30" class="input cinza"></asp:TextBox>

        <br />
        <br />


        <asp:Button ID="btnEditar" runat="server" Text="Atualizar Perfil" OnClick="btnEditar_Click" class="botao amarelo"/>

        <br />
        <br />

        <asp:Button runat="server" Text="Descartar Alteração" OnClick="Unnamed1_Click" class="botao azulEscuro"/>

        <br />
        <br />

        <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    </div>
        
</asp:Content>