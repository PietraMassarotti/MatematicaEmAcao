<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Views_Atividade_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="pagina fundoCinza">

    <div class="center">
        <p class="tituloDois">Não encontrou o tópico? Pesquise aqui.</p>

        <div class="buscar">
            <asp:TextBox ID="txtTopico" runat="server" class="input"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="botao amarelo"/>
        </div>

        <p class="tituloUm">Tópicos</p>
    </div>

    <div class="catalogoGrid">
        <asp:Repeater ID="rptTopico" runat="server">
            <ItemTemplate>
                <div class="card amareloClaro">
                    <asp:HyperLink ID="lnkTopico" runat="server">
                        <asp:Label ID="lblNome" runat="server" class="cardNome"></asp:Label>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:Label ID="lblSemResultado" runat="server" Visible="false" Text="Nenhum tópico encontrado :(" class="mensagem"></asp:Label>

</div>
</asp:Content>

