using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoBackEnd.Model;
using ProjetoBackEnd.Data;
using System.Web.Script.Serialization;
using ProjetoBackEnd;

namespace ProjetoFrontEnd.Ajax
{
    public partial class GetCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["uf"] != null) {
               string uf = Request.QueryString["uf"];
               uf = uf.ToUpper();
               PeopleModel pm = new PeopleModel();
                List<Cidade> lc= pm.ListCidades(uf);
                   List<RootObject> list = new List<RootObject>();
                   foreach (Cidade c in lc)
                   {
                       RootObject o = new RootObject();
                       o.id = c.id.ToString();
                       o.nome = c.nome;
                       list.Add(o);
                   }

                   JavaScriptSerializer js = new JavaScriptSerializer();
                   string strJson = js.Serialize(list);
                   Response.Write(strJson);
              
            }
                
           
        }
    }
}