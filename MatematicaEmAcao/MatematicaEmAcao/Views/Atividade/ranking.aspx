<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="ranking.aspx.cs" Inherits="Views_Atividade_ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Ranking</h1>

    <asp:DropDownList ID="ddlBusca" runat="server">
        <asp:ListItem Value="1" Text="Ranking do meu Nível" Selected="True"></asp:ListItem>
        <asp:ListItem Value="2" Text="Ranking Geral"></asp:ListItem>
    </asp:DropDownList>

    <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" />

    <h3><asp:Label ID="lblTitulo" runat="server"></asp:Label></h3>

    <asp:Repeater ID="rptRanking" runat="server">
        <ItemTemplate>
            <div>
                <asp:Label ID="lblPosicao" runat="server"></asp:Label>
                <asp:Label ID="lblNome" runat="server"></asp:Label>
                <asp:Label ID="lblNivel" runat="server"></asp:Label>
                <asp:Label ID="lblXp" runat="server"></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label ID="lblSemResultado" runat="server" Visible="false" Text="Nenhum aluno encontrado no ranking."></asp:Label>

</asp:Content>

