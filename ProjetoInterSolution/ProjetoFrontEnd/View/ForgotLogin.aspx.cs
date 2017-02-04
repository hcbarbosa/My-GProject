using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//chamando para usar email
using System.Net.Mail;
using System.Net.Configuration;


using ProjetoBackEnd.Model;

namespace ProjetoInter.View
{
    public partial class ForgotLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string resp = Request.QueryString["resp"];
                if (resp == "false")
                {
                    resposta.Text = "Please, enter with default email.";
                }
            }
        }

        protected void send_Click(object sender, EventArgs e)
        {
            try
            {

                PeopleModel pm = new PeopleModel();
                
                if (pm.IsValidEmail(Request.Params["email"]))
                {
                    resposta.Text = pm.GetLoginPessoa(pm.GetIdLoginPessoa(Request.Params["email"]));

                    string remetenteEmail = "mygprojectfatec@gmail.com"; //O e-mail do remetente
                    MailMessage mail = new MailMessage();
                    mail.To.Add(Request.Params["email"]);
                    mail.From = new MailAddress(remetenteEmail, "MyGProject", System.Text.Encoding.UTF8);
                    mail.Subject = "MyGProject - Forgot Login";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.Body = pm.GetLoginPessoa(pm.GetIdLoginPessoa(Request.Params["email"]));
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High; //Prioridade do E-Mail
                    SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
                    client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "inter22014");
                    client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio
                    client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
                    client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
                    try
                    {
                        client.Send(mail);
                        client.Dispose();
                        Response.Redirect("Login.aspx?resp=sent",false);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Login.aspx?resp=notsent&error=" +ex.Message,false);
                    }

                }
                else
                {
                    Response.Redirect("ForgotLogin.aspx?resp=false",false);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx",false);
        }
    }
}