using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFrontEnd.Ajax
{
    public partial class GetDependency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string st = Request.Params["dependencias"];
                

                string principal = Request.Params["principal"];
                int projeto = Int32.Parse(Request.Params["projeto"]);
                int tipo = Int32.Parse(Request.Params["tipo"]);

                Dependencia d = new Dependencia();

                d.tipo = tipo;
                d.projeto = projeto;
                if (principal.Contains("A"))
                {
                    d.atividadePrincipal = Int32.Parse(principal.Substring(0, principal.Length - 1));

                }
                else
                {
                    d.atividadePrincipal = null;
                }

                if (principal.Contains("F"))
                {
                    d.fasePrincipal = Int32.Parse(principal.Substring(0, principal.Length - 1));

                }
                else
                {
                    d.fasePrincipal = null;
                }

                if (st.Contains("A"))
                {
                    d.atividadeDependente = Int32.Parse(st.Replace("A", ""));

                }
                else
                {
                    d.atividadeDependente = null;
                }

                if (st.Contains("F"))
                {
                    d.faseDependente = Int32.Parse(st.Replace("F", ""));

                }
                else
                {
                    d.faseDependente = null;
                }

                DependenciaModel dm = new DependenciaModel();
                dm.CriaDep(d);

            }

        }
    }
}