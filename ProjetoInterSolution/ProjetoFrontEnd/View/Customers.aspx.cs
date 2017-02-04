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
    public partial class Customers : System.Web.UI.Page
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
                                                   title: 'Customer',
                                                   content: '<i>Edited with success...</i>',
                                                   color: '#e29a06',
                                                   iconSmall: 'fa fa-thumbs-up bounce animated',
                                                   timeout: 4000
                                               });
                                            ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
                else if (Request.Params["ok"] == "register")
                {
                    string script = @"             $.smallBox({
                                                   title: 'Customer',
                                                   content: '<i>Registered with success...</i>',
                                                   color: 'green',
                                                   iconSmall: 'fa fa-thumbs-up bounce animated',
                                                   timeout: 4000
                                               });
                                            ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", script, true);
                }
            }

            PeopleModel pm = new PeopleModel();
            List<Estado> estados = new List<Estado>();
            estados = pm.ListEstados();
            string conteudoestado = "<option selected='selected' disabled='disabled'>Choose the State</option>";
            foreach (Estado es in estados)
            {
                conteudoestado += @"<option value='" + es.sigla + @"'>" + es.nome + @"</option>";
            }

            selecionaestado.Text = conteudoestado;

            if (Request.Params["id"] != null)
            {
                CompanyModel com = new CompanyModel();
                List<Pessoa> empresas = new List<Pessoa>();
                empresas = com.ListPessoas();
                string conteudoempresa = null;
                foreach (Pessoa em in empresas)
                {
                    conteudoempresa += @"<option value='" + em.id + @"'>" + em.nome + @"</option>";
                }

                selecionaempresas.Text = conteudoempresa;
                string ids = Request.Params["id"];
                int id = Int32.Parse(ids);
                CustomerModel cum = new CustomerModel();
                string conteudo = @"<table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr>
                                     <th data-hide='phone' class='sorting_asc' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-sort='ascending' aria-label='Id: activate to sort column ascending' style='width: 31px;'>Id</th>
                                     <th data-hide='Hour' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Name: activate to sort column ascending' style='width: 324px;'>Name</th>
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Company: activate to sort column ascending' style='width: 128px;'>Company</th>                                   
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Default Email : activate to sort column ascending' style='width: 181px;'>Default Email </th>   
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Default Phone : activate to sort column ascending' style='width: 128px;'>Default Phone </th>             
                                   
                                    <th style='width: 40px;'>View</th>           
                                    <th style='width: 40px;'>Delete</th> 
                                    
								</tr>
							</thead>
							<tbody>";
                List<Pessoa> lista = cum.GetPessoas(id);
                string empresascliente = "";
                foreach (Pessoa p in lista)
                {
                    empresascliente = cum.GetEmpresaDoCliente(p.id);
                    if ((empresascliente.Length) > 15)
                    {
                        empresascliente = (empresascliente).Substring(0, 15) + "...";
                    }
                                
                    conteudo += @"								
                                 <tr role='row' class='odd'>
                                    <td class='sorting_1'>" + p.id + @"</td>
									<td><span class='responsiveExpander'></span>" + p.nome + @"</td>
									<td>" + empresascliente
                                           + @"</td>
									<td>" + pm.GetDefaultEmailPessoa(p.id) + @"</td>
									<td>" + pm.GetDefaultPhonePessoa(p.id) + @"</td>
                                     <td>
                                        <button type='button' class='btn  btn-sm btn-primary  view' onclick='EditCustomer(" + p.id + @");' >
                                        <span class='glyphicon glyphicon-eye-open'></span>
                                        </button>
                                    </td>
                                    <td>
                                         <button type='button' class='btn  btn-sm btn-danger delete'  onclick='DeleteCustomer(" + p.id + ",\"" + p.nome + @""");'>
                                        <span class='glyphicon glyphicon-remove'></span>
                                        </button>
                                    </td> 
								</tr>";
                }
                conteudo += "</tbody></table>";

                ListCustomers.Text = conteudo;

            }
            else
            {
                    CompanyModel com = new CompanyModel();
                    List<Pessoa> empresas = new List<Pessoa>();
                    empresas = com.ListPessoas();
                    string conteudoempresa = null;
                    foreach (Pessoa em in empresas)
                    {
                        conteudoempresa += @"<option value='" + em.id + @"'>" + em.nome + @"</option>";
                    }

                    selecionaempresas.Text = conteudoempresa;


                    if (!IsPostBack)
                    {

                        if (Request.Params["name"] != null)
                        {
                            try
                            {
                                CustomerModel cm = new CustomerModel();
                                Pessoa p = new Pessoa();
                                p.Cliente = new Cliente();
                                p.id = Int32.Parse(Request.Params["idCustomer"]);
                                p.nome = Request.Params["name"];
                                p.Cliente.cpf = Request.Params["cpf"];
                                p.Cliente.profissao = Request.Params["profession"];
                                int company = Int32.Parse(Request.Params["company"]);
                                p.cep = Request.Params["zip"];
                                p.logradouro = Request.Params["street"];
                                p.numero = Request.Params["number"];
                                p.bairro = Request.Params["neighborhood"];
                                p.complemento = Request.Params["complement"];
                                p.cidade_id = Int32.Parse(Request.Params["city"]);
                                p.status = 1;
                                if (Request.Params["email[]"] != null)
                                {
                                    string[] emails = Request.Params["email[]"].Split(',');
                                    if (Request.Params["phone[]"] != null)
                                    {
                                        string[] phones = Request.Params["phone[]"].Split(',');
                                        cm.Update(p, emails, phones, company);
                                        Response.Redirect("Index.aspx#Customers.aspx?ok=edit",false);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {


                            CustomerModel cum = new CustomerModel();
                            string conteudo = @"<table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr>
                                     <th data-hide='phone' class='sorting_asc' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-sort='ascending' aria-label='Id: activate to sort column ascending' style='width: 31px;'>Id</th>
                                     <th data-hide='Hour' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Name: activate to sort column ascending' style='width: 324px;'>Name</th>
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Company: activate to sort column ascending' style='width: 128px;'>Company</th>                                    
                                    <th data-hide='phone,tablet' class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Default Email : activate to sort column ascending' style='width: 181px;'>Default Email </th>   
                                    <th class='sorting' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-label='Default Phone : activate to sort column ascending' style='width: 128px;'>Default Phone </th>             
                                      
                                    <th style='width: 40px;'>View</th>           
                                    <th style='width: 40px;'>Delete</th> 
                                    
								</tr>
							</thead>
							<tbody>";
                            List<Pessoa> lista = cum.ListPessoas();
                            string empresascliente = "";
                            foreach (Pessoa p in lista)
                            {
                                empresascliente = cum.GetEmpresaDoCliente(p.id);
                                if ((empresascliente.Length) > 15)
                                {
                                    empresascliente = (empresascliente).Substring(0, 15) + "...";
                                } 
                                conteudo += @"								
                                 <tr role='row' class='odd'>
                                    <td class='sorting_1'>" + p.id + @"</td>
									<td><span class='responsiveExpander'></span>" + p.nome + @"</td>
									<td>" + empresascliente + @"</td>
									<td>" + pm.GetDefaultEmailPessoa(p.id) + @"</td>
									<td>" + pm.GetDefaultPhonePessoa(p.id) + @"</td>
									 <td>
                                        <button type='button' class='btn  btn-sm btn-primary  view' onclick='EditCustomer(" + p.id + @");' >
                                        <span class='glyphicon glyphicon-eye-open'></span>
                                        </button>
                                    </td>
                                    <td>
                                         <button type='button' class='btn  btn-sm btn-danger delete' onclick='DeleteCustomer(" + p.id + ",\"" + p.nome + @""");'>
                                        <span class='glyphicon glyphicon-remove'></span>
                                        </button>
                                    </td> 
								</tr>";
                            }
                            conteudo += "</tbody></table>";

                            ListCustomers.Text = conteudo;
                        }
                    }
                }
            }
        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerModel cm = new CustomerModel();
                Pessoa p = new Pessoa();
                p.Cliente = new Cliente();

                p.nome = Request.Params["name"];
                if (file.HasFile)
                {
                    string nomeimg= (DateTime.Now).ToString("dd.MM.yyyy") + "-";
                    p.imagem = nomeimg + file.FileName;
                    file.SaveAs(Server.MapPath("../Images/avatars/" + (nomeimg + file.FileName)));
                }
                else
                {
                    p.imagem = "user.jpg";
                }
                p.Cliente.cpf = Request.Params["cpf"];
                p.Cliente.login = Request.Params["login"];
                p.Cliente.senha = Request.Params["password"];
                p.Cliente.profissao = Request.Params["profession"];
                int company = Int32.Parse(Request.Params["company"]);               
                p.cep = Request.Params["zip"];
                p.logradouro = Request.Params["street"];
                p.numero = Request.Params["number"];
                p.bairro = Request.Params["neighborhood"];
                p.complemento = Request.Params["complement"];
                p.cidade_id = Int32.Parse(Request.Params["city"]);
                p.status = 1;                
                    if (Request.Form["email[]"] != null)
                    {
                        string[] emails = Request.Form["email[]"].Split(',');
                        if (Request.Form["phone[]"] != null)
                        {
                            string[] phones = Request.Form["phone[]"].Split(',');
                            cm.Insert(p,emails,phones,company);
                            Response.Redirect("Index.aspx#Customers.aspx?ok=register", false);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }         
        }


        
    }
}