using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Views_Aluno_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        Response.Redirect("cadastro.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string msg = "";
        int contaErro = 0;
        string email = txtEmail.Text;
        string senha = txtSenha.Text;

        //Validação de campos obrigatórios
        if (email == "")
        {
            contaErro++;
            msg += "Campo 'E-mail' deve ser preenchido! <br>";
        }

        if (senha == "")
        {
            contaErro++;
            msg += "Campo 'Senha' deve ser preenchido! <br>";
        }

        // Se os campos estão vazios não procura no banco
        if (contaErro > 0)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = Color.IndianRed;
            lblMsg.Visible = true;
        }
        else
        {
            String codUsuario = null;
            String senhaAtual = null;

            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = strConexao.ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //  cmd.ExecuteNonQuery(); // ISSO aqui usa para oque não faz select, por exemplo INSERT, DELETE UPDATE
            //  cmd.ExecuteReader(); ou  cmd.ExecuteScalar(); // isso para query
            cmd.CommandText = "SELECT cod_usuario, senha FROM tbl_usuarios WHERE email = @email AND tipo_usuario = 'A'";
            // Evita SQL injection, o nome é Binding SQL;
            cmd.Parameters.AddWithValue("@email", email);
            //resultado do select dentro de reader
            //objeto responsável por ler, linha por linha, o resultado de uma consulta SQL feita ao banco de dados.
            SqlDataReader reader = cmd.ExecuteReader();

            // Usa if porque o retorno é sempre um único cliente não vários
            if (reader.Read())
            {
                // Pega e guarda o codCliente correspondente ao e-mail
                codUsuario = Convert.ToString(reader["cod_usuario"]);
                // Pega e guarda a senha correspondente ao e-mail
                senhaAtual = Convert.ToString(reader["senha"]);
            }

            conn.Close();

            // Se cliente ainda for null, então o e-mail não existe no banco
            if (codUsuario == null)
            {
                contaErro++;
                msg += "E-mail não encontrado. <br>";
            }
            else
            {
                if (senha != senhaAtual)
                {
                    contaErro++;
                    msg += "Senha incorreta. <br>";
                }
            }

            if (contaErro > 0)
            {
                lblMsg.Text = msg;
                lblMsg.ForeColor = Color.IndianRed;
                lblMsg.Visible = true;
            }
            else
            {
                // Se tudo der certo inicia sessão com o código do cliente
                Session["cod_usuario"] = codUsuario;
                Session["tipo_usuario"] = 'A';
                Response.Redirect("~/Views/Atividade/index.aspx");
            }
        }
    }
}