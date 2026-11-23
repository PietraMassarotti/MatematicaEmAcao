using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Atividade_index : System.Web.UI.Page
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
            CarregarTopicos("");
        }
    }
   
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CarregarTopicos(txtTopico.Text.Trim());
    }

    private void CarregarTopicos(string filtro)
    {
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT cod_topico, nome, ordem FROM tbl_topicos  WHERE nome LIKE @filtro ORDER BY ordem ASC;";
        cmd.Parameters.AddWithValue("@filtro","%" + filtro + "%");
        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();

        tabela.Load(reader);

        conn.Close();

        rptTopico.DataSource = tabela;
        rptTopico.DataBind();

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptTopico.Items[i];

            Label lblNome = (Label)item.FindControl("lblNome");
            HyperLink lnkTopico = (HyperLink)item.FindControl("lnkTopico");

            int cod_topico = Convert.ToInt32(linha["cod_topico"]);

            lblNome.Text = linha["nome"].ToString();
            lnkTopico.NavigateUrl = "~/Views/Atividade/atividadeTopico.aspx?id=" + cod_topico;
        }

        lblSemResultado.Visible = (tabela.Rows.Count == 0);
    }

}