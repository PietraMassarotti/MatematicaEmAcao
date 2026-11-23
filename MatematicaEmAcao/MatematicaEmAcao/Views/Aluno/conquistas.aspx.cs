using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Aluno_conquistas : System.Web.UI.Page
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
            CarregarConquistas();
        }
    }

    private void CarregarConquistas()
    {
        int cod_aluno = Convert.ToInt32(Session["cod_usuario"]);

        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT c.cod_conquista, c.titulo, c.descricao, ac.data_ganha FROM tbl_conquistas c LEFT JOIN tbl_aluno_has_conquistas ac ON ac.cod_conquista = c.cod_conquista AND ac.cod_aluno = @cod_aluno ORDER BY CASE WHEN ac.data_ganha IS NULL THEN 1 ELSE 0 END ASC, ac.data_ganha DESC, c.cod_conquista ASC;";
        cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(reader);

        conn.Close();

        rptConquistas.DataSource = tabela;
        rptConquistas.DataBind();

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptConquistas.Items[i];

            Panel pnlConquista = (Panel)item.FindControl("pnlConquista");
            Label lblNome = (Label)item.FindControl("lblNome");
            Label lblDescricao = (Label)item.FindControl("lblDescricao");
            Label lblDataObtido = (Label)item.FindControl("lblDataObtido");

            lblNome.Text = linha["titulo"].ToString();
            lblDescricao.Text = linha["descricao"].ToString();

            if (linha["data_ganha"] != DBNull.Value)
            {
                DateTime data = Convert.ToDateTime(linha["data_ganha"]);
                lblDataObtido.Text = "Obtida em " + data.ToString("dd/MM/yyyy");
                pnlConquista.CssClass = "conquista obtida";
            }
            else
            {
                lblDataObtido.Text = "Ainda não obtida";
                pnlConquista.CssClass = "conquista pendente";
            }
        }
    }
}