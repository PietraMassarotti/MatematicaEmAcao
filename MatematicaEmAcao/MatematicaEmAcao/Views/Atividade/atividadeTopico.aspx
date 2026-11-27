<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="atividadeTopico.aspx.cs" Inherits="Views_Atividade_atividadeTopico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pagina fundoCinza">

    <div class="topoPagina">
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" class="botao botaoVoltar azulEscuro"/>

        <div class="center">
            <asp:Label ID="lblNomeTopico" runat="server" Text="Label" class="tituloUm"></asp:Label>

            <p class="tituloDois">Não encontrou a atividade? Pesquise aqui.</p>

            <div class="buscar">
                <asp:TextBox ID="txtAtividade" runat="server" class="input"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="botao amarelo"/>
            </div>
        </div>
    </div>

    <asp:Repeater ID="rptAtividadeTopico" runat="server">

        <HeaderTemplate>
            <table class="tabela">
                <thead>
                    <tr class="azul">
                        <th>Código</th>
                        <th>Título</th>
                        <th>Tipo</th>
                        <th>Dificuldade</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><asp:Label ID="lblCod" runat="server"></asp:Label></td>
                <td>
                    <asp:HyperLink ID="lnkAtividade" runat="server">
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </asp:HyperLink>
                </td>
                <td><asp:Label ID="lblTipo" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblDificuldade" runat="server"></asp:Label></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>

    </asp:Repeater>

    <asp:Label ID="lblSemResultado" runat="server" Text="Nenhuma atividade encontrada :(" Visible="false" class="mensagem"></asp:Label>

</div>

</asp:Content>

