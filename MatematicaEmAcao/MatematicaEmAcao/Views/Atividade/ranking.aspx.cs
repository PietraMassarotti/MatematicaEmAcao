using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Atividade_ranking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cod_usuario"] == null)
        {
            Response.Redirect("~/Views/Aluno/login.aspx");
            return;
        }

        if (!IsPostBack)
        {
            CarregarRanking("1");
        }
    }

    protected void btnMostrar_Click(object sender, EventArgs e)
    {
        CarregarRanking(ddlBusca.SelectedValue);
    }

    private void CarregarRanking(string filtro)
    {
        int cod_aluno = Convert.ToInt32(Session["cod_usuario"]);

        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        if (filtro == "1")
        {
            cmd.CommandText = "SELECT u.nome, a.xp_atual, n.nome AS nivel FROM tbl_alunos a INNER JOIN tbl_usuarios u ON u.cod_usuario = a.cod_aluno INNER JOIN tbl_niveis n ON n.cod_nivel = a.cod_nivel  WHERE a.cod_nivel = (SELECT cod_nivel FROM tbl_alunos WHERE cod_aluno = @cod_aluno) ORDER BY a.xp_atual DESC, u.nome ASC;";
            cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
        }
        else
        {
            cmd.CommandText = "SELECT u.nome, a.xp_atual, n.nome AS nivel FROM tbl_alunos a INNER JOIN tbl_usuarios u ON u.cod_usuario = a.cod_aluno INNER JOIN tbl_niveis n ON n.cod_nivel = a.cod_nivel ORDER BY a.xp_atual DESC, u.nome ASC;";
        }

        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(reader);

        conn.Close();

        rptRanking.DataSource = tabela;
        rptRanking.DataBind();

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptRanking.Items[i];

            Label lblPosicao = (Label)item.FindControl("lblPosicao");
            Label lblNome = (Label)item.FindControl("lblNome");
            Label lblNivel = (Label)item.FindControl("lblNivel");
            Label lblXp = (Label)item.FindControl("lblXp");

            lblPosicao.Text = (i + 1).ToString() + "º";
            lblNome.Text = linha["nome"].ToString();
            lblNivel.Text = linha["nivel"].ToString();
            lblXp.Text = linha["xp_atual"].ToString() + " XP";
        }

        if (filtro == "1" && tabela.Rows.Count > 0)
        {
            lblTitulo.Text = "Ranking do nível " + tabela.Rows[0]["nivel"].ToString();
        }
        else
        {
            lblTitulo.Text = "Ranking Geral";
        }

        lblSemResultado.Visible = (tabela.Rows.Count == 0);
    }
}