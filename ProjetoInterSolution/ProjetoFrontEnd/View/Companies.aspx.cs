using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

using System.IO;

namespace ProjetoInter.View
{
    public partial class Companies : System.Web.UI.Page
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
                                                   title: 'Company',
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
                                                   title: 'Company',
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

            if (!IsPostBack)
            {
                if (Request.Params["name"] != null)
                {
                    try
                    {
                        CompanyModel cm = new CompanyModel();
                        Pessoa em = new Pessoa();
                        em.Empresa = new Empresa();
                        em.id = Int32.Parse(Request.Params["idCompany"]);
                        em.nome = Request.Params["name"];
                        if (Request.Params["filecompany"]!=null && Request.Params["filecompany"]!= "")
                        {
                            string imgatual = pm.GetImagem(em.id) ;
                            if (Request.Params["filecompany"] != imgatual )
                            {
                                if (imgatual != "gp.png")
                                {
                                    File.Delete(Server.MapPath("../Images/uploads/" + imgatual));
                                }
                            }
                                                       
                            em.imagem = (DateTime.Now).ToString("dd.MM.yyyy") + "-" + Request.Params["filecompany"];
                        }
                        em.Empresa.cnpj = Request.Params["cnpj"];
                        em.Empresa.area_de_atuacao = Request.Params["area"];
                        em.cep = Request.Params["zip"];
                        em.logradouro = Request.Params["street"];
                        em.numero = Request.Params["number"];
                        em.bairro = Request.Params["neighborhood"];
                        em.complemento = Request.Params["complement"];
                        em.cidade_id = Int32.Parse(Request.Params["city"]);
                        em.status = 1;
                        if (Request.Params["email[]"] != null)
                        {
                            string[] emails = Request.Params["email[]"].Split(',');
                            if (Request.Params["phone[]"] != null)
                            {
                                string[] phones = Request.Params["phone[]"].Split(',');
                                cm.Update(em, emails, phones);
                                Response.Redirect("Index.aspx#Companies.aspx?ok=edit", false);
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
                    if(Request.Params["letra"]!=null && Request.Params["letra"]!="All")
                    {
                        CompanyModel cm = new CompanyModel();
                        string conteudo = null;
                        int aux = 0;
                        string teste;
                        if ((cm.ListPessoas(Request.Params["letra"])).Count() == 0 )
                        {
                            conteudo="<br /><br /><center>Nothing found</center>";
                        }
                        else{
                            foreach (Pessoa p in cm.ListPessoas(Request.Params["letra"]))
                            {
                                teste = ((p.nome.Length) > 15) ? (p.nome).Substring(0, 15) + "..." : p.nome;
                                if (aux % 7 == 0)
                                {
                                    conteudo += @"<div class='row'></div><div class='superbox-list'  >
			                                <img id='imgtoda' src='../Images/uploads/" + p.imagem + @"'  title='" + p.nome + @"' class='superbox-img' onclick='GetCompaniesId(" + p.id + ",\"" + p.nome + @""");' style='border:solid;'/>
                                            <label style='color:green'>" + teste + @"</label>
		                                    </div>";
                                }
                                else
                                {
                                    conteudo += @"<div class='superbox-list'>
			                                <img id='imgtoda' src='../Images/uploads/" + p.imagem + @"'  title='" + p.nome + @"' class='superbox-img' onclick='GetCompaniesId(" + p.id + ",\"" + p.nome + @""");' style='border:solid;'/>
                                            <label style='color:green'>" + teste + @"</label>
		                                    </div>";
                                }
                                aux++;
                            }                            
                       }
                        listcompanies.Text = conteudo;

                    }
                    else{

                        CompanyModel cm = new CompanyModel();
                        string conteudo = null;
                        int aux = 0;
                        string teste;
                        foreach (Pessoa p in cm.ListPessoas())
                        {
                            teste = ((p.nome.Length) > 15) ? (p.nome).Substring(0, 15) + "..." : p.nome;
                            if (aux % 7 == 0)
                            {
                                conteudo += @"<div class='row'></div><div class='superbox-list'  >
			                            <img id='imgtoda' src='../Images/uploads/" + p.imagem + @"'  title='" + p.nome + @"' class='superbox-img' onclick='GetCompaniesId(" + p.id + ",\"" + p.nome + @""");' style='border:solid;'/>
                                        <label style='color:green'>" + teste + @"</label>
		                                </div>";
                            }
                            else
                            {
                                conteudo += @"<div class='superbox-list'>
			                            <img id='imgtoda' src='../Images/uploads/" + p.imagem + @"'  title='" + p.nome + @"' class='superbox-img' onclick='GetCompaniesId(" + p.id + ",\"" + p.nome + @""");' style='border:solid;'/>
                                        <label style='color:green'>" + teste + @"</label>
		                                </div>";
                            }
                            aux++;
                        }
                    
                        listcompanies.Text = conteudo;
                    }
                }
            }

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyModel cm = new CompanyModel();
                Pessoa em = new Pessoa();
                em.Empresa = new Empresa();
                em.nome = Request.Params["name"];
                if (file.HasFile)
                {
                    em.imagem = (DateTime.Now).ToString("dd.MM.yyyy") + "-" + file.FileName;
                    file.SaveAs(Server.MapPath("../Images/uploads/" + em.imagem));
                }
                else
                {
                    em.imagem = "gp.png";
                }
                em.Empresa.cnpj = Request.Params["cnpj"];
                em.Empresa.area_de_atuacao = Request.Params["area"];
                em.cep = Request.Params["zip"];
                em.logradouro = Request.Params["street"];
                em.numero = Request.Params["number"];
                em.bairro = Request.Params["neighborhood"];
                em.complemento = Request.Params["complement"];
                em.cidade_id = Int32.Parse(Request.Params["city"]);
                em.status = 1;

                if (Request.Form["email[]"] != null)
                {
                    string[] emails = Request.Form["email[]"].Split(',');
                    if (Request.Form["phone[]"] != null)
                    {
                        string[] phones = Request.Form["phone[]"].Split(',');
                        cm.Insert(em,emails,phones);
                        Response.Redirect("Index.aspx#Companies.aspx?ok=register", false);
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