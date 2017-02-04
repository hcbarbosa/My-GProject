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
    public partial class Table : System.Web.UI.Page
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

            if (Request.Params["projeto"] != null)
            {
                nada.Visible = false;
                int projeto = Int32.Parse(Request.Params["projeto"]);
                string conteudo = "";
                StepModel sd = new StepModel();
                ActivityModel ad = new ActivityModel();
                CronogramaRecursoModel crm = new CronogramaRecursoModel();
                ResourceModel rm = new ResourceModel();
                int ordernador = 0;
                decimal totalat = 0;
                foreach (Fase f in sd.listFases(projeto))
                {
                    ordernador++;
                    conteudo += @" <tr role='row' class='odd'>
                                    <td>" + ordernador + @"</td>
									<td><b>" +f.nome+@"<b></td>
                                    <td>" + (f.data_inicio).ToString().Substring(0, 10) + @"</td>
									<td>" + (f.data_termino).ToString().Substring(0, 10) + @"</td>
                                    <td>" + ad.GetCustoFase(f.numero) + @"</td>
									<td>" + f.porc_completo + @"</td>
								</tr>";
                    foreach (Atividade a in ad.GetAtividadesFase(f.numero))
                    {
                        totalat = crm.GetTotalAt(a.numero);
                        ordernador++;
                        if(totalat == 0)
                        {
                            conteudo += @" <tr role='row' class='odd'>
                                    <td>" + ordernador + @"</td>
									<td>" + a.nome + @"</td>
                                    <td>" + (a.data_inicio).ToString().Substring(0, 10) + @"</td>
									<td>" + (a.data_termino).ToString().Substring(0, 10) + @"</td>
                                    <td><center>----<center></td>
									<td>" + a.porc_completo + @"</td>
								</tr>"; 
                        }
                        else
                        {
                        conteudo += @" <tr role='row' class='odd'>
                                    <td>" + ordernador + @"</td>
									<td >" +a.nome + @"</td>
                                    <td>" +(a.data_inicio).ToString().Substring(0,10) + @"</td>
									<td>" + (a.data_termino).ToString().Substring(0, 10) + @"</td>
                                    <td>" + totalat + @"</td>
									<td>" +a.porc_completo + @"</td>
								</tr>"; 
                        }
                        totalat = 0;
                    }
                }


                ProjectModel pm = new ProjectModel();
                Projeto pro = pm.GetProjeto(projeto);

                tabelacron.Text = @"<table id='tableproject' class='table  table-bordered table-hover'   style='width:100%;align-items:center;'>
							<thead>
								<tr>
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Order: activate to sort column ascending' style='width: 50px;'>Order</th> 
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Project-"+pro.nome+@": activate to sort column ascending' style='width: 452px;'>Project-"+pro.nome+@"</th> 
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Start date: activate to sort column ascending' style='width: 128px;'>Start date</th>                                   
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Expiry date: activate to sort column ascending' style='width: 128px;'>Expiry date</th>
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Cost: activate to sort column ascending' style='width: 181px;'>Cost:" + pro.valor_utilizado + @"</th>
                                    <th data-hide='phone' class='sorting_asc' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-sort='ascending' aria-label='Percentage: activate to sort column ascending' style='width: 110px;'>Percentage</th>                                    
								</tr>
							</thead>
							<tbody>"
                            + conteudo + @"       
                               
							</tbody>
						</table>";
            }
        }
    }
}