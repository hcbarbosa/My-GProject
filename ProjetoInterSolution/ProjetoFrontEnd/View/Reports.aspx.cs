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
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            selecionaprojeto.Text = "<option  value =\"0\" selected='selected'>Choose the project</option>";
            if (Session["usuario"] is Cliente)
            {
                Cliente c = Session["usuario"] as Cliente;
                ReportModel rm = new ReportModel();
                foreach (Projeto p in rm.ListProjetosCliente(c.pessoa_id))
                {
                    selecionaprojeto.Text += "<option value=\"" + p.codigo + "\">" + p.nome + "</option>";
                }
            }
            else if (Session["usuario"] is Gerente)
            {
                Gerente g = Session["usuario"] as Gerente;
                ReportModel rm = new ReportModel();
                foreach (Projeto p in rm.ListProjetosGerente(g.pessoa_id))
                {
                    selecionaprojeto.Text += "<option value=\"" + p.codigo + "\">" + p.nome + "</option>";
                }
            }

            
        }
    }
}