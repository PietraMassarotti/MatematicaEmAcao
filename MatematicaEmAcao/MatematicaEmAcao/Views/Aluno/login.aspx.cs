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
        string email = txtEmail.Text;
        string senha = txtSenha.Text;

        if (email == "" || senha == "")
        {
            msg += "Por Favor preencha todos os campos!";
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
            cmd.CommandText = "SELECT cod_usuario, senha FROM tbl_usuarios WHERE email = @email AND tipo_usuario = 'A'";
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                codUsuario = Convert.ToString(reader["cod_usuario"]);
                senhaAtual = Convert.ToString(reader["senha"]);
            }

            conn.Close();

            int contaErro = 0;

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
                Session["cod_usuario"] = codUsuario;
                Session["tipo_usuario"] = 'A';
                Response.Redirect("~/Views/Atividade/index.aspx");
            }
        }
    }
}