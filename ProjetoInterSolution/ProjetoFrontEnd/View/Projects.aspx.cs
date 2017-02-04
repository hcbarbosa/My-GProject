using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;
using System.Data;

namespace ProjetoInter.View
{
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is Cliente )
            {
                Cliente c = Session["usuario"] as Cliente;
                string conteudo = "";
                string statusproject = "";
                ProjectModel pm = new ProjectModel();
                foreach (Projeto p in pm.ListProjetosCliente(c.pessoa_id))
                {
                    switch (p.status)
                    {
                        case 0: statusproject = "Canceled";                         
                            break;
                        case 1: statusproject = "In progress";
                            break;
                        case 2: statusproject = "Model";
                            break;
                        case 3: statusproject = "Completed";
                             break;
                    }

                    conteudo += @"           <tr role='row' class='odd'>
                                        <td class='sorting_1'>" + p.codigo + @"</td>
									    <td><span class='responsiveExpander'></span>" + p.nome + @"</td>
									    <td>" + pm.GetEmpresaProjeto(p.codigo) + @"</td>
									    <td>" + (p.data_inicio).ToString("dd/MM/yyyy") + @"</td> 
									    <td>" + (p.data_termino).ToString("dd/MM/yyyy") + @"</td>
									    <td>" + p.porc_completo + "%" + @"</td>
                                         <td>" + statusproject + @"</td>
                                         <td>
                                            <button type='button' class='btn  btn-sm btn-primary open' onclick='Open(" + p.codigo + @");'>
                                            <span class='glyphicon glyphicon-folder-open'></span>
                                            </button>
                                        </td> 
								    </tr>";
                }

                ListProjects.Text = @"<table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->
                                     <th data-hide='phone' class='sorting_asc' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-sort='ascending' aria-label='Code: activate to sort column ascending' style='width: 31px;'>Code</th>
                                     <th data-hide='Hour' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Name: activate to sort column ascending' style='width: 324px;'>Name</th>
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Company: activate to sort column ascending' style='width: 128px;'>Company</th>                                   
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Start Date: activate to sort column ascending' style='width: 181px;'>Start Date</th>   
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Expiry Date: activate to sort column ascending' style='width: 128px;'>Expiry Date</th>             
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Percentage: activate to sort column ascending' style='width: 75px;'>Percentage</th>          
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Status: activate to sort column ascending' style='width: 75px;'>Status</th>  
                                      <!--view del-->
                                    <th style='width: 40px'>View</th>  
								</tr>
							</thead>
							<tbody>"
                                 + conteudo +
                                @"</tbody>
						</table>";

            }
            else if(Session["usuario"] is Gerente)
            {

                botaonew.Text = @"<div class='col-xs-offset-11 col-xs-1'>              
                                      <div class='btn-header transparent pull-right'>                 
                                            <input type='button' class='btn btn-success' id='new' value='New'/>                    
                                      </div>
                                     </div>";

            Gerente g = Session["usuario"] as Gerente;
            string acao = "";
            string conteudo = "";
            string statusproject = "";
            ProjectModel pm = new ProjectModel();
            foreach (Projeto p in pm.ListProjetosGerente(g.pessoa_id))
            {
                switch (p.status)
                {
                    case 0: statusproject = "Canceled";
                        acao = @"<td>
                                 <button type='button' class='btn  btn-sm btn-success' title='Are you want reactivate the project?' onclick='AtivarProject(" + p.codigo + ",\"" + p.nome + @""");'>
                                 <span class='glyphicon glyphicon-repeat'></span>
                                 </button>
                                 </td> ";       
                        break;
                    case 1: statusproject = "In progress"; 
                        acao = @"<td>
                                 <button type='button' class='btn  btn-sm btn-danger delete' title='Are you want cancel the project?' onclick='DeleteProject(" + p.codigo + ",\"" + p.nome + @""");'>
                                 <span class='glyphicon glyphicon-remove'></span>
                                 </button>
                                 </td> ";
                        break;
                    case 2: statusproject = "Model";
                        acao = @"<td>
                                 <button type='button' class='btn  btn-sm ' onclick='btnViewModel(" + p.codigo + @")' title='The project is a model'>
                                 <span class='glyphicon glyphicon-book'></span>
                                 </button>
                                 </td> ";
                        break;
                    case 3: statusproject = "Completed";
                        acao = @"<td>
                                 <button type='button' class='btn  btn-sm ' disabled title='The project is completed' >
                                 <span class='glyphicon glyphicon-ok'></span>
                                 </button>
                                 </td> ";
                        break;
                }

                


                conteudo += @"           <tr role='row' class='odd'>
                                        <td class='sorting_1'>" + p.codigo + @"</td>
									    <td><span class='responsiveExpander'></span>" + p.nome + @"</td>
									    <td>" + pm.GetEmpresaProjeto(p.codigo) + @"</td>
									    <td>" + (p.data_inicio).ToString("dd/MM/yyyy") + @"</td> 
									    <td>" + (p.data_termino).ToString("dd/MM/yyyy") + @"</td>
									    <td>" + p.porc_completo + "%" + @"</td>
                                         <td>" + statusproject + @"</td>
                                         <td>
                                            <button type='button' class='btn  btn-sm btn-primary open' onclick='Open(" + p.codigo + @");'>
                                            <span class='glyphicon glyphicon-folder-open'></span>
                                            </button>
                                        </td>                                     
                                         "+ acao + @"
								    </tr>";
            }

            ListProjects.Text = @"<table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->
                                     <th data-hide='phone' class='sorting_asc' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-sort='ascending' aria-label='Code: activate to sort column ascending' style='width: 31px;'>Code</th>
                                     <th data-hide='Hour' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Name: activate to sort column ascending' style='width: 324px;'>Name</th>
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Company: activate to sort column ascending' style='width: 128px;'>Company</th>                                   
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Start Date: activate to sort column ascending' style='width: 181px;'>Start Date</th>   
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Expiry Date: activate to sort column ascending' style='width: 128px;'>Expiry Date</th>             
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Percentage: activate to sort column ascending' style='width: 75px;'>Percentage</th>          
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Status: activate to sort column ascending' style='width: 75px;'>Status</th>  
                                      <!--view del-->
                                    <th style='width: 40px'>View</th>           
                                    <th style='width: 40px'>Action</th>   
                                    
								</tr>
							</thead>
							<tbody>"
                             + conteudo +
                            @"</tbody>
						</table>";
                if(!IsPostBack){
                ProjectModel pmo = new ProjectModel();
                pmo.RotinaLimpar();
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }

            if (Request.Params["ok"] != null)
            {
                if (Request.Params["ok"] == "register")
                {
                    string script = @"             $.smallBox({
                                                   title: 'Project',
                                                   content: '<i>Registered with success...</i>',
                                                   color: 'green',
                                                   iconSmall: 'fa fa-thumbs-up bounce animated',
                                                   timeout: 4000
                                               });
                                            ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }
           
        }

        protected void confirm_Click(object sender, EventArgs e)
        {        
            try
            {
                Projeto p = new Projeto();
                ProjectModel pm = new ProjectModel();
                p.nome = Request.Params["name"];
                p.data_inicio = DateTime.Parse(Request.Params["startdate"]);
                p.data_termino = DateTime.Parse(Request.Params["finishdate"]);
                p.valor_previsto = decimal.Parse(Request.Params["valuetotal"]);
                if (Request.Params["model"] != null)
                {
                    p.modelo_numero = Int32.Parse(Request.Params["model"]);    
                }
                Gerente g = Session["usuario"] as Gerente;
                p.gerente_id = g.pessoa_id;
                p.porc_completo = 0;
                p.status = 1;
                p.valor_utilizado = 0;
               
                //para depois inserir 
                int company = Int32.Parse(Request.Params["company"]);                
                //captura valores do clientes
                string[] clientes = Request.Form["customers[]"].Split(',');
                //captura valores das fases
                string[] steps = Request.Form["steps[]"].Split(',');

                DataTable dt = new DataTable();
                dt.Columns.Add("step", typeof(string));
                dt.Columns.Add("activity", typeof(string));               

                for (int i = 0; i < steps.Length; i++) 
                {
                    if (Request.Form["" + steps[i] + "_activity[]"] != null)
                    {
                        string[] act = Request.Form["" + steps[i] + "_activity[]"].Split(',');
                        for (int x = 0; x < act.Length; x++)
                        {
                            dt.Rows.Add(new object[] {Int32.Parse(steps[i]), Int32.Parse(act[x]) });                        
                        }
                    }                
                }
                pm.Insert(p,company,clientes,dt);
                Response.Redirect("Index.aspx#Projects.aspx?ok=register", false);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}