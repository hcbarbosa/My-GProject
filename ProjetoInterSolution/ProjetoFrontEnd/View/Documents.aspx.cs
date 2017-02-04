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
    public partial class Documents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            selecionaprojeto.Text = "<option  value =\"0\" selected='selected'>Choose the project</option>";
            if (Session["usuario"] is Cliente )
            {
                Cliente c = Session["usuario"] as Cliente;
                DocumentModel dm = new DocumentModel();
                foreach(Projeto p in dm.ListProjetosCliente(c.pessoa_id))
                {
                    selecionaprojeto.Text += "<option value=\"" + p.codigo + "\">" + p.nome + "</option>";
                }
            }
            else if (Session["usuario"] is Gerente)
            {
                Gerente g = Session["usuario"] as Gerente;
                DocumentModel dm = new DocumentModel();
                foreach (Projeto p in dm.ListProjetosGerente(g.pessoa_id))
                {
                    selecionaprojeto.Text += "<option value=\"" + p.codigo + "\">" + p.nome + "</option>";
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }

            if(Request.Params["projeto"]!=null)
            {
                int projeto = Int32.Parse(Request.Params["projeto"]);
                DocumentModel dm = new DocumentModel();
                List<Cronograma> cr = new List<Cronograma>();
                cr = dm.GetDocumentosProjeto(projeto);
                string arvore = @"<ul>
								<li>
									<span><i class='fa fa-lg fa-folder-open'></i>" + dm.GetNomeProjeto(projeto) + @"</span>
									<ul>";
                int auxfase = 0;
                string fs = "";
                foreach (Cronograma c in cr)
                {
                    fs = dm.GetNomeFase(c.fase_numero);
                    if (auxfase == 0)
                    {
                        arvore += @"<li>
											                    <span><i class='fa fa-lg fa-plus-circle'></i>" + fs + @"</span>
											                    <ul>";
                    }
                    else if (c.fase_numero != auxfase)
                    {

                        arvore += @"</ul>
                                                                </li>
                                                                <li>
											                    <span><i class='fa fa-lg fa-plus-circle'></i>" + fs + @"</span>
											                    <ul>";
                    }

                    arvore += @"     <li style='display:none'>
													                    <span><label onclick=" + "\"" + "ShowDocument('" + dm.GetDocumento(Int32.Parse((c.documento_numero).ToString())).local + "')\">" + dm.GetDocumento(Int32.Parse((c.documento_numero).ToString())).nome + @"</label> </span>
												                    </li>";

                    auxfase = c.fase_numero;
                }
                arvore += @"</ul>
										                    </li>
									                            </ul>
								                            </li>								
							                            </ul>";

                arvoreprojeto.Text = arvore;
            }
        }
               
    }
}