using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Aluno_dashboard : System.Web.UI.Page
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
            CarregarDashboard();
        }
    }

    private void CarregarDashboard()
    {
        int cod_aluno = Convert.ToInt32(Session["cod_usuario"]);

        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT a.streak_atual, a.streak_max, a.xp_atual, n.nome AS nivel, (SELECT COUNT(*) FROM tbl_aluno_has_conquistas WHERE cod_aluno = a.cod_aluno) AS total_conquistas FROM tbl_alunos a INNER JOIN tbl_niveis n ON n.cod_nivel = a.cod_nivel WHERE a.cod_aluno = @cod_aluno;";
        cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabelaAluno = new DataTable();
        tabelaAluno.Load(reader);
        reader.Close();

        if (tabelaAluno.Rows.Count == 0)
        {
            conn.Close();
            lblMsg.Text = "Não foi possível encontrar os dados do aluno.";
            lblMsg.Visible = true;
            return;
        }

        DataRow aluno = tabelaAluno.Rows[0];

        lblStreakAtual.Text = aluno["streak_atual"].ToString();
        lblStreakMax.Text = aluno["streak_max"].ToString();
        lblNivel.Text = aluno["nivel"].ToString();
        lblXpTotal.Text = aluno["xp_atual"].ToString();
        lblTotalConquistas.Text = aluno["total_conquistas"].ToString();

        cmd.Parameters.Clear();
        cmd.CommandText = "SELECT t.cod_topico, t.nome, COUNT(DISTINCT s.cod_questao) AS qtd FROM tbl_topicos t LEFT JOIN tbl_atividades atv ON atv.cod_topico = t.cod_topico LEFT JOIN tbl_questoes q ON q.cod_atividade = atv.cod_atividade LEFT JOIN tbl_submissoes s ON s.cod_questao = q.cod_questao AND s.cod_aluno = @cod_aluno GROUP BY t.cod_topico, t.nome, t.ordem ORDER BY t.ordem ASC;";
        cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
        reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(reader);
        reader.Close();

        cmd.Parameters.Clear();
        cmd.CommandText = "SELECT d.cod_dificuldade, d.nome, COUNT(DISTINCT s.cod_questao) AS qtd FROM tbl_dificuldades d LEFT JOIN tbl_atividades atv ON atv.cod_dificuldade = d.cod_dificuldade LEFT JOIN tbl_questoes q ON q.cod_atividade = atv.cod_atividade LEFT JOIN tbl_submissoes s ON s.cod_questao = q.cod_questao AND s.cod_aluno = @cod_aluno GROUP BY d.cod_dificuldade, d.nome ORDER BY d.cod_dificuldade ASC;";
        cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
        reader = cmd.ExecuteReader();

        DataTable tabelaDif = new DataTable();
        tabelaDif.Load(reader);
        reader.Close();

        conn.Close();

        rptTopicos.DataSource = tabela;
        rptTopicos.DataBind();

        int total = 0;

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptTopicos.Items[i];

            Label lblTopico = (Label)item.FindControl("lblTopico");
            Label lblQtdTopico = (Label)item.FindControl("lblQtdTopico");

            int qtd = Convert.ToInt32(linha["qtd"]);

            lblTopico.Text = linha["nome"].ToString();
            lblQtdTopico.Text = qtd.ToString();

            total += qtd;
        }

        lblTotalAtividadesFeitas.Text = total.ToString();

        rptDificuldades.DataSource = tabelaDif;
        rptDificuldades.DataBind();

        for (int i = 0; i < tabelaDif.Rows.Count; i++)
        {
            DataRow linha = tabelaDif.Rows[i];
            RepeaterItem item = rptDificuldades.Items[i];

            Label lblDificuldade = (Label)item.FindControl("lblDificuldade");
            Label lblQtdDificuldade = (Label)item.FindControl("lblQtdDificuldade");

            lblDificuldade.Text = linha["nome"].ToString();
            lblQtdDificuldade.Text = linha["qtd"].ToString();
        }
    }
}