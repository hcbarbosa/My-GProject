using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Model;
using ProjetoBackEnd.Data;
using System.Web.Script.Serialization;


namespace ProjetoFrontEnd.Ajax
{
    public partial class GetCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                if (Request.Params["acao"] != null && Request.Params["acao"] == "edit")
                {
                    CustomerModel cm = new CustomerModel();
                    PeopleModel pm = new PeopleModel();

                    Cliente c = new Cliente();
                    c.Pessoa = new Pessoa();
                    c.Pessoa.Cidade = new Cidade();
                    c.Pessoa.Cidade.Estado = new Estado();
                    c = cm.GetCliente(Int32.Parse(Request.Params["id"]));
                    string empresa = cm.GetEmpresaDoCliente(c.pessoa_id);
                    string emails = "";
                    string phones = "";

                    foreach (Email email in pm.ListEmails(c.pessoa_id))
                    {
                        emails += email.endereco + ";";
                    }

                    foreach (Telefone tel in pm.ListTelefones(c.pessoa_id))
                    {
                        phones += tel.numero + ";";
                    }
                    Response.Write("[{\"cliente\":\"" + c.Pessoa.nome + "\",\"cpf\":\"" + c.cpf + "\",\"profession\":\"" + c.profissao + "\",\"empresa\":\"" + empresa + "\", \"zip\":\"" + c.Pessoa.cep + "\", \"street\":\"" + c.Pessoa.logradouro + "\", \"number\":\"" + c.Pessoa.numero + "\", \"neighborhood\":\"" + c.Pessoa.bairro + "\", \"complement\":\"" + c.Pessoa.complemento + "\", \"state\":\"" + c.Pessoa.Cidade.Estado.nome + "\", \"city\":\"" + c.Pessoa.Cidade.nome + "\", \"login\":\"" + c.login + "\", \"senha\":\"" + c.senha + "\", \"img\":\"" + c.Pessoa.imagem + "\", \"email\":\"" + emails + "\", \"phone\":\"" + phones + "\"}]");
                }
                else if (Request.Params["acao"] != null && Request.Params["acao"] == "preenche")
                {
                    CustomerModel cm = new CustomerModel();
                    CompanyModel com = new CompanyModel();
                    PeopleModel pm = new PeopleModel();

                    string empresadocliente = cm.GetEmpresaDoCliente(Int32.Parse(Request.Params["id"]));
                    int codigocidade = cm.GetPessoa(Int32.Parse(Request.Params["id"])).cidade_id;
                    string estado = pm.EstadoDaPessoa(codigocidade);                   

                    List<Pessoa> empresas = com.ListPessoas();
                    List<Estado> estados = pm.ListEstados();
                    List<Cidade> cidades = pm.ListCidades(estado);
                    
                    string opestados = "";    
                    string opempresas = "";
                    string opcidades = "";

                    //preenche combobox empresa
                    foreach (Pessoa p in empresas)
                    {
                        if (p.nome == empresadocliente)
                        {
                            opempresas += "<option value='" + p.id + "' selected='selected'>" + p.nome + "</option>";
                        }
                        else
                        {
                            opempresas += "<option value='" + p.id + "'>" + p.nome + "</option>";
                        }                        
                    }                    
                    //preenche combobox de estado
                    opestados = "<select name='state' id='state'>";
                    foreach (Estado es in estados)
                    {
                        if (es.sigla == estado)
                        {
                            opestados += "<option value='" + es.sigla + "' selected='selected'>" + es.nome + "</option>";
                        }
                        else
                        {
                            opestados += "<option value='" + es.sigla + "'>" + es.nome + "</option>";
                        }                          
                    }
                    opestados += "</select><i></i>";

                    //preenche combobox de cidade
                    opcidades = "<select name='city' id='city1' >";
                    foreach(Cidade cid in cidades)
                    {
                        if (codigocidade == cid.id)
                        {
                            opcidades += "<option value='" + cid.id + "' selected='selected'>" + cid.nome + "</option>";
                        }
                        else
                        {
                            opcidades += "<option value='" + cid.id + "'>" + cid.nome + "</option>";
                        }  
                    }
                    opcidades += "</select><i></i>";

                    Response.Write("[{\"companies\":\"" + opempresas + "\",\"estados\":\"" + opestados + "\",\"cidades\":\"" + opcidades + "\"}]");
                }
                else if (Request.Params["acao"] != null && Request.Params["acao"] == "delete")
                {
                    CustomerModel cm = new CustomerModel();
                    cm.Delete(Int32.Parse(Request.Params["id"]));
                }

            }
        }
    }
}