using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Atividade_atividadeTopico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cod_topico;
        // valida: existe e é um número? Como o cod de produto é passado na url, ele pode ser alterado por qualquer usuário, int.TryParse converte o valor da url e verfifica se é um número evitando que a página quebre
        if (!int.TryParse(Request.QueryString["id"], out cod_topico))
        {
            //se não é válido retorna para o catalogo
            Response.Redirect("~/Views/Atividade/index.aspx");
            //para o código aqui sem continuar, igual o break
            return;
        }
    }
}