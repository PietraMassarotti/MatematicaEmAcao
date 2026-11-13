<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Views_Atividade_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="center">

            <p class="tituloDois" >Não encontrou o Tópico? Pesquise aqui!</p>

            <br />

            <div class="buscarTopico">
                <asp:TextBox ID="txtTopico" runat="server" class="input"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="botao amarelo"/>
            </div>

        </div>

        <p class="tituloUm">Topicos</p>

        <div class="catalogoGrid">
        <asp:Repeater ID="rptTopico" runat="server">

            <ItemTemplate>
                <div class="card amarelo">
                    <asp:HyperLink ID="lnkTopico" runat="server">
                        <asp:Label ID="lblNome" runat="server" class="cardNome"></asp:Label>
                    </asp:HyperLink>             
                </div>
            </ItemTemplate>

        </asp:Repeater>
        </div>

        <asp:Label ID="lblSemResultado" runat="server" Visible="false" Text="Nenhum tópico encontrado :("></asp:Label>

</asp:Content>

