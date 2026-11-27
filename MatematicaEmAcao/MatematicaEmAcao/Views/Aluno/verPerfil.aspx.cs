using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Aluno_verPerfil : System.Web.UI.Page
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
            CarregarPerfil();
        }
    }

    private void CarregarPerfil()
    {
        lblMsg.Text = "";

        int cod_usuario = Convert.ToInt32(Session["cod_usuario"]);

        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT nome, email, senha FROM tbl_usuarios WHERE cod_usuario = @cod_usuario;";
        cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);

        SqlDataReader reader = cmd.ExecuteReader();

        DataTable tabela = new DataTable();
        tabela.Load(reader);

        conn.Close();

        if (tabela.Rows.Count == 0)
        {
            lblMsg.Text = "Não foi possível encontrar os dados do usuário.";
            lblMsg.Visible = true;
            btnEditar.Enabled = false;
            return;
        }

        DataRow usuario = tabela.Rows[0];

        txtNome.Text = usuario["nome"].ToString();
        txtEmail.Text = usuario["email"].ToString();
        txtSenha.Text = usuario["senha"].ToString();
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int cod_usuario = Convert.ToInt32(Session["cod_usuario"]);

        string nome = txtNome.Text.Trim();
        string email = txtEmail.Text.Trim();
        string senha = txtSenha.Text.Trim();

        if (nome == "" || email == "" || senha == "")
        {
            lblMsg.Text = "Por favor preencha todos os campos!";
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = strConexao.ToString();
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT COUNT(*) FROM tbl_usuarios WHERE email = @email AND cod_usuario <> @cod_usuario;";
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);
        int emailEmUso = Convert.ToInt32(cmd.ExecuteScalar());

        if (emailEmUso > 0)
        {
            conn.Close();
            lblMsg.Text = "Erro: e-mail inválido.";
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
            return;
        }

        cmd.Parameters.Clear();
        cmd.CommandText = "UPDATE tbl_usuarios SET nome = @nome, email = @email, senha = @senha, update_at = GETDATE() WHERE cod_usuario = @cod_usuario;";
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@senha", senha);
        cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);
        cmd.ExecuteNonQuery();

        conn.Close();

        lblMsg.Text = "Perfil atualizado com sucesso!";
        lblMsg.ForeColor = Color.DarkOliveGreen;
        lblMsg.Visible = true;
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        CarregarPerfil();
    }
}