using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Model;
using ProjetoBackEnd.Data;

namespace ProjetoInter.View
{
    public partial class Resources : System.Web.UI.Page
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
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }

            if (Request.Params["ok"] != null)
            {
                if (Request.Params["ok"] == "edit")
                {
                    string script = @"             $.smallBox({
                                                   title: 'Resource',
                                                   content: '<i>Edited with success...</i>',
                                                   color: '#e29a06',
                                                   iconSmall: 'fa fa-thumbs-up bounce animated',
                                                   timeout: 4000
                                               });
                                            ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                else if(Request.Params["ok"] == "register")
                {
                    string script = @"             $.smallBox({
                                                   title: 'Resource',
                                                   content: '<i>Registered with success...</i>',
                                                   color: 'green',
                                                   iconSmall: 'fa fa-thumbs-up bounce animated',
                                                   timeout: 4000
                                               });
                                            ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }


            TypeModel tms = new TypeModel();
            string seleciona = "<option></option>";
            foreach (Tipo t in tms.ListTipos())
            {
                seleciona += @"<option value='" + t.id + @"'>" + t.descricao + @"</option>";

            }
            tipos.Text = seleciona;

            if (!IsPostBack)
            {
                if (Request.Params["idRecurso"] != null)
                {

                    try
                    {
                        ResourceModel rm = new ResourceModel();
                        TypeModel tm = new TypeModel();
                        Recurso r = new Recurso();

                        r.id = Int32.Parse(Request.Params["idRecurso"]);
                        r.descricao = Request.Params["description"];
                        r.valor = Decimal.Parse(Request.Params["value"]);
                        r.tipo_id = Int32.Parse(Request.Params["idtype"]);
                        switch (tm.GetTipo(r.tipo_id).descricao)
                        {

                            case "Material":
                                r.qtd_unid_disponivel = Decimal.Parse(Request.Params["unidade"]);
                                break;

                            case "Human":
                                r.qtd_hora_disponivel = TimeSpan.Parse(Request.Params["hora"]);
                                break;
                        }
                       
                        rm.Update(r);
                        Response.Redirect("Index.aspx#Resources.aspx?ok=edit", false);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
                else
                {                    
                    
                    ResourceModel rm = new ResourceModel();
                    string conteudo = null;
                    TypeModel tm = new TypeModel();

                    foreach (Recurso r in rm.ListResources())
                    {
                        string qtd = null;

                        switch (r.tipo_id)
                        {
                            case 1:
                                qtd = (r.qtd_hora_disponivel.ToString()).Substring(0, 5) + " hr.";
                                break;
                            case 2:
                                qtd = r.qtd_unid_disponivel.ToString() + " unid.";
                                break;

                        }



                        conteudo += @"<tr role='row' class='odd'>
									<td class='sorting_1'>" + r.descricao + @"</td>
									<td>" + tm.GetTipo(r.tipo_id).descricao + @"</td> 
                                    <td>" + qtd + @"</td>     
                                     <td>
                                        <button type='button'class='btn  btn-sm btn-primary  view' onclick='EditResource(" + r.id + "," + r.tipo_id + @");'>
                                        <span class='glyphicon glyphicon-eye-open'></span>
                                        </button>
                                    </td>
                                    <td>
                                        <button type='button'class='btn  btn-sm btn-danger delete' onclick='DeleteResource(" + r.id + "," + r.tipo_id + ",\""+ r.descricao+ @""");'>
                                        <span class='glyphicon glyphicon-remove'></span>
                                        </button>
                                    </td> 
								</tr>	";

                    }

                    ListResources.Text = @"
            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->                                                                                                              
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='Name: activate to sort column ascending'>Name</th>
                                     <th data-hide='phone'class='sorting'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-label='Type: activate to sort column ascending'>Type</th>
                                     <th data-hide='hours'class='sorting'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-label='Hours Used/Total: activate to sort column ascending'>Quantity</th>
                                     
                                    <!--view del-->
                                    <th style='width: 40px;'>View</th>           
                                    <th style='width: 40px;'>Delete</th>   
                                    
								</tr>
							</thead>
							<tbody><!--registros-->
											
                                " + conteudo + @"
							</tbody>
						</table> ";                    
                }

            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {

            try
            {
                ResourceModel rm = new ResourceModel();
                TypeModel tm = new TypeModel();
                Recurso r = new Recurso();
                r.tipo_id = Int32.Parse(Request.Params["type"]);
                r.descricao = Request.Params["description"];
                switch (tm.GetTipo(r.tipo_id).descricao)
                {

                    case "Material":
                        r.qtd_unid_disponivel = Decimal.Parse(Request.Params["unidade"]);
                        break;

                    case "Human":
                        r.qtd_hora_disponivel = TimeSpan.Parse(Request.Params["hora"]);
                        break;
                }

                r.valor = Decimal.Parse(Request.Params["value"]);

                rm.Insert(r);
                Response.Redirect("Index.aspx#Resources.aspx?ok=register", false);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
       
