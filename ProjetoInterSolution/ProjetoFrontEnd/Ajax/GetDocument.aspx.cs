using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Model;
using ProjetoBackEnd.Data;

namespace ProjetoFrontEnd.Ajax
{
    public partial class GetDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["projeto"] != null)
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
                string f = "";
                foreach (Cronograma c in cr)
                {   f = dm.GetNomeFase(c.fase_numero);
                    if (auxfase == 0)
                    {
                        arvore += @"<li>
											                    <span><i class='fa fa-lg fa-plus-circle'></i>" + f + @"</span>
											                    <ul>";
                    }
                    else if (c.fase_numero != auxfase)
                    {
                        
                        arvore += @"</ul>
                                                                </li>
                                                                <li>
											                    <span><i class='fa fa-lg fa-plus-circle'></i>" + f + @"</span>
											                    <ul>";
                    }

                    arvore += @"     <li style='display:none'>
													                    <span><label>" + dm.GetDocumento(Int32.Parse((c.documento_numero).ToString())).nome + @"</label> </span>
												                    </li>";

                    auxfase = c.fase_numero;
                }
                arvore += @"</ul>
										                    </li>
									                            </ul>
								                            </li>								
							                            </ul>";
                Response.Write("[{\"opcoes\":\"" + arvore + "\"}]");
            }
        }
    }
}