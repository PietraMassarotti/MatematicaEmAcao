using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Cabecalho_menu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        //abandona e sai da sessão
        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/Views/Aluno/login.aspx");
    }

    protected void bntAtividades_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Atividade/index.aspx");
    }

    protected void bntRanking_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Atividade/ranking.aspx");
    }

    protected void btnProgresso_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Aluno/dashboard.aspx");
    }

    protected void btnPerfil_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Aluno/verPerfil.aspx");
    }

    protected void btnConquistas_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Aluno/conquistas.aspx");
    }
}
