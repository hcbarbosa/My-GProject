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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is Cliente)
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }
            else if (Session["usuario"] is Gerente)
            {
                //Company
                CompanyModel cm = new CompanyModel();
                string conteudo = "";
                foreach (Pessoa p in cm.ListPessoasInat())
                {
                    conteudo += @"<tr role='row' class='odd'>
									<td class='sorting_1'>" + p.nome + @"</td>   
                                       <td id='" + p.id + @"'>
                                        <center>
                                        <button type='button'class='btn  btn-sm btn-success  activecompany' value='" + p.id + @"' >
                                        <span class='glyphicon glyphicon-repeat'></span>
                                        </button>
                                        </center>
                                       </td>
                                    </td>
								</tr>	";
                }
                listcompanies.Text = @"
            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->                                                                                                              
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='Name: activate to sort column ascending'>Name</th>                                   
                                    <!--view del-->          
                                    <th style='width: 95px;'>Reactivate</th>                                      
								</tr>
							</thead>
							<tbody><!--registros-->
											
                                " + conteudo + @"
							</tbody>
						</table> ";

                //Custumers
                CustomerModel cm1 = new CustomerModel();
                string conteudo1 = "";
                foreach (Pessoa p1 in cm1.ListPessoasInat())
                {
                    conteudo1 += @"<tr role='row' class='odd'>
									<td class='sorting_1'>" + p1.nome + @"</td>   
                                     <td id='" + p1.id + @"'>
                                        <center>
                                        <button type='button'class='btn  btn-sm btn-success  activecustomer' value='" + p1.id + @"'>
                                        <span class='glyphicon glyphicon-repeat'></span>
                                        </button>
                                        </center>
                                      </td>
                                    </td>
								</tr>	";
                }
                listcustomers.Text = @"
            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->                                                                                                              
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='Name: activate to sort column ascending'>Name</th>                                  
                                    <!--view del-->          
                                    <th style='width: 95px;'>Reactivate</th>                                       
								</tr>
							</thead>
							<tbody><!--registros-->											
                                " + conteudo1 + @"
							</tbody>
						</table> ";

                //Resources
                ResourceModel rm = new ResourceModel();
                string conteudo2 = "";
                foreach (Recurso r in rm.ListResourcesInat())
                {
                    conteudo2 += @"<tr   role='row' class='odd'>
									<td class='sorting_1'>" + r.descricao + @"</td>   
                                       <td id='" + r.id + @"'>
                                        <center>
                                        <button type='button'class='btn btn-sm btn-success  activeresource' value='" + r.id + @"'>
                                        <span class='glyphicon glyphicon-repeat'></span>
                                        </button>
                                        </center>
                                       </td>
                                    </td>
								</tr>	";
                }
                listresources.Text = @"
            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->                                                                                                              
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='Name: activate to sort column ascending'>Name</th>                                     
                                    <!--view del-->          
                                    <th style='width: 95px;'>Reactivate</th>                                       
								</tr>
							</thead>
							<tbody><!--registros-->											
                                " + conteudo2 + @"
							</tbody>
						</table> ";

                //Documents
                DocumentModel dm = new DocumentModel();
                string conteudo3 = "";
                foreach (Cronograma c in dm.GetDocInat())
                {
                    conteudo3 += @"<tr role='row' class='odd'>
									<td class='sorting_1'>" + c.Projeto.nome + @"</td> 
                                    <td class='sorting_1'>" + c.Fase.nome + @"</td>
                                    <td class='sorting_1'>" + c.Atividade.nome + @"</td>
                                    <td class='sorting_1'>" + c.Documento.nome + @"</td>                                               
                                      <td id='" + c.Documento.local + @"' >                        
                                        <center>
                                        <button type='button'  class='btn  btn-sm btn-success  activedocument' value='" + c.Documento.local + @"'>
                                        <span class='glyphicon glyphicon-repeat'></span>
                                        </button>
                                        </center>
                                      </td>
								</tr>	";
                }
                listdocuments.Text = @"
            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->                                                                                                              
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='ProjectName: activate to sort column ascending'>Project`s Name</th>
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='StepName: activate to sort column ascending'>Step`s Name</th>
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='ActivityName: activate to sort column ascending'>Activity`s Name</th>
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='DocumentName: activate to sort column ascending'>Document`s Name</th>                                    
                                    <!--view del-->        
                                    <th style='width: 95px;'>Reactivate</th>                                      
								</tr>
							</thead>
							<tbody><!--registros-->											
                                " + conteudo3 + @"
							</tbody>
						</table> ";



            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }
        }
    }
}












