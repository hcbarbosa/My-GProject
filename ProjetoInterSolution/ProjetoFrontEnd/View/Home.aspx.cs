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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is Cliente )
            {
                string conteudo = "";
                ProjectModel pm = new ProjectModel();
                Cliente c = Session["usuario"] as Cliente;
                foreach (Projeto p in pm.ListProjetosCliente(c.pessoa_id))
                {
                    if (p.status == 1)
                    {
                        if(p.data_termino < DateTime.Now)
                        {
                            conteudo += p.nome +
                                @"<div class='progress'>
    		                <div class='progress-bar bg-color-red' aria-valuetransitiongoal='" + Convert.ToInt32(p.porc_completo) + @"'></div>
			            </div>	  
                        <br />";
                        }
                        else{
                            conteudo += p.nome +
                                @"<div class='progress'>
    		                <div class='progress-bar bg-color-green' aria-valuetransitiongoal='" + Convert.ToInt32(p.porc_completo) + @"'></div>
			            </div>	  
                        <br />";
                        }
                    }
                }
                listprojects.Text = conteudo +"       <br /><br />";
                ActivityModel am = new ActivityModel();
                foreach (Atividade a in am.ListAtividadesdodiaCliente(c.pessoa_id))
                {
                    atividadesdodia.Text += @"<tr> <td> """ + a.nome + @""" in the project <b>" + am.GetNomeProjetodaAtividade(a.numero) + @"</b>. </td> </tr>";
                }
            }
            else if(Session["usuario"] is Gerente)
            {
                string conteudo = "";
                ProjectModel pm = new ProjectModel();
                Gerente g = Session["usuario"] as Gerente;
                foreach (Projeto p in pm.ListProjetosGerente(g.pessoa_id))
                {
                    if (p.status == 1)
                    {
                        if (p.data_termino < DateTime.Now)
                        {
                            conteudo += p.nome +
                                @"<div class='progress'>
    		                <div class='progress-bar bg-color-red' aria-valuetransitiongoal='" + Convert.ToInt32(p.porc_completo) + @"'></div>
			            </div>	  
                        <br />";
                        }
                        else
                        {
                            conteudo += p.nome +
                                @"<div class='progress'>
    		                <div class='progress-bar bg-color-green' aria-valuetransitiongoal='" + Convert.ToInt32(p.porc_completo) + @"'></div>
			            </div>	  
                        <br />";
                        }
                    }
                }
                listprojects.Text = conteudo + "       <br /><br />  <br /><br />";
                ActivityModel am = new ActivityModel();
                foreach (Atividade a in am.ListAtividadesdodiaGerente(g.pessoa_id))
                {
                    atividadesdodia.Text += @"<tr> <td> """ + a.nome + @""" in the project <b>" + am.GetNomeProjetodaAtividade(a.numero) + @"</b>. </td> </tr>";
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