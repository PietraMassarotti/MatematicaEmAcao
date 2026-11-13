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
        // Conecta ao banco de dados e busca os produtos
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT cod_topico, nome, ordem FROM tbl_topicos  WHERE nome LIKE @filtro ORDER BY ordem ASC;";
        cmd.Parameters.AddWithValue("@filtro","%" + filtro + "%");
        //resultado do select dentro de reader
        //objeto responsável por ler, linha por linha, o resultado de uma consulta SQL feita ao banco de dados.
        SqlDataReader reader = cmd.ExecuteReader();

        //uma estrutura de dados que representa uma tabela na memória (linhas e colunas), parecida com uma planilha.
        DataTable tabela = new DataTable();

        //percorre o reader inteiro automaticamente e guarda tudo dentro da tabela
        tabela.Load(reader);

        conn.Close();

        // Liga a tabela ao Repeater e desenha um item vazio para cada linha
        //diz ao Repeater "essa é a fonte de dados que você vai usar".
        rptTopico.DataSource = tabela;
        rptTopico.DataBind();

        // Agora percorre os itens ja criados e preenche cada um
        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            //Pega a linha i da tabela, ou seja, os dados de um pedido específico (todas as colunas daquela linha).
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptTopico.Items[i];

            Label lblNome = (Label)item.FindControl("lblNome");
            HyperLink lnkTopico = (HyperLink)item.FindControl("lnkTopico");

            int cod_topico = Convert.ToInt32(linha["cod_topico"]);

            //Preenche cada label com o valor correspondente daquela linha:
            lblNome.Text = linha["nome"].ToString();
            //Passa código atráves do link da página
            lnkTopico.NavigateUrl = "~/Views/Atividade/atividadeTopico.aspx?id=" + cod_topico;
        }

        //Se não encontrar nenhuma linha, exibi mensagem de nada encontrado.
        lblSemResultado.Visible = (tabela.Rows.Count == 0);
    }

}