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
    public partial class Activities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string atividadesdodia = "";
            ActivityModel am = new ActivityModel();
            Pessoa p = Session["pessoa"] as Pessoa;
            DateTime data = DateTime.Now;
            DateTime datadia = data.Date;
            foreach (Atividade a in am.ListAtividadesdodiaGerente(p.id))
            {
                if (a.data_termino > datadia)
                {
                    atividadesdodia += @"<li>
		                                    <span class='padding-10'>

			                                    <em class='badge padding-5 no-border-radius bg-color-red pull-left margin-right-5'>
				                                    <i class='fa fa-times fa-fw fa-2x'></i>
			                                    </em>
			
			                                    <span><b>Late: </b>
				                                     " + a.nome + @"
				                                     <br>
				                                     <span class='pull-right font-xs text-muted'><i>In the project: " + am.GetNomeProjetodaAtividade(a.numero) + @"</i></span>
			                                    </span>
			
		                                    </span>
	                                    </li>";
                }
                else
                {
                    atividadesdodia += @"<li>
		                                    <span class='padding-10'>

			                                    <em class='badge padding-5 no-border-radius bg-color-green pull-left margin-right-5'>
				                                    <i class='fa fa-check fa-fw fa-2x'></i>
			                                    </em>
			
			                                    <span><b>Regular: </b>
				                                     " + a.nome + @"
				                                     <br>
				                                     <span class='pull-right font-xs text-muted'><i>In the project: " + am.GetNomeProjetodaAtividade(a.numero) + @"</i></span>
			                                    </span>
			
		                                    </span>
	                                    </li>";
                }
            
            }

            activitiescontent.InnerHtml = atividadesdodia;
        }
    }
}