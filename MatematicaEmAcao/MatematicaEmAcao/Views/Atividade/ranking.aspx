<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="ranking.aspx.cs" Inherits="Views_Atividade_ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p class="tituloUm">Ranking</p>

    <br />

    <div class="buscar">
        <asp:DropDownList ID="ddlBusca" runat="server" class="input">
            <asp:ListItem Value="1" Text="Ranking do meu Nível" Selected="True"></asp:ListItem>
            <asp:ListItem Value="2" Text="Ranking Geral"></asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" class="botao amarelo"/>
    </div>

    <br />

    <p><asp:Label ID="lblTitulo" runat="server" class="tituloDois"></asp:Label></p>

    <br />

    <asp:Repeater ID="rptRanking" runat="server">

    <HeaderTemplate>
        <table class="tabela">
            <thead>
                <tr class="azulEscuro">
                    <th>Posição</th>
                    <th>Aluno</th>
                    <th>Nível</th>
                    <th>XP</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>

    <ItemTemplate>
        <tr>
            <td><asp:Label ID="lblPosicao" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblNome" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblNivel" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblXp" runat="server"></asp:Label></td>
        </tr>
    </ItemTemplate>

    <FooterTemplate>
            </tbody>
        </table>
    </FooterTemplate>

</asp:Repeater>

    <asp:Label ID="lblSemResultado" runat="server" Visible="false" Text="Nenhum aluno encontrado no ranking."></asp:Label>

</asp:Content>

