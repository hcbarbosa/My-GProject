using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFrontEnd.Ajax
{
    public partial class GetReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["projeto"] != null) 
            {

               
                ProjectModel pm = new ProjectModel();
                int projeto = Int32.Parse(Request.Params["projeto"]);
                Projeto p = pm.GetProjeto(projeto);

                string clientes = "";
                foreach (Cliente c in pm.GetClientesProjeto(projeto))
                {
                    clientes += c.Pessoa.nome + ";";
                }
                string modelo = "";
                if (p.modelo_numero != null)
                {
                    ModeloModel mm = new ModeloModel();
                    modelo = mm.GetModelo(p.modelo_numero.Value).nome;
                }
                else
                {
                    modelo = "No";
                }

               

                string fases = "";
                StepModel sm = new StepModel();
                int porc = 0;
                string nome = "";
                string[] aux;
                foreach (Fase f in sm.listFases(Int32.Parse(Request.Params["projeto"])))
                {
                    if (f.nome.Count() > 8)
                    {
                        nome = (f.nome).Substring(0, 8);
                    }
                    else
                    {
                        nome = f.nome;
                    }
                   aux = ((f.porc_completo).ToString()).Split(',');
                   porc = Int32.Parse(aux[0]);
                   fases += "{\"x\": \"" + nome + "\",\"y\": " + porc + "},";

                }

                string dados = "\"porc_completo\":\"" + (p.porc_completo) + "\",\"nome\":\"" + p.nome + "\",\"clientes\":\"" + clientes + "\",\"company\":\"" + pm.GetEmpresaProjeto(projeto) + "\",\"modelo\":\"" + modelo + "\",\"data_inicio\":\"" + p.data_inicio.ToString("dd/MM/yyyy") + "\",\"data_termino\":\"" + p.data_termino.ToString("dd/MM/yyyy") + "\",\"valor_previsto\":\"" + p.valor_previsto + "\",\"valor_utilizado\":\"" + p.valor_utilizado + "\",\"fases\":[" + fases.Substring(0,fases.Length-1) + "]";


                Response.Write("[{"+dados+"}]");
            
            
            }

        }
    }
}