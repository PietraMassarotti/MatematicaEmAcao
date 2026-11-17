using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Atividade_atividadeTopico : System.Web.UI.Page
{
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int cod_topico;
        if (!int.TryParse(Request.QueryString["id"], out cod_topico))
        {
            Response.Redirect("~/Views/Atividade/index.aspx");
            return;
        }

        if (!IsPostBack)
        {
            CarregarAtividades(cod_topico, "");
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int cod_topico;
        if (!int.TryParse(Request.QueryString["id"], out cod_topico))
        {
            Response.Redirect("~/Views/Atividade/index.aspx");
            return;
        }

        CarregarAtividades(cod_topico, txtAtividade.Text.Trim());
    }

    private void CarregarAtividades(int cod_topico, string busca)
    {
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        DataTable tabela = new DataTable();

        using (SqlConnection conn = new SqlConnection(strConexao))
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;

            cmd.CommandText = "SELECT cod_atividade, titulo, tipo_atividade, cod_dificuldade FROM tbl_atividades WHERE cod_topico = @cod_topico AND (titulo LIKE @busca OR CAST(cod_atividade AS NVARCHAR(10)) = @codBusca)";
            cmd.Parameters.AddWithValue("@cod_topico", cod_topico);
            // "contém": digitar "soma" encontra "Somando pequenos números"
            cmd.Parameters.AddWithValue("@busca", "%" + busca + "%");
            // comparação exata com o código
            cmd.Parameters.AddWithValue("@codBusca", busca);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                tabela.Load(reader);
            }
        }

        rptAtividadeTopico.DataSource = tabela;
        rptAtividadeTopico.DataBind();

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptAtividadeTopico.Items[i];

            Label lblCod = (Label)item.FindControl("lblCod");
            Label lblTitulo = (Label)item.FindControl("lblTitulo");
            Label lblTipo = (Label)item.FindControl("lblTipo");
            Label lblDificuldade = (Label)item.FindControl("lblDificuldade");
            HyperLink lnkAtividade = (HyperLink)item.FindControl("lnkAtividade");

            int cod_atividade = Convert.ToInt32(linha["cod_atividade"]);

            lblCod.Text = linha["cod_atividade"].ToString();
            lblTitulo.Text = linha["titulo"].ToString();
            lblTipo.Text = linha["tipo_atividade"].ToString();
            lblDificuldade.Text = linha["cod_dificuldade"].ToString();
            //lnkAtividade.NavigateUrl = "~/Views/Atividade/atividade.aspx?id=" + cod_atividade;
        }

        lblSemResultado.Visible = (tabela.Rows.Count == 0);
    }
}
