using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoInter.View
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is Cliente)
            {
                Pessoa p = Session["pessoa"] as Pessoa;
                Cliente c = Session["usuario"] as Cliente;
                imguser.ImageUrl = "../Images/avatars/"+p.imagem;
                usuario.Text = p.nome;
                comecocoment.Text = "<!--";
                fimcoment.Text = "-->";
                painelnavegacao.Text = "<ul>"+
                                            "<li class=''>" +
                                                "<a href='Home.aspx' title='Home'><i class='fa fa-lg fa-fw fa-home'></i><span class='menu-item-parent'>Home</span></a>"+
                                            "</li>"+
                                            "<li>"+
                                                "<a href='Documents.aspx'><i class='fa fa-lg fa-fw fa-file-text'></i><span class='menu-item-parent'>Documents</span></a>"+
                                            "</li> "+               
                                             "<li>"+
                                                "<a href='Projects.aspx' title='Projects'><i class='fa fa-lg fa-fw fa-folder-open'></i><span class='menu-item-parent'>Projects</span></a>"+
                                           "</li>"+
                                            "<li>"+
                                                "<a href='Reports.aspx'><i class='fa fa-lg fa-fw fa-bar-chart-o'></i><span class='menu-item-parent'>Reports</span></a>"+
                                            "</li>"+
                                              "<li>"+
                                                "<a href='#' title='Projects'><i class='fa fa-lg fa-fw fa-sort-amount-asc'></i><span class='menu-item-parent'>Schedule</span></a>"+
                                                    "<ul>"+
                                                    "<li>"+
                                                        "<a href='Gantt.aspx'>Gantt</a>"+
                                                    "</li>"+
                                                    "<li>"+
                                                        "<a href='Table.aspx'>Table</a>"+
                                                    "</li>"+                       
                                                "</ul>"+
                                             "</li> "+
                                        "</ul>";
            }
            else if (Session["usuario"] is Gerente)
            {
                Pessoa p = Session["pessoa"] as Pessoa;
                Gerente g = Session["usuario"] as Gerente;
                imguser.ImageUrl = "../Images/avatars/"+p.imagem;
                usuario.Text = p.nome;
                NotificationModel nm = new NotificationModel();
                numeronotificacao.Text = "" +nm.PegaNumerodeNaoLida(p.id);

                painelnavegacao.Text = "<ul>" +
                                            "<li class=''>" +
                                                "<a href='Home.aspx' title='Home'><i class='fa fa-lg fa-fw fa-home'></i><span class='menu-item-parent'>Home</span></a>" +
                                            "</li>" +
                                            "<li>" +
                                                "<a href='Calendar.aspx'><i class='fa fa-lg fa-fw fa-calendar'></i> <span class='menu-item-parent'>Calendar</span></a>" +
                                            "</li>" +
                                            "<li>" +
                                                "<a href='Companies.aspx'><i class='fa fa-lg fa-fw fa-building'></i><span class='menu-item-parent'>Companies</span><span class='badge pull-right inbox-badge'></span></a>" +
                                            "</li>" +
                                            "<li>" +
                                               "<a href='Customers.aspx'><i class='fa fa-lg fa-fw fa-user'></i><span class='menu-item-parent'>Customers</span><span class='badge pull-right inbox-badge'></span></a>" +
                                            "</li>" +
                                            "<li>" +
                                                "<a href='Documents.aspx'><i class='fa fa-lg fa-fw fa-file-text'></i><span class='menu-item-parent'>Documents</span></a>" +
                                            "</li> " +
                                             "<li>" +
                                                "<a href='Projects.aspx' title='Projects'><i class='fa fa-lg fa-fw fa-folder-open'></i><span class='menu-item-parent'>Projects</span></a>" +
                                           "</li>" +
                                            "<li>" +
                                                "<a href='Reports.aspx'><i class='fa fa-lg fa-fw fa-bar-chart-o'></i><span class='menu-item-parent'>Reports</span></a>" +
                                            "</li>" +
                                            "<li>" +
                                                "<a href='Resources.aspx'><i class='fa fa-lg fa-fw fa-pencil-square-o'></i><span class='menu-item-parent'>Resources</span></a> " +
                                            "</li>  " +
                                              "<li>" +
                                                "<a href='#' title='Projects'><i class='fa fa-lg fa-fw fa-sort-amount-asc'></i><span class='menu-item-parent'>Schedule</span></a>" +
                                                    "<ul>" +
                                                    "<li>" +
                                                        "<a href='Gantt.aspx'>Gantt</a>" +
                                                    "</li>" +
                                                    "<li>" +
                                                        "<a href='Table.aspx'>Table</a>" +
                                                    "</li>" +
                                                "</ul>" +
                                             "</li> " +
                                            "<li>" +
                                                "<a href='Admin.aspx'><i class='fa fa-lg fa-fw fa-repeat'></i><span class='menu-item-parent'>Reactivate</span></a> " +
                                            "</li> " +
                                        "</ul>";

            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido",false);
            }
        }
    }
}