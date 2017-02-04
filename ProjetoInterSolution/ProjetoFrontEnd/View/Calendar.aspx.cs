using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoInter.View
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is Cliente)
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }
            else if (Session["usuario"] is Gerente)
            {
                Pessoa p = Session["pessoa"] as Pessoa;
                idgerente.Value = ""+p.id;
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }
        }
    }
}