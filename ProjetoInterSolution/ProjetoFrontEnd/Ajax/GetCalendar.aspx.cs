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
    public partial class GetCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                int auxmesinicio = 0;
                int auxmesfim = 0;
                string cmes = "";
                int id = Int32.Parse(Request.Params["id"]);
                string eventos = "";
                string inicio = "";
                string fim = "";
                ActivityModel am = new ActivityModel();
                Pessoa p = Session["pessoa"] as Pessoa;
                DateTime data = DateTime.Now;
                data = DateTime.Parse((data.ToString()).Substring(0, 10));

                eventos += "{\"title\":\"oi\"," +
                                        "\"start\":\"" + "new Date(2014,10,27)\"," +
                                       "\"end\":\"" + "new Date(2014,10,27)\"," +
                                       "\"className\":\" ['event', 'bg-color-greenLight']\"," +
                                       "\"icon\":\"" + "fa-check" + "\"},";
                foreach (Atividade a in am.ListAtividadesdoMes(id))
                {
                    cmes = (a.data_inicio).ToString().Substring(3, 2);
                    auxmesinicio = Int32.Parse(cmes)-1;
                    cmes = (a.data_termino).ToString().Substring(3, 2);
                    auxmesfim = Int32.Parse(cmes) - 1;
                    inicio = (a.data_inicio).ToString().Substring(0, 2) + "/"+ auxmesinicio + "/" + (a.data_inicio).ToString().Substring(6, 4);
                    fim = (a.data_termino).ToString().Substring(0, 2) + "/" + auxmesfim + "/" + (a.data_termino).ToString().Substring(6, 4);
                    
                    if (a.status == 1 && a.data_termino < data)
                    { 
                        eventos += "{\"title\":\"" + a.nome + "\","+
                                        "\"start\":\"" +  inicio + "\"," +
                                        "\"end\":\"" + fim + "\"," +
                                        "\"className\":\" ['event', 'bg-color-red']\","+
                                        "\"icon\":\"" +"fa-clock-o"+"\"},";
                    }
                    else
                    {
                        eventos += "{\"title\":\"" + a.nome + "\"," +
                                         "\"start\":\"" +  inicio + "\"," +
                                        "\"end\":\"" + fim + "\"," +
                                         "\"className\":\" ['event', 'bg-color-greenLight']\"," +
                                        "\"icon\":\"" + "fa-check" + "\"},";
                    }
                   
                }

               string dados = "\"eventos\":[" + eventos.Substring(0, eventos.Length - 1) + "]";


                Response.Write("[{" +dados +"}]");            

            }
        }
    }
}