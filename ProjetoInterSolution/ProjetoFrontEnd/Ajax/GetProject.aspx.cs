using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;
using System.Web.Script.Serialization;

namespace ProjetoFrontEnd.Ajax
{
    public partial class GetProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["acao"] != null && Request.Params["acao"] == "preenche")
                {
                    CompanyModel com = new CompanyModel();
                    ModeloModel mom = new ModeloModel();
                    List<Pessoa> empresas = com.ListPessoas();
                    List<Modelo> modelos = mom.ListModelos();
                    string opempresas = "";
                    string opmodelos = "";
                    //preenche combobox empresa
                    foreach (Pessoa p in empresas)
                    {
                        opempresas += "<option value='" + p.id + "'>" + p.nome + "</option>";
                    }
                    //preenche combobox modelo
                    foreach (Modelo m in modelos)
                    {
                        opmodelos += "<option value='" + m.numero + "'>" + m.nome + "</option>";
                    }
                    Response.Write("[{\"companies\":\"" + opempresas + "\",\"modelos\":\"" + opmodelos + "\"}]");
                }
                else if (Request.Params["empresa"] != null)
                {
                    CustomerModel cm = new CustomerModel();
                    List<Pessoa> clientes = cm.GetPessoas(Int32.Parse(Request.Params["empresa"]));
                    List<RootObject> list = new List<RootObject>();

                    foreach (Pessoa p in clientes)
                    {
                        RootObject o = new RootObject();
                        o.id = p.id.ToString();
                        o.nome = p.nome;
                        list.Add(o);
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string strJson = js.Serialize(list);
                    Response.Write(strJson);

                }
                else if (Request.Params["model"] != null)
                {
                    ModeloModel mm = new ModeloModel();
                    Modelo m = mm.GetModelo(Int32.Parse(Request.Params["model"]));
                    Response.Write("[{\"name\":\"" + m.nome + "\"}]");
                }
                else if (Request.Params["company"] != null)
                {
                    CompanyModel cm = new CompanyModel();
                    Response.Write("[{\"name\":\"" + cm.GetEmpresa(Int32.Parse(Request.Params["company"])).Pessoa.nome + "\"}]");
                }
                else if (Request.Params["customers"] != null)
                {
                    string[] clientes = Request.Params["customers"].Split(',');
                    CustomerModel cm = new CustomerModel();
                    string opcoes = "";
                    for (int i = 0; i < clientes.Length; i++)
                    {
                        opcoes += "" + cm.GetPessoa(Int32.Parse(clientes[i])).nome + ";";
                    }

                    Response.Write("[{\"clientes\":\"" + opcoes + "\"}]");
                }
                else if (Request.Params["stepname"] != null && Request.Params["stepdescr"] != null && Request.Params["stepstart"] != null && Request.Params["stepfinish"] != null)
                {
                    StepModel sm = new StepModel();
                    Fase fi = new Fase();
                    fi.nome = Request.Params["stepname"];
                    fi.descricao = Request.Params["stepdescr"];
                    fi.data_inicio = DateTime.Parse(Request.Params["stepstart"]);
                    fi.data_termino = DateTime.Parse(Request.Params["stepfinish"]);
                    fi.porc_completo = 0;
                    fi.dias_usados = 0;
                    fi.status = 1;
                    Fase fr = sm.Insert(fi);
                    Response.Write("[{\"fase\":\"<tr><td>" + fr.nome + " <input type='hidden' name='steps[]' value='" + fr.numero + "'/></td></tr>\", \"treesteps\":\"  <li><span><i class='fa fa-lg '></i> " + fr.nome + "</span><ul id='" + fr.numero + "'></ul></li>\", \"curActivity\":\"<option value='" + fr.numero + "'>" + fr.nome + "</option>\"}]");
                }
                else if (Request.Params["actname"] != null && Request.Params["actdescr"] != null && Request.Params["actstart"] != null && Request.Params["actfinish"] != null)
                {


                    ActivityModel am = new ActivityModel();
                    Atividade at = new Atividade();
                    at.nome = Request.Params["actname"];
                    at.descricao = Request.Params["actdescr"];
                    at.data_inicio = DateTime.Parse(Request.Params["actstart"]);
                    at.data_termino = DateTime.Parse(Request.Params["actfinish"]);
                    at.porc_completo = 0;
                    at.qtd_hora = Int32.Parse(Request.Params["qtdhours"]);
                    at.status = 1;
                    Atividade af = am.Insert(at);
                    Response.Write("[{\"act\":\"<li ><span><label>" + af.nome + "</label> </span></li>\", \"actid\":\"" + af.numero + "\"}]");
                }
                else if (Request.Params["acao"] == "delete" && Request.Params["codigo"] != null)
                {
                    ProjectModel pm = new ProjectModel();
                    pm.Delete(Int32.Parse(Request.Params["codigo"]));
                }
                else if (Request.Params["acao"] == "ativar" && Request.Params["codigo"] != null)
                {
                    ProjectModel pm = new ProjectModel();
                    pm.Ativar(Int32.Parse(Request.Params["codigo"]));
                }
                else if (Request.Params["acao"] == "completar" && Request.Params["codigo"] != null)
                {
                    ProjectModel pm = new ProjectModel();
                    pm.Complete(Int32.Parse(Request.Params["codigo"]));
                }
            }
        }
    }
}