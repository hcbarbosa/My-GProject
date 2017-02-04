using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Model;
using ProjetoBackEnd.Data;

namespace ProjetoInter.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            if(!IsPostBack)
            {   
                string resp = Request.QueryString["resp"];
                if(resp=="proibido")
                {
                    resposta.Text = "You are not allowed to access the system. <br /> Please, log in your account.";
                }
                else if (resp == "false")
                {
                    resposta.Text = "Login or password are invalids.";
                }
                else if(resp=="sent")
                {
                    resposta.ForeColor = System.Drawing.Color.Green;
                    resposta.Text = "Login sent to your deafult email. ";
                }
                else if (resp == "notsent")
                {
                    resposta.Text = "Login not sent. Error: "+Request.Params["error"];
                }
            }

        }

        protected void ok_Click(object sender, EventArgs e)
        {
            try {

                CustomerModel cm = new CustomerModel();
                ManagerModel mm = new ManagerModel();
                
                if(cm.IsvalidUser(Request.Params["login"],Request.Params["password"])!=null)
                {
                    Cliente c = cm.IsvalidUser(Request.Params["login"], Request.Params["password"]);
                    Pessoa p = cm.GetPessoa(c.pessoa_id);
                    Session["usuario"] = c;
                    Session["pessoa"] = p;
                    Response.Redirect("Index.aspx",false);

                }
                else if (mm.IsvalidUser(Request.Params["login"], Request.Params["password"])!= null)
                {
                    Gerente g = mm.IsvalidUser(Request.Params["login"], Request.Params["password"]);
                    Pessoa p = mm.GetPessoa(g.pessoa_id);
                    Session["usuario"] = g;
                    Session["pessoa"] = p;
                    Response.Redirect("Index.aspx",false);
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx?resp=false",false);
                }

            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}