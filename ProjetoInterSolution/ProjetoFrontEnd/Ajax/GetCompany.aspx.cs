using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoFrontEnd.Ajax
{
    public partial class GetCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["id"] != null)
            {
                if (Request.Params["acao"] != null && Request.Params["acao"] == "edit")
                {
                    CompanyModel cm = new CompanyModel();
                    PeopleModel pm = new PeopleModel();

                    Empresa em = new Empresa();
                    em.Pessoa = new Pessoa();
                    em.Pessoa.Cidade = new Cidade();
                    em.Pessoa.Cidade.Estado = new Estado();
                    em = cm.GetEmpresa(Int32.Parse(Request.Params["id"]));
                    string emails = "";
                    string phones = "";

                    foreach (Email email in pm.ListEmails(em.pessoa_id))
                    {
                        emails += email.endereco + ";";
                    }

                    foreach (Telefone tel in pm.ListTelefones(em.pessoa_id))
                    {
                        phones += tel.numero + ";";
                    }
                    Response.Write("[{\"empresa\":\"" + em.Pessoa.nome + "\",\"cnpj\":\"" + em.cnpj + "\",\"area\":\"" + em.area_de_atuacao + "\", \"zip\":\"" + em.Pessoa.cep + "\", \"street\":\"" + em.Pessoa.logradouro + "\", \"number\":\"" + em.Pessoa.numero + "\", \"neighborhood\":\"" + em.Pessoa.bairro + "\", \"complement\":\"" + em.Pessoa.complemento + "\", \"state\":\"" + em.Pessoa.Cidade.Estado.nome + "\", \"city\":\"" + em.Pessoa.Cidade.nome + "\", \"img\":\"" + em.Pessoa.imagem + "\", \"email\":\"" + emails + "\", \"phone\":\"" + phones + "\"}]");
                
                }
                if (Request.Params["acao"] != null && Request.Params["acao"] == "preenche")
                {                
                    CompanyModel com = new CompanyModel();
                    PeopleModel pm = new PeopleModel();

                    int codigocidade = (com.GetEmpresa(Int32.Parse(Request.Params["id"])).Pessoa.cidade_id);
                    string estado = pm.EstadoDaPessoa(codigocidade);                   

                    List<Estado> estados = pm.ListEstados();
                    List<Cidade> cidades = pm.ListCidades(estado);
                    
                    string opestados = "";    
                    string opcidades = "";

                    //preenche combobox de estado
                    opestados = "<select name='state' id='stateCompany'>";
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
                    opcidades = "<select name='city' id='cityCompany' >";
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

                    Response.Write("[{\"estados\":\"" + opestados + "\",\"cidades\":\"" + opcidades + "\"}]");
                }
                else if (Request.Params["acao"] != null && Request.Params["acao"] == "delete")
                {
                    CompanyModel com = new CompanyModel();
                    com.Delete(Int32.Parse(Request.Params["id"]));
                }
            }
            

        }
    }
}