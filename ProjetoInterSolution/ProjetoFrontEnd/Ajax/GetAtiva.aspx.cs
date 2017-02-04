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
    public partial class GetAtiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["company"] != null)
            {
                int id = Int32.Parse(Request.Params["company"]);
                CompanyModel cm = new CompanyModel();
                cm.Ativar(id);
            }

            else if (Request.Params["customer"] != null)
            {
                int id = Int32.Parse(Request.Params["customer"]);
                CustomerModel cm = new CustomerModel();
                cm.Ativar(id);
            }

            else if (Request.Params["resource"] != null)
            {
                int id = Int32.Parse(Request.Params["resource"]);
                ResourceModel rm = new ResourceModel();
                rm.Ativar(id);
            }
        }
    }
}