<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Cabecalho/menu.master" AutoEventWireup="true" CodeFile="atividade.aspx.cs" Inherits="Views_Atividade_atividade" MaintainScrollPositionOnPostBack="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:HiddenField ID="hdfTipo" runat="server" />
<div class="pagina fundoCinza">

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <div class="tituloAtividade">
        <asp:Button runat="server" Text="Voltar" OnClick="Unnamed1_Click" class="botao botaoVoltar azulEscuro" />
        <p class="tituloUm">
            <asp:Label ID="lblCodAtividade" runat="server"></asp:Label>:
            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </p>
    </div>

    <div class="faixaInfo">
        <asp:Label ID="lblTopico" runat="server"></asp:Label>
        <asp:Label ID="lblTipo" runat="server"></asp:Label>
        <asp:Label ID="lblDificuldade" runat="server"></asp:Label>
    </div>

    <asp:Repeater ID="rptQuestoes" runat="server" OnItemCommand="rptQuestoes_ItemCommand">
        <ItemTemplate>
            <div class="questao">
                <asp:HiddenField ID="hdfCodQuestao" runat="server" />
                <asp:HiddenField ID="hdfResposta" runat="server" />

                <asp:Label ID="lblPergunta" runat="server" class="pergunta"></asp:Label>

                <!--Resposta digitada-->
                <asp:Panel ID="pnlEscrita" runat="server" Visible="False">
                    <asp:TextBox ID="txtResposta" runat="server" class="input cinza respostaTexto"></asp:TextBox>
                </asp:Panel>

                <!--Múltipla Escolha-->
                <asp:Panel ID="pnlMultiplaE" runat="server" Visible="False" CssClass="opcoes">
                    <asp:Button ID="btnOp1" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="1" />
                    <asp:Button ID="btnOp2" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="2" />
                    <asp:Button ID="btnOp3" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="3" />
                    <asp:Button ID="btnOp4" runat="server" CssClass="opcao" CommandName="Selecionar" CommandArgument="4" />
                </asp:Panel>

                <!--Verdadeiro/Falso-->
                <asp:Panel ID="pnlVerdFalso" runat="server" Visible="False" CssClass="opcoes opcoesLargas">
                    <asp:Button ID="btnVerdadeiro" runat="server" Text="Verdadeiro" CssClass="opcao" CommandName="Selecionar" CommandArgument="Verdadeiro" />
                    <asp:Button ID="btnFalso" runat="server" Text="Falso" CssClass="opcao" CommandName="Selecionar" CommandArgument="Falso" />
                </asp:Panel>

                <asp:Button ID="btnDica" runat="server" Text="Dica" CommandName="Dica" class="botao botaoGrande botaoDica amarelo" />
                <asp:Label ID="lblDica" runat="server" Visible="False" class="dica"></asp:Label>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="center" style="margin-top: 24px;">
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" class="botao botaoGrande azul" />
    </div>

    <asp:Panel ID="pnlResultado" runat="server" Visible="False" CssClass="resultado">
        <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblAcertos" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblPontos" runat="server" Visible="False"></asp:Label>
    </asp:Panel>

</div>

</asp:Content>