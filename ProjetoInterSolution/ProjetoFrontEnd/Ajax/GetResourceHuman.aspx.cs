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
    public partial class GetResourceHuman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {                
                if (Request.Params["acao"] != null && Request.Params["acao"] == "edit")
                {
                    ResourceModel rm = new ResourceModel();
                    Recurso re = new Recurso();
                    re.Tipo = new Tipo();
                    re = rm.GetResource(Int32.Parse(Request.Params["id"]));
                    Response.Write("[{\"descricao\":\"" + re.descricao + "\",\"tipo\":\"" + re.Tipo.descricao + "\",\"hora\":\"" + re.qtd_hora_disponivel + "\", \"valor\":\"" + re.valor + "\"}]");
                
                }                
                else if (Request.Params["acao"] != null && Request.Params["acao"] == "delete")
                {
                    ResourceModel rm = new ResourceModel();
                    rm.Delete(Int32.Parse(Request.Params["id"]));
                }
            }
           
        }
    }
}