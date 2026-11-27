<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="Views_Aluno_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="pagina fundoCinza">

    <div class="center">
        <p class="tituloUm">Meu Progresso</p>
    </div>

    <asp:Label ID="lblMsg" runat="server" Visible="False" class="mensagem"></asp:Label>

    <div class="gradeInfo quatroColunas">
        <div class="painel">
            <p class="painelTitulo">Streak atual</p>
            <asp:Label ID="lblStreakAtual" runat="server" class="painelValor"></asp:Label>
        </div>

        <div class="painel painelDestaque">
            <p class="painelTitulo">Streak Máximo</p>
            <asp:Label ID="lblStreakMax" runat="server" class="painelValor"></asp:Label>
        </div>

        <div class="painel">
            <p class="painelTitulo">Nível atual</p>
            <asp:Label ID="lblNivel" runat="server" class="painelValor"></asp:Label>
        </div>

        <div class="painel">
            <p class="painelTitulo">XP Total</p>
            <asp:Label ID="lblXpTotal" runat="server" class="painelValor"></asp:Label>
        </div>
    </div>

    <div class="gradeInfo duasColunas">
        <div class="painel">
            <p class="painelTitulo">Total de Conquistas</p>
            <asp:Label ID="lblTotalConquistas" runat="server" class="painelValor"></asp:Label>
        </div>

        <div class="painel">
            <p class="painelTitulo">Total de Atividades Realizadas</p>
            <asp:Label ID="lblTotalAtividadesFeitas" runat="server" class="painelValor"></asp:Label>
        </div>
    </div>

    <div class="gradeInfo duasColunas">
        <div class="painel">
            <p class="painelTitulo">Exercícios Realizados Por Tópico</p>
            <asp:Repeater ID="rptTopicos" runat="server">
                <ItemTemplate>
                    <div class="linhaLista">
                        <asp:Label ID="lblTopico" runat="server"></asp:Label>:
                        <asp:Label ID="lblQtdTopico" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="painel">
            <p class="painelTitulo">Exercícios Realizados Por Dificuldade</p>
            <asp:Repeater ID="rptDificuldades" runat="server">
                <ItemTemplate>
                    <div class="linhaLista">
                        <asp:Label ID="lblDificuldade" runat="server"></asp:Label>:
                        <asp:Label ID="lblQtdDificuldade" runat="server"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</div>

</asp:Content>