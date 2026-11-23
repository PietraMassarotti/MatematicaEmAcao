<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="atividade.aspx.cs" Inherits="Views_Atividade_atividade" MaintainScrollPositionOnPostBack="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:HiddenField ID="hdfTipo" runat="server" />

        <asp:Button runat="server" Text="Voltar" OnClick="Unnamed1_Click" />
    <br />
<asp:Label ID="lblCodAtividade" runat="server"></asp:Label>
<asp:Label ID="lblTitulo" runat="server"></asp:Label>
<br />
<asp:Label ID="lblTopico" runat="server"></asp:Label>
<asp:Label ID="lblTipo" runat="server"></asp:Label>
<asp:Label ID="lblDificuldade" runat="server"></asp:Label>



<asp:Repeater ID="rptQuestoes" runat="server" OnItemCommand="rptQuestoes_ItemCommand">
    <ItemTemplate>
        <div>
            <asp:HiddenField ID="hdfCodQuestao" runat="server" />
            <asp:HiddenField ID="hdfResposta" runat="server" />

            <asp:Label ID="lblPergunta" runat="server"></asp:Label>

            <asp:Button ID="btnDica" runat="server" Text="Dica" CommandName="Dica" />
            <asp:Label ID="lblDica" runat="server" Visible="False"></asp:Label>

            <!--Resposta digitada-->
            <asp:Panel ID="pnlEscrita" runat="server" Visible="False">
                <asp:TextBox ID="txtResposta" runat="server"></asp:TextBox>
            </asp:Panel>

            <!--Quiz-->
            <asp:Panel ID="pnlQuiz" runat="server" Visible="False">
                <asp:Button ID="btnOp1" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="1" />
                <asp:Button ID="btnOp2" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="2" />
                <asp:Button ID="btnOp3" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="3" />
                <asp:Button ID="btnOp4" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="4" />
            </asp:Panel>

            <!--Verdadeiro/Falso-->
            <asp:Panel ID="pnlVerdFalso" runat="server" Visible="False">
                <asp:Button ID="btnVerdadeiro" runat="server" Text="Verdadeiro" CssClass="opcao" CommandName="Selecionar" CommandArgument="Verdadeiro" />
                <asp:Button ID="btnFalso" runat="server" Text="Falso" CssClass="opcao" CommandName="Selecionar" CommandArgument="Falso" />
            </asp:Panel>
        </div>
    </ItemTemplate>
</asp:Repeater>

    <br />

    <asp:Button ID="btnEnviar" runat="server" Text="Enviar atividade" OnClick="btnEnviar_Click" />

    <br />
    <br />

    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
     <br />
    <asp:Label ID="lblAcertos" runat="server" Visible="False"></asp:Label>
     <br />
    <asp:Label ID="lblPontos" runat="server" Visible="False"></asp:Label>

</asp:Content>