using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Atividade_atividade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cod_usuario"] == null)
        {
            Response.Redirect("~/Views/Aluno/login.aspx");
            return;
        }

        int cod_atividade;
        if (!int.TryParse(Request.QueryString["id"], out cod_atividade))
        {
            Response.Redirect("~/Views/Atividade/index.aspx");
            return;
        }

        if (!IsPostBack)
        {
            CarregarAtividade(cod_atividade);
        }
    }

    private void CarregarAtividade(int cod_atividade)
    {
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT a.cod_atividade, a.titulo, a.tipo_atividade, t.nome AS topico, d.nome AS dificuldade FROM tbl_atividades a INNER JOIN tbl_topicos t ON t.cod_topico = a.cod_topico INNER JOIN tbl_dificuldades d ON d.cod_dificuldade = a.cod_dificuldade WHERE a.cod_atividade = @cod_atividade;";
        cmd.Parameters.AddWithValue("@cod_atividade", cod_atividade);
        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabelaAtividade = new DataTable();
        tabelaAtividade.Load(reader);

        if (tabelaAtividade.Rows.Count == 0)
        {
            conn.Close();
            Response.Redirect("~/Views/Atividade/index.aspx");
            return;
        }

        DataRow atividade = tabelaAtividade.Rows[0];
        string tipo = atividade["tipo_atividade"].ToString();

        lblCodAtividade.Text = "Atividade " + atividade["cod_atividade"].ToString();
        lblTitulo.Text = atividade["titulo"].ToString();
        lblTopico.Text = "Tópico: " + atividade["topico"].ToString();
        lblTipo.Text = "Tipo: " + tipo;
        lblDificuldade.Text = "Dificuldade: " + atividade["dificuldade"].ToString();

        hdfTipo.Value = tipo;

        cmd.Parameters.Clear();
        cmd.CommandText = "SELECT q.cod_questao, q.pergunta, q.resposta, di.conteudo AS dica FROM tbl_questoes q LEFT JOIN tbl_dicas di ON di.cod_dica = q.cod_dica WHERE q.cod_atividade = @cod_atividade ORDER BY q.cod_questao ASC;";
        cmd.Parameters.AddWithValue("@cod_atividade", cod_atividade);
        reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(reader);

        conn.Close();

        rptQuestoes.DataSource = tabela;
        rptQuestoes.DataBind();

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptQuestoes.Items[i];

            HiddenField hdfCodQuestao = (HiddenField)item.FindControl("hdfCodQuestao");
            Label lblPergunta = (Label)item.FindControl("lblPergunta");
            Button btnDica = (Button)item.FindControl("btnDica");
            Label lblDica = (Label)item.FindControl("lblDica");

            hdfCodQuestao.Value = linha["cod_questao"].ToString();
            lblPergunta.Text = (i + 1).ToString() + ") " + linha["pergunta"].ToString();

            if (linha["dica"] != DBNull.Value)
            {
                lblDica.Text = "Dica: " + linha["dica"].ToString();
            }
            else
            {
                btnDica.Visible = false;
            }

            if (tipo == "Resposta escrita")
            {
                item.FindControl("pnlEscrita").Visible = true;
            }
            else if (tipo == "Verdadeiro/Falso")
            {
                item.FindControl("pnlVerdFalso").Visible = true;
            }
            else if (tipo == "Múltipla Escolha")
            {
                item.FindControl("pnlMultiplaE").Visible = true;

                string[] partes = linha["resposta"].ToString().Split(';');

                ((Button)item.FindControl("btnOp1")).Text = partes[1];
                ((Button)item.FindControl("btnOp2")).Text = partes[2];
                ((Button)item.FindControl("btnOp3")).Text = partes[3];
                ((Button)item.FindControl("btnOp4")).Text = partes[4];
            }
        }
    }

    protected void rptQuestoes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        RepeaterItem questao = e.Item;

        if (e.CommandName == "Dica")
        {
            Label lblDica = (Label)questao.FindControl("lblDica");
            lblDica.Visible = !lblDica.Visible;
        }
        else if (e.CommandName == "Selecionar")
        {
            string respostaEscolhida = e.CommandArgument.ToString();

            HiddenField hdfResposta = (HiddenField)questao.FindControl("hdfResposta");
            hdfResposta.Value = respostaEscolhida;

            Button btnOp1 = (Button)questao.FindControl("btnOp1");
            Button btnOp2 = (Button)questao.FindControl("btnOp2");
            Button btnOp3 = (Button)questao.FindControl("btnOp3");
            Button btnOp4 = (Button)questao.FindControl("btnOp4");
            Button btnVerdadeiro = (Button)questao.FindControl("btnVerdadeiro");
            Button btnFalso = (Button)questao.FindControl("btnFalso");

            btnOp1.CssClass = "opcao";
            btnOp2.CssClass = "opcao";
            btnOp3.CssClass = "opcao";
            btnOp4.CssClass = "opcao";
            btnVerdadeiro.CssClass = "opcao";
            btnFalso.CssClass = "opcao";

            Button botaoClicado = (Button)e.CommandSource;
            botaoClicado.CssClass = "opcao selecionado";
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        int cod_atividade = Convert.ToInt32(Request.QueryString["id"]);
        int cod_aluno = Convert.ToInt32(Session["cod_usuario"]);
        string tipo = hdfTipo.Value;

        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT cod_questao, resposta, xp_recompensa FROM tbl_questoes WHERE cod_atividade = @cod_atividade ORDER BY cod_questao ASC;";
        cmd.Parameters.AddWithValue("@cod_atividade", cod_atividade);
        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(reader);

        int acertos = 0;
        int pontos = 0;

        for (int i = 0; i < tabela.Rows.Count; i++)
        {
            DataRow linha = tabela.Rows[i];
            RepeaterItem item = rptQuestoes.Items[i];

            int cod_questao = Convert.ToInt32(linha["cod_questao"]);
            string respostaCerta = linha["resposta"].ToString();
            int xp = Convert.ToInt32(linha["xp_recompensa"]);

            string respostaAluno;
            if (tipo == "Resposta escrita")
            {
                respostaAluno = ((TextBox)item.FindControl("txtResposta")).Text;
            }
            else
            {
                respostaAluno = ((HiddenField)item.FindControl("hdfResposta")).Value;
            }

            bool acertou;
            if (tipo == "Múltipla Escolha")
            {
                if(respostaAluno == respostaCerta.Split(';')[0])
                {
                    acertou = true;
                }
                else
                {
                    acertou = false;
                }
            }
            else
            {
                if(respostaAluno.Trim().ToLower() == respostaCerta.Trim().ToLower())
                {
                    acertou = true;
                }
                else
                {
                    acertou = false;
                }
            }

            int xpGanho = 0;
            if (acertou)
            {
                acertos++;
                xpGanho = xp;
                pontos += xp;
            }

            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO tbl_submissoes (status, xp_ganho, cod_aluno, cod_questao) VALUES (@status, @xp_ganho, @cod_aluno, @cod_questao);";
            cmd.Parameters.AddWithValue("@status", acertou ? "Correta" : "Incorreta");
            cmd.Parameters.AddWithValue("@xp_ganho", xpGanho);
            cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
            cmd.Parameters.AddWithValue("@cod_questao", cod_questao);
            cmd.ExecuteNonQuery();
        }

        cmd.Parameters.Clear();
        cmd.CommandText = "UPDATE tbl_alunos SET xp_atual = xp_atual + @pontos, dt_ultima_atv = GETDATE() WHERE cod_aluno = @cod_aluno;";
        cmd.Parameters.AddWithValue("@pontos", pontos);
        cmd.Parameters.AddWithValue("@cod_aluno", cod_aluno);
        cmd.ExecuteNonQuery();

        conn.Close();

        lblMsg.Text = "Atividade enviada com sucesso!";
        lblAcertos.Text = "Você acertou " + acertos + " de " + tabela.Rows.Count + " questões.";
        lblPontos.Text = "Pontos ganhos: " + pontos + " XP";

        lblMsg.Visible = true;
        lblAcertos.Visible = true;
        lblPontos.Visible = true;
        pnlResultado.Visible = true;

        btnEnviar.Enabled = false;
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        int cod_atividade;
        if (!int.TryParse(Request.QueryString["id"], out cod_atividade))
        {
            Response.Redirect("~/Views/Atividade/index.aspx");
            return;
        }
        else {
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = strConexao.ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT cod_topico  FROM tbl_atividades WHERE cod_atividade LIKE @filtro;";
            cmd.Parameters.AddWithValue("@filtro", cod_atividade);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable tabela = new DataTable();
            tabela.Load(reader);

            if (tabela.Rows.Count == 0)
            {
                conn.Close();
                Response.Redirect("~/Views/Atividade/index.aspx");
                return;
            }

            DataRow atividade = tabela.Rows[0];
            string cod_topico = atividade["cod_topico"].ToString();

            conn.Close();
            Response.Redirect("~/Views/Atividade/atividadeTopico.aspx?id=" + cod_topico);
            return;
        }
    }

            
}