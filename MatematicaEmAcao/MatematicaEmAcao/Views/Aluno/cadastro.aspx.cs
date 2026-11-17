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
        string strConexao = ConfigurationManager
            .ConnectionStrings["ConnectionString"].ConnectionString;

        // inicializa o contador de erros e a mensagem de erro
        int contaErro = 0;
        string msgErro = "";

        lblMsg.Visible = false;

        if (txtNome.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ser preenchido!<br>";
        }

        if (txtEmail.Text.Trim() == "")
        {
            contaErro++;
            msgErro += "Campo 'E-mail' deve ser preenchido!<br>";
        }

        if (txtSenha.Text == "")
        {
            contaErro++;
            msgErro += "Campo 'Senha' deve ser preenchido!<br>";
        }

        //Validação básica de dados, se o tamanho do input for maior que o aceito pelo banco impede o cadastro
        if (txtNome.Text.Length > 150)
        {
            contaErro++;
            msgErro += "Campo 'Nome' deve ter no máximo 150 caracteres!<br>";
        }

        if (txtEmail.Text.Length > 150)
        {
            contaErro++;
            msgErro += "Campo 'E-mail' deve ter no máximo 150 caracteres!<br>";
        }

        if (txtSenha.Text.Length > 30)
        {
            contaErro++;
            msgErro += "Campo 'Senha' deve ter no máximo 30 caracteres!<br>";
        }

        // se algum campo estiver vazio alertará o usuário,
        // caso contrário insere os dados no banco
        if (contaErro > 0)
        {
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
                    // abre a conexão com o banco de dados
                    conn.Open();

                    // verifica se o e-mail já está cadastrado
                    SqlCommand cmdVerifica = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_usuarios WHERE email = @email",
                        conn);

                    cmdVerifica.Parameters.AddWithValue(
                        "@email",
                        txtEmail.Text.Trim());

                    int emailExiste = Convert.ToInt32(
                        cmdVerifica.ExecuteScalar());

                    if (emailExiste > 0)
                    {
                        lblMsg.Text = "Este e-mail já está cadastrado!";
                        lblMsg.ForeColor = Color.IndianRed;
                        lblMsg.Visible = true;
                        return;
                    }

                    // cria o comando para inserir o administrador
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    // tenta inserir os dados do administrador no banco de dados
                    cmd.CommandText = "INSERT INTO tbl_usuarios " +
                        "(nome, email, senha, tipo_usuario) VALUES " +
                        "(@nome, @email, @senha, 'A')";

                    // adiciona os parâmetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // caso ocorra algum erro ao inserir os dados no banco,
                // exibe o que causou o erro
                lblMsg.Text = "Erro ao cadastrar aluno: " + ex.Message;
                lblMsg.ForeColor = Color.IndianRed;
                lblMsg.Visible = true;
                return;
            }

            // limpa os campos do formulário e exibe a mensagem de sucesso
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