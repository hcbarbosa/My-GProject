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
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string notificacoes = "";

            Pessoa p = Session["pessoa"] as Pessoa;
            NotificationModel nm = new NotificationModel();
            ProjectModel pm = new ProjectModel();
            foreach (Notificacoe n in nm.listNot(p.id))
            {
                //status 1 nao leu ainda
                if (n.status == 1)
                {
                    notificacoes += @"<li>
		                            <span class='padding-10 unread'>

			                            <em class='badge padding-5 no-border-radius bg-color-blueLight pull-left margin-right-5'>
				                            <i class='fa fa-user fa-fw fa-2x'></i>
			                            </em>
			
			                            <span>
				                             " + n.informacao + @"
				                             <br/>
				                             <span class='pull-right font-xs text-muted'><i>In the project: " + pm.GetProjeto(n.projeto_codigo).nome + @"...</i></span>
			                            </span>
			
		                            </span>
	                            </li>";
                }
                else
                {
                    notificacoes += @"<li>
		                            <span class='padding-10 read'>

			                            <em class='badge padding-5 no-border-radius bg-color-blueLight pull-left margin-right-5'>
				                            <i class='fa fa-user fa-fw fa-2x'></i>
			                            </em>
			
			                            <span>
				                             " + n.informacao + @"
				                             <br/>
				                             <span class='pull-right font-xs text-muted'><i>In the project: " + pm.GetProjeto(n.projeto_codigo).nome + @"...</i></span>
			                            </span>
			
		                            </span>
	                            </li>";
                }
            }
            nm.ViuNotificacoes(p.id);
            notificacoescontent.InnerHtml = notificacoes;
        }
    }
}