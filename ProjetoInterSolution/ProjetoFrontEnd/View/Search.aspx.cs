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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] is Cliente)
            {
                if (Request.Params["param"] != null)
                {
                    Cliente c = Session["usuario"] as Cliente;
                    ProjectModel pm = new ProjectModel();
                    List<Projeto> lp = pm.ListProjetosCliente(Request.Params["param"],c.pessoa_id);
                    if (lp.Count() != 0 && lp !=null)
                    {

                        projetos.Text = @"<table class='col-xs-5 table table-hover table-border'>";
                        foreach (Projeto p in lp)
                        {
                            projetos.Text += @"<tr>
                                             <td>" + p.nome + @"</td>                     
                                            <td>
                                                <button type='button' class='btn  btn-sm btn-primary open' onclick='Open(" + p.codigo + @");'>
                                                <span class='glyphicon glyphicon-folder-open'></span>
                                                </button>
                                           </td> 
                                         </tr>";

                        }
                        projetos.Text += @"</table>";
                    }
                    else
                    {
                        projetos.Text = "<center><h5>Nothing found<h5></center>";
                    }
            }
            }
                else if (Session["usuario"] is Gerente)
                {
                    if (Request.Params["param"] != null)
                    {
                        Gerente g = Session["usuario"] as Gerente;
                        ProjectModel pm = new ProjectModel();
                        List<Projeto> lp = pm.ListProjetosGerente(Request.Params["param"], g.pessoa_id);
                        if (lp.Count() != 0)
                        {

                            projetos.Text = @"<table class='col-xs-5 table table-hover table-border'>";
                            foreach (Projeto p in lp)
                            {
                                projetos.Text += @"<tr>
                                             <td>" + p.nome + @"</td>                     
                                            <td>
                                                <button type='button' class='btn  btn-sm btn-primary open' onclick='Open(" + p.codigo + @");'>
                                                <span class='glyphicon glyphicon-folder-open'></span>
                                                </button>
                                           </td> 
                                         </tr>";

                            }
                            projetos.Text += @"</table>";
                        }
                        else
                        {
                            projetos.Text = "<center><h5>Nothing found<h5></center>";
                        }
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
