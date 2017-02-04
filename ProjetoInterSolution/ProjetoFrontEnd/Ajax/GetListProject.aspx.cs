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
    public partial class GetListProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["acao"] != null && Request.Params["acao"] == "preenche" && Request.Params["projeto"] != null)
                {
                    int projeto = Int32.Parse(Request.Params["projeto"]);
                    CompanyModel com = new CompanyModel();
                    ModeloModel mom = new ModeloModel();
                    ProjectModel pm = new ProjectModel();
                    CustomerModel cm = new CustomerModel();
                    int empresa = 0;
                    Projeto proj = pm.GetProjeto(projeto);
                    string empresaprojeto = pm.GetEmpresaProjeto(projeto);
                    List<Pessoa> empresas = com.ListPessoas();
                    List<Modelo> modelos = mom.ListModelos();
                    string opempresas = "";
                    string opmodelos = "";
                    string opclientes = "";
                    //preenche combobox empresa
                    foreach (Pessoa p in empresas)
                    {
                        if (empresaprojeto == p.nome)
                        {
                            opempresas += "<option value='" + p.id + "' selected='selected'>" + p.nome + "</option>";
                            empresa = p.id;
                        }
                        else
                        {
                            opempresas += "<option value='" + p.id + "'>" + p.nome + "</option>";
                        }
                    }
                    //preenche combobox modelo
                    foreach (Modelo m in modelos)
                    {
                        if (proj.modelo_numero == m.numero)
                        {
                            opmodelos += "<option value='" + m.numero + "' selected='selected'>" + m.nome + "</option>";
                        }
                        else
                        {
                            opmodelos += "<option value='" + m.numero + "'>" + m.nome + "</option>";
                        }
                    }

                    List<Pessoa> clientes = cm.GetPessoas(empresa);
                    //preenche combobox clientes
                    foreach (Pessoa c in clientes)
                    {

                        opclientes += "<option value='" + c.id + "'>" + c.nome + "</option>";
                    }

                    Response.Write("[{\"companies\":\"" + opempresas + "\",\"modelos\":\"" + opmodelos + "\",\"name\":\"" + proj.nome + "\",\"start\":\"" + (proj.data_inicio).ToString("yyyy-MM-dd") + "\",\"finish\":\"" + (proj.data_termino).ToString("yyyy-MM-dd") + "\",\"value\":\"" + proj.valor_previsto + "\",\"customers\":\"" + opclientes + "\"}]");
                }
                else if (Request.Params["acao"] != null && Request.Params["acao"] == "preenchemodel" && Request.Params["projeto"] != null)
                {
                    ModeloModel mm = new ModeloModel();
                    Modelo m = mm.GetModeloPorProjeto(Int32.Parse(Request.Params["projeto"]));
                    Response.Write("[{\"name\":\"" + m.nome + "\",\"desc\":\"" + m.descricao + "\",\"numero\":\"" + m.numero + "\"}]");
                }
                else if (Request.Params["acao"] != null && Request.Params["acao"] == "comment" && Request.Params["projeto"] != null && Request.Params["comentario"] != null && Request.Params["id"] != null)
                {
                    Comentario c = new Comentario();
                    CommentModel cm = new CommentModel();
                    PeopleModel ps = new PeopleModel();
                    c.data_hora = DateTime.Now;
                    c.descricao = Request.Params["comentario"];
                    c.pessoa_id = Int32.Parse(Request.Params["id"]);
                    c.projeto_codigo = Int32.Parse(Request.Params["projeto"]);
                    c.status = 1;
                    cm.Insert(c);

                    Response.Write("[{\"comentario\":\"" + c.descricao + "\",\"img\":\"" + ps.GetImagem(c.pessoa_id) + "\",\"data\":\"" + c.data_hora + "\",\"id\":\"" + c.id + "\",\"usuario\":\"" + ps.GetPessoa(c.pessoa_id).nome + "\"}]");
                }
                else if (Request.Params["acao"] == "inserir" && Request.Params["modelo"] != null && Request.Params["desc"] != null && Request.Params["codigo"] != null)
                {
                    Modelo m = new Modelo();
                    m.nome = Request.Params["modelo"];
                    m.descricao = Request.Params["desc"];
                    m.projeto_codigo = Int32.Parse(Request.Params["codigo"]);
                    m.status = 1;
                    ModeloModel mm = new ModeloModel();
                    mm.Insert(m);
                }
                else if (Request.Params["acao"] == "alterar" && Request.Params["modelo"] != null && Request.Params["desc"] != null && Request.Params["codigo"] != null)
                {
                    Modelo m = new Modelo();
                    m.nome = Request.Params["modelo"];
                    m.descricao = Request.Params["desc"];
                    m.projeto_codigo = Int32.Parse(Request.Params["codigo"]);
                    m.status = 1;
                    ModeloModel mm = new ModeloModel();
                    mm.Update(m);
                }
                else if (Request.Params["acao"] == "deletemodel" && Request.Params["numero"] != null)
                {
                    ModeloModel mm = new ModeloModel();
                    mm.Delete(Int32.Parse(Request.Params["numero"]));
                }
                else if (Request.Params["acao"] == "deleterecurso" && Request.Params["recat"] != null)
                {
                    CronogramaRecursoModel crm = new CronogramaRecursoModel();
                    string[] recat = Request.Params["recat"].Split(',');
                    int rec = Int32.Parse(recat[0]);
                    int atv = Int32.Parse(recat[1]);
                    crm.Delete(rec, atv);
                    Response.Write("[{\"rec\":\"" + rec + "\",\"at\":\"" + atv + "\"}]");
                }
                else if (Request.Params["deletecomment"] != null)
                {
                    int id = Int32.Parse(Request.Params["deletecomment"]);
                    CommentModel cm = new CommentModel();
                    cm.Delete(id);

                }
                else if (Request.Params["acao"] == "editfase" && Request.Params["fase"] != null)
                {
                    StepModel sm = new StepModel();
                    Fase f = sm.GetFase(Int32.Parse(Request.Params["fase"]));
                    Response.Write("[{\"name\":\"" + f.nome + "\",\"desc\":\"" + f.descricao + "\",\"start\":\"" + f.data_inicio + "\",\"finish\":\"" + f.data_termino + "\"}]");
                }
                else if (Request.Params["acao"] == "alterar" && Request.Params["fase"] != null && Request.Params["desc"] != null && Request.Params["start"] != null && Request.Params["finish"] != null)
                {
                    StepModel sm = new StepModel();
                    Fase f = new Fase();
                    f.numero = Int32.Parse(Request.Params["fase"]);
                    f.nome = Request.Params["nome"];
                    f.descricao = Request.Params["desc"];
                    f.data_inicio = DateTime.Parse(Request.Params["start"]);
                    f.data_termino = DateTime.Parse(Request.Params["finish"]);
                    sm.Update(f);
                    string start = (f.data_inicio).ToString().Substring(0, 10);
                    string finish = (f.data_termino).ToString().Substring(0, 10);
                    Response.Write("[{\"name\":\"" + f.nome + "\",\"numero\":\"" + f.numero + "\",\"desc\":\"" + f.descricao + "\",\"start\":\"" + start + "\",\"finish\":\"" + finish + "\"}]");

                }
                else if (Request.Params["acao"] == "deletefase" && Request.Params["fase"] != null)
                {
                    StepModel sm = new StepModel();
                    sm.Delete(Int32.Parse(Request.Params["fase"]));
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "reactivefase" && Request.Params["fase"] != null)
                {
                    StepModel sm = new StepModel();
                    sm.Reactivate(Int32.Parse(Request.Params["fase"]));
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "completefase" && Request.Params["fase"] != null)
                {
                    StepModel sm = new StepModel();
                    sm.Complete(Int32.Parse(Request.Params["fase"]));
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "novafase" && Request.Params["nome"] != null && Request.Params["desc"] != null && Request.Params["start"] != null && Request.Params["finish"] != null)
                {
                    StepModel sm = new StepModel();
                    Fase f = new Fase();
                    f.nome = Request.Params["nome"];
                    f.descricao = Request.Params["desc"];
                    f.data_inicio = DateTime.Parse(Request.Params["start"]);
                    f.data_termino = DateTime.Parse(Request.Params["finish"]);
                    f.status = 1;
                    f = sm.Insert(f);
                    Response.Write("[{\"numero\":\"" + f.numero + "\"}]");
                }
                else if (Request.Params["acao"] == "novaat" && Request.Params["projeto"] != null && Request.Params["hora"] != null && Request.Params["fase"] != null && Request.Params["nome"] != null && Request.Params["desc"] != null && Request.Params["start"] != null && Request.Params["finish"] != null)
                {
                    ActivityModel am = new ActivityModel();
                    Atividade a = new Atividade();
                    a.nome = Request.Params["nome"];
                    a.descricao = Request.Params["desc"];
                    a.data_inicio = DateTime.Parse(Request.Params["start"]);
                    a.data_termino = DateTime.Parse(Request.Params["finish"]);
                    a.qtd_hora = Int32.Parse(Request.Params["hora"]);
                    a.status = 1;
                    a = am.Insert(a);
                    CronogramaModel cm = new CronogramaModel();
                    cm.InsertStepAt(Int32.Parse(Request.Params["projeto"]), Int32.Parse(Request.Params["fase"]), a.numero);
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "deleteat" && Request.Params["at"] != null)
                {
                    ActivityModel am = new ActivityModel();
                    am.Delete(Int32.Parse(Request.Params["at"]));
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "reactivateat" && Request.Params["at"] != null)
                {
                    ActivityModel am = new ActivityModel();
                    am.Reactivate(Int32.Parse(Request.Params["at"]));
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "completeat" && Request.Params["at"] != null)
                {
                    ActivityModel am = new ActivityModel();
                    am.Complete(Int32.Parse(Request.Params["at"]));
                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["acao"] == "editat" && Request.Params["at"] != null)
                {
                    ActivityModel am = new ActivityModel();
                    Atividade a = am.GetAtividade(Int32.Parse(Request.Params["at"]));
                    Response.Write("[{\"name\":\"" + a.nome + "\",\"desc\":\"" + a.descricao + "\",\"start\":\"" + a.data_inicio + "\",\"finish\":\"" + a.data_termino + "\",\"hour\":\"" + a.qtd_hora + "\"}]");
                }
                else if (Request.Params["acao"] == "alteraat" && Request.Params["nome"] != null && Request.Params["hora"] != null && Request.Params["numero"] != null && Request.Params["desc"] != null && Request.Params["start"] != null && Request.Params["finish"] != null)
                {
                    ActivityModel am = new ActivityModel();
                    Atividade a = new Atividade();
                    a.numero = Int32.Parse(Request.Params["numero"]);
                    a.nome = Request.Params["nome"];
                    a.descricao = Request.Params["desc"];
                    a.data_inicio = DateTime.Parse(Request.Params["start"]);
                    a.data_termino = DateTime.Parse(Request.Params["finish"]);
                    a.qtd_hora = Int32.Parse(Request.Params["hora"]);
                    a.status = 1;
                    am.Update(a);
                    string start = (a.data_inicio).ToString().Substring(0, 10);
                    string finish = (a.data_termino).ToString().Substring(0, 10);
                    Response.Write("[{\"name\":\"" + a.nome + "\",\"desc\":\"" + a.descricao + "\",\"numero\":\"" + a.numero + "\",\"start\":\"" + start + "\",\"finish\":\"" + finish + "\",\"hour\":\"" + a.qtd_hora + "\"}]");
                }
                else if (Request.Params["acao"] == "preencherecurso" && Request.Params["tipo"] != null && Request.Params["atividade"] != null && Request.Params["fase"] != null && Request.Params["projeto"] != null)
                {
                    string opcoes = "";
                    CronogramaRecursoModel crm = new CronogramaRecursoModel();
                    int tipo = Int32.Parse(Request.Params["tipo"]);
                    int projeto = Int32.Parse(Request.Params["projeto"]);
                    int fase = Int32.Parse(Request.Params["fase"]);
                    int at = Int32.Parse(Request.Params["atividade"]);
                    List<Recurso> lr = crm.listRecursosSemRelacao(tipo, projeto, fase, at);
                    foreach (Recurso r in lr)
                    {
                        opcoes += "<option  value ='" + r.id + "' >" + r.descricao + "</option>";
                    }
                    Response.Write("[{\"recursos\":\"" + opcoes + "\"}]");
                }
                else if (Request.Params["acao"] == "qtdrecurso" && Request.Params["recurso"] != null)
                {

                    ResourceModel rm = new ResourceModel();
                    Recurso r = rm.GetResource(Int32.Parse(Request.Params["recurso"].ToString()));
                    if (r.Tipo.descricao == "Human")
                    {
                        Response.Write("[{\"qtd\":\"" + r.qtd_hora_disponivel + "\"}]");
                    }
                    else if (r.Tipo.descricao == "Material")
                    {
                        Response.Write("[{\"qtd\":\"" + r.qtd_unid_disponivel + "\"}]");
                    }
                }
                else if (Request.Params["acao"] == "addrecurso" && Request.Params["recurso"] != null && Request.Params["projeto"] != null && Request.Params["fase"] != null && Request.Params["atividade"] != null)
                {
                    CronogramaRecursoModel crm = new CronogramaRecursoModel();
                    ResourceModel rm = new ResourceModel();
                    Recurso r = rm.GetResource(Int32.Parse(Request.Params["recurso"]));
                    CronogramaRecurso c = new CronogramaRecurso();
                    c.projeto_codigo = Int32.Parse(Request.Params["projeto"]);
                    c.fase_numero = Int32.Parse(Request.Params["fase"]);
                    c.atividade_numero = Int32.Parse(Request.Params["atividade"]);
                    c.recurso_id = Int32.Parse(Request.Params["recurso"]);
                    r.id = Int32.Parse(Request.Params["recurso"]);

                    if (Request.Params["tipo"] == "1")
                    {
                        c.qtd_hora_usada = TimeSpan.Parse(Request.Params["hora"]);
                    }
                    else
                    {
                        decimal qtd = Decimal.Parse(Request.Params["qtd"].ToString());
                        decimal unid = Decimal.Parse(Request.Params["unid"].ToString());
                        if (qtd < unid)
                        {
                            c.qtd_unid_usada = Decimal.Parse(Request.Params["qtd"]);
                        }
                        else
                        {
                            c.qtd_unid_usada = Decimal.Parse(Request.Params["unid"]);
                        }
                    }
                    if (c.qtd_hora_usada != null)
                    {
                        int q = Int32.Parse(c.qtd_hora_usada.ToString().Substring(0, 2));
                        c.valortotal = r.valor * q;
                    }
                    else if (c.qtd_unid_usada != null)
                    {
                        decimal q = Decimal.Parse(c.qtd_unid_usada.ToString());
                        c.valortotal = r.valor * q;
                    }
                    c.status = 1;

                    if (Request.Params["tipo"] == "1")
                    {
                        r.qtd_hora_disponivel = r.qtd_hora_disponivel - c.qtd_hora_usada;
                    }
                    else
                    {
                        r.qtd_unid_disponivel = r.qtd_unid_disponivel - c.qtd_unid_usada;
                    }

                    ProjectModel pm = new ProjectModel();
                    Projeto p = pm.GetProjeto(c.projeto_codigo);

                    crm.Insert(c);
                    rm.Update(r);
                    p.valor_utilizado = p.valor_utilizado + c.valortotal;
                    pm.UpdateValor(p);

                    Response.Write("[{\"ok\":\"" + true + "\"}]");
                }
                else if (Request.Params["savedoc"] != null && Request.Params["at"] != null)
                {
                    DocumentModel dm = new DocumentModel();
                    Documento d = new Documento();
                    d.tipo = (DateTime.Now).ToString("dd.MM.yyyy.hh.mm.ss");
                    d.nome = Request.Params["savedoc"];

                    dm.InsertDoc(Int32.Parse(Request.Params["at"]), d);

                    Response.Write("[{\"ok\":\"" + true + "\"}]");
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
            }
        }
    }
}