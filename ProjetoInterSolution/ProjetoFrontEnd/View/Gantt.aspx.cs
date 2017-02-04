using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoFrontEnd.View
{
    public partial class Gantt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            selecionaprojeto.Text = "<option  value =\"0\" selected='selected'>Choose the project</option>";
            if (Session["usuario"] is Cliente)
            {
                Cliente c = Session["usuario"] as Cliente;
                CronogramaModel cm = new CronogramaModel();
                foreach (Projeto p in cm.ListProjetosCliente(c.pessoa_id))
                {
                    selecionaprojeto.Text += "<option value=\"" + p.codigo + "\">" + p.nome + "</option>";
                }
            }
            else if (Session["usuario"] is Gerente)
            {
                Gerente g = Session["usuario"] as Gerente;
                CronogramaModel cm = new CronogramaModel();
                foreach (Projeto p in cm.ListProjetosGerente(g.pessoa_id))
                {
                    selecionaprojeto.Text += "<option value=\"" + p.codigo + "\">" + p.nome + "</option>";
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }
        }
    }
}