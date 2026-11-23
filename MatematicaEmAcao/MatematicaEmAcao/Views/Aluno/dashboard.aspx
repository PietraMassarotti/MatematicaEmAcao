<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="Views_Aluno_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Meu Progresso</h1>

    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>

        <p>Streak Atual:</p>
        <asp:Label ID="lblStreakAtual" runat="server"></asp:Label>

    <br />

    <p>Streak Máximo:</p>
        <asp:Label ID="lblStreakMax" runat="server"></asp:Label>

    <br />

    <p>Nível Atual:</p>
        <asp:Label ID="lblNivel" runat="server"></asp:Label>

    <br />

    <p>Xp Total:</p>
        <asp:Label ID="lblXpTotal" runat="server"></asp:Label>

    <br />

    <p>Número Total de Conquistas:</p>
        <asp:Label ID="lblTotalConquistas" runat="server"></asp:Label>

    <br />

    <p>Número Total de atividades realizadas:</p>
        <asp:Label ID="lblTotalAtividadesFeitas" runat="server"></asp:Label>
    <br />

    <h3>Número de exercícios realizados por tópico</h3>
    <asp:Repeater ID="rptTopicos" runat="server">
        <ItemTemplate>
            <div>
                <asp:Label ID="lblTopico" runat="server"></asp:Label>
                <asp:Label ID="lblQtdTopico" runat="server"></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <h3>Número de exercícios realizados por dificuldade</h3>

    <asp:Repeater ID="rptDificuldades" runat="server">
        <ItemTemplate>
            <div>
                <asp:Label ID="lblDificuldade" runat="server"></asp:Label>
                <asp:Label ID="lblQtdDificuldade" runat="server"></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>