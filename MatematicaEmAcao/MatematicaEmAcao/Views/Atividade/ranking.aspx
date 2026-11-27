<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="ranking.aspx.cs" Inherits="Views_Atividade_ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="pagina fundoCinza">

    <div class="center">
        <div class="buscar">
            <asp:DropDownList ID="ddlBusca" runat="server" class="input">
                <asp:ListItem Value="1" Text="Ranking do meu nível" Selected="True"></asp:ListItem>
                <asp:ListItem Value="2" Text="Ranking Geral"></asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" class="botao amarelo"/>
        </div>

        <asp:Label ID="lblTitulo" runat="server" class="tituloUm"></asp:Label>
    </div>

    <asp:Repeater ID="rptRanking" runat="server">

        <HeaderTemplate>
            <table class="tabela">
                <thead>
                    <tr class="azul">
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

    <asp:Label ID="lblSemResultado" runat="server" Visible="false" Text="Nenhum aluno encontrado no ranking." class="mensagem"></asp:Label>

</div>

</asp:Content>

