<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="atividadeTopico.aspx.cs" Inherits="Views_Atividade_atividadeTopico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/>

    <asp:Label ID="lblNomeTopico" runat="server" Text="Label"></asp:Label>

    <h2>Buscar uma atividade dentro do tópico</h2>

    <div class="buscarAtividade">
        <asp:TextBox ID="txtAtividade" runat="server" class="input"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
    </div>

    <asp:Repeater ID="rptAtividadeTopico" runat="server">

    <ItemTemplate>
        <div>
            <asp:HyperLink ID="lnkAtividade" runat="server">
                 <asp:Label ID="lblCod" runat="server"></asp:Label>
                 <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                 <asp:Label ID="lblTipo" runat="server"></asp:Label>
                 <asp:Label ID="lblDificuldade" runat="server"></asp:Label>
            </asp:HyperLink>             
        </div>
    </ItemTemplate>

</asp:Repeater>

    <asp:Label ID="lblSemResultado" runat="server" Text="Nenhuma atividade encontrada :(" Visible ="false"></asp:Label>

</asp:Content>

