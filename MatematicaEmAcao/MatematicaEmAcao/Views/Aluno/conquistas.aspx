<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="conquistas.aspx.cs" Inherits="Views_Aluno_conquistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="pagina fundoCinza">

    <div class="center">
        <p class="tituloUm">Conquistas</p>
    </div>

    <div class="listaConquistas">
        <asp:Repeater ID="rptConquistas" runat="server">
            <ItemTemplate>
                <asp:Panel ID="pnlConquista" runat="server">
                    <asp:Label ID="lblNome" runat="server"></asp:Label>
                    <asp:Label ID="lblDescricao" runat="server"></asp:Label>
                    <asp:Label ID="lblDataObtido" runat="server"></asp:Label>
                </asp:Panel>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</div>

</asp:Content>