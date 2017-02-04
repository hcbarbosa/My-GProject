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
    public partial class GetGantt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["projeto"] != null) 
            {
                GanttModel gm = new GanttModel();
                ProjectModel pm = new ProjectModel();
                Projeto p = new Projeto();

                List<SerializeGanttData> lsd = new List<SerializeGanttData>();

                SerializeGanttData sd = new SerializeGanttData();

                p = pm.GetProjeto(Int32.Parse(Request.Params["projeto"]));

                sd.id = decimal.Parse(Request.Params["projeto"]);
                sd.text = p.nome;
                sd.start_date = p.data_inicio.ToString("dd-MM-yyyy");
                TimeSpan tm = p.data_termino - p.data_inicio;
                sd.duration = (tm.TotalDays).ToString();
                sd.progress = p.porc_completo/100;
                sd.parent = "";
                sd.open = true;

                lsd.Add(sd);
                lsd.AddRange(gm.GetGanttData(Int32.Parse(Request.Params["projeto"])));

                JavaScriptSerializer js = new JavaScriptSerializer();
                string data = js.Serialize(lsd);
                string links = js.Serialize(gm.GetDependency(Int32.Parse(Request.Params["projeto"])));

                Response.Write("{\"data\":"+data+", \"links\":"+links+"}");


                
                

            }

        }
    }
}