using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Aluno_cadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        string msgErro = "";

        lblMsg.Visible = false;

       
        if (txtNome.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtSenha.Text == "")
        {
            msgErro += "Por favor preencha todos os campos!";
            lblMsg.Text = msgErro;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        }
        else
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConexao))
                {
                    conn.Open();

                    SqlCommand cmdVerifica = new SqlCommand("SELECT COUNT(*) FROM tbl_usuarios WHERE email = @email",conn);
                    cmdVerifica.Parameters.AddWithValue("@email",txtEmail.Text.Trim());

                    int emailExiste = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                    if (emailExiste > 0)
                    {
                        lblMsg.Text = "Erro: Este e-mail já está cadastrado.";
                        lblMsg.ForeColor = Color.IndianRed;
                        lblMsg.Visible = true;
                        return;
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "INSERT INTO tbl_usuarios (nome, email, senha, tipo_usuario) VALUES (@nome, @email, @senha, 'A')";
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro ao cadastrar aluno: " + ex.Message;
                lblMsg.ForeColor = Color.IndianRed;
                lblMsg.Visible = true;
                return;
            }

            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;

            lblMsg.Text = "Cadastro realizado com sucesso! :)";
            lblMsg.ForeColor = Color.DarkOliveGreen;
            lblMsg.Visible = true;
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}