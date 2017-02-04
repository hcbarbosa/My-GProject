using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

using System.IO;

namespace ProjetoInter.View
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string pass = Request.QueryString["pass"];
                if (pass == "false")
                {
                    lblPass.Visible = true;
                    lblPass.InnerText = "Invalid Password!";
                }

                string conf = Request.QueryString["conf"];
                if (conf == "false")
                {
                    passConf.Visible = true;
                    passConf.InnerText = "Passwords are different!";
                }

                if (Session["usuario"] is Cliente)
                {

                    Pessoa p = Session["pessoa"] as Pessoa;
                    Cliente c = Session["usuario"] as Cliente;
                    PeopleModel pm = new PeopleModel();
                    user.ImageUrl = "../Images/avatars/" + p.imagem;
                    txtName.Text = p.nome;
                    foreach (Email emails in pm.ListEmails(p.id))
                    {
                        ListItem l = new ListItem(emails.endereco, emails.endereco, true);
                        if (emails.status == 3)
                        {
                            l.Selected = true;
                            selectDefaultEmail.Items.Add(l);
                        }
                        else
                        {
                            selectDefaultEmail.Items.Add(l);
                        }
                    }
                    txtLogin.Text = c.login;
                    txtPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";

                }
                else if (Session["usuario"] is Gerente)
                {
                    Pessoa p = Session["pessoa"] as Pessoa;
                    Gerente g = Session["usuario"] as Gerente;
                    PeopleModel pm = new PeopleModel();
                    user.ImageUrl = "../Images/avatars/" + p.imagem;
                    txtName.Text = p.nome;
                    foreach (Email emails in pm.ListEmails(p.id))
                    {
                        ListItem l = new ListItem(emails.endereco, emails.endereco, true);
                        if (emails.status == 3)
                        {
                            l.Selected = true;
                            selectDefaultEmail.Items.Add(l);
                        }
                        else
                        {
                            selectDefaultEmail.Items.Add(l);
                        }
                    }
                    txtLogin.Text = g.login;
                    txtPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";

                }
                else
                {
                    Response.Redirect("Login.aspx?resp=proibido", false);
                }
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {

            if (Session["usuario"] is Cliente)
            {
                Pessoa pe = Session["pessoa"] as Pessoa;
                Cliente ce = Session["usuario"] as Cliente;
                PeopleModel pm = new PeopleModel();
                CustomerModel cm = new CustomerModel();


                if (txtPassword.Text != null && txtPassword.Text != "")
                {
                    ce.senha = txtPassword.Text;
                    if (cm.IsvalidPass(ce.pessoa_id, ce.senha) == false)
                    {
                        Response.Redirect("Index.aspx#Account.aspx?pass=false");
                    }

                    if (txtNewPassword.Text != txtConfirmPassword.Text)
                    {
                        Response.Redirect("Index.aspx#Account.aspx?conf=false");
                    }
                    else
                    {
                        ce.senha = txtNewPassword.Text;
                        cm.AlterPass(ce.pessoa_id, ce.senha);
                    }
                }
                if (file.HasFile)
                {

                    if (pe.imagem != "user.jpg")
                    {
                        File.Delete(Server.MapPath("../Images/avatars/" + pe.imagem)); //Deleta a imagem     
                        pe.imagem = (DateTime.Now).ToString("dd.MM.yyyy.hh.mm.ss") + "-" + file.FileName;
                        file.SaveAs(Server.MapPath("../Images/avatars/" + pe.imagem));
                        pm.InsertImagem(pe.id, pe.imagem);
                    }
                    else
                    {
                        pe.imagem = (DateTime.Now).ToString("dd.MM.yyyy.hh.mm.ss") + "-" + file.FileName;
                        file.SaveAs(Server.MapPath("../Images/avatars/" + pe.imagem));
                        pm.InsertImagem(pe.id, pe.imagem);
                    }
                }
                if (txtName.Text != pe.nome && txtName.Text != null && txtName.Text != "")
                {
                    pe.nome = txtName.Text;
                    pm.AlterName(pe.id, pe.nome);
                }

                if (selectDefaultEmail.SelectedValue != null)
                {
                    pm.AlterEmail(pe.id, selectDefaultEmail.SelectedValue);
                }

                if (txtLogin.Text != null && txtLogin.Text != "")
                {
                    ce.login = txtLogin.Text;
                    cm.AlterLogin(ce.pessoa_id, ce.login);
                }


            }
            else if (Session["usuario"] is Gerente)
            {
                Pessoa pe = Session["pessoa"] as Pessoa;
                Gerente ge = Session["usuario"] as Gerente;
                PeopleModel pm = new PeopleModel();
                ManagerModel mm = new ManagerModel();


                if (txtPassword.Text != null && txtPassword.Text != "")
                {
                    ge.senha = txtPassword.Text;
                    if (mm.IsvalidPass(ge.pessoa_id, ge.senha) == false)
                    {
                        Response.Redirect("Index.aspx#Account.aspx?pass=false");
                    }

                    if (txtNewPassword.Text != txtConfirmPassword.Text)
                    {
                        Response.Redirect("Index.aspx#Account.aspx?conf=false");
                    }
                    else
                    {
                        ge.senha = txtNewPassword.Text;
                        mm.AlterPass(ge.pessoa_id, ge.senha);
                    }
                }
                if (file.HasFile)
                {
                    if (pe.imagem != "user.jpg")
                    {
                        File.Delete(Server.MapPath("../Images/avatars/" + pe.imagem)); //Deleta a imagem     
                        pe.imagem = (DateTime.Now).ToString("dd.MM.yyyy.hh.mm.ss") + "-" + file.FileName;
                        file.SaveAs(Server.MapPath("../Images/avatars/" + pe.imagem));
                        pm.InsertImagem(pe.id, pe.imagem);
                    }
                    else
                    {
                        pe.imagem = (DateTime.Now).ToString("dd.MM.yyyy.hh.mm.ss") + "-" + file.FileName;
                        file.SaveAs(Server.MapPath("../Images/avatars/" + pe.imagem));
                        pm.InsertImagem(pe.id, pe.imagem);
                    }
                }
                if (txtName.Text != pe.nome && txtName.Text != null && txtName.Text != "")
                {
                    pe.nome = txtName.Text;
                    pm.AlterName(pe.id, pe.nome);
                }

                if (selectDefaultEmail.SelectedValue != null)
                {
                    pm.AlterEmail(pe.id, selectDefaultEmail.SelectedValue);
                }

                if (txtLogin.Text != null && txtLogin.Text != "")
                {
                    ge.login = txtLogin.Text;
                    mm.AlterLogin(ge.pessoa_id, ge.login);
                }



            }
            else
            {
                Pessoa pe = Session["pessoa"] as Pessoa;
                Gerente ge = Session["usuario"] as Gerente;
            }



            Response.Redirect("Index.aspx#Account.aspx", false);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx#Account.aspx", false);
        }



    }




}