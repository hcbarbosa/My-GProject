using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//chamando para usar email
using System.Net.Mail;
using System.Net.Configuration;

namespace ProjetoBackEnd.Data
{
    class CustomerData
    {
        public CustomerData() { }

        //verifica se o login é valido
        public Cliente IsvalidUser(string login, string password)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Cliente cliente = (from c in bd.Clientes
                                   from p in bd.Pessoas
                                   where c.pessoa_id == p.id &&
                                   c.login == login
                                   && c.senha == password &&
                                   p.status == 1
                                   select c).FirstOrDefault();

                return cliente;
            }
        }
        //Verifica senha do cliente pelo id
        public bool IsvalidPass(int id, string password)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Cliente cliente = (from c in bd.Clientes
                                   where c.pessoa_id == id
                                   && c.senha == password
                                   select c).FirstOrDefault();
                if (cliente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Altera login de um customer pelo id
        public bool AlterLogin(int id, string login)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var clilogin = (from c in bd.Clientes where c.pessoa_id == id select c).FirstOrDefault();
                    clilogin.login = login;
                    bd.SubmitChanges();
                }

                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }
        //Altera a senha de um customer pelo id
        public bool AlterPass(int id, string pass)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var clipass = (from c in bd.Clientes where c.pessoa_id == id select c).FirstOrDefault();
                    clipass.senha = pass;
                    bd.SubmitChanges();
                }

                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }


        //pega uma pessoa a partir de um codigo
        public Pessoa GetPessoa(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Pessoa cliente = (from c in bd.Pessoas
                                  where c.id == codigo
                                  select c).FirstOrDefault();

                return cliente;
            }

        }

        //pega um cliente com pessoa, cidade, estado
        public Cliente GetCliente(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Pessoa pessoa = (from c in bd.Pessoas
                                  where c.id == codigo
                                  select c).FirstOrDefault();
                Cidade cid = (from c in bd.Cidades 
                              where c.id == pessoa.cidade_id
                              select c).FirstOrDefault();
                Estado est = (from e in bd.Estados
                              where e.sigla == cid.estado_sigla
                              select e).FirstOrDefault();

                Cliente cliente = (from c in bd.Clientes
                                   where c.pessoa_id == codigo
                                   select c).FirstOrDefault();
                cliente.Pessoa = new Pessoa();
                cliente.Pessoa.Cidade = new Cidade();
                cliente.Pessoa.Cidade.Estado = new Estado();
                cliente.Pessoa = pessoa;
                cliente.Pessoa.Cidade = cid;
                cliente.Pessoa.Cidade.Estado = est;

                return cliente;
            }
        }
//pega uma lista das pessoas que sao clientes inativos
        public List<Pessoa> GetPessoasInat()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Pessoa> l = new List<Pessoa>();

                l = (from e in bd.Clientes
                     from p in bd.Pessoas
                     where p.id == e.pessoa_id && p.status == 0
                     orderby p.nome
                     select p).ToList();
                return l;
            }
        }
        //pega uma lista de clientes
        public List<Cliente> GetClientes()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cliente> l = new List<Cliente>();
                l = (from c in bd.Clientes
                     from p in bd.Pessoas
                     where c.pessoa_id == p.id && p.status == 1
                     orderby p.nome
                     select c).ToList();
                return l;
            }
        }

        //pega uma lista de pessoas ativas
        public List<Pessoa> ListPessoas()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Pessoa> l = new List<Pessoa>();
                l = (from c in bd.Clientes
                     from p in bd.Pessoas
                     where c.pessoa_id == p.id && p.status == 1
                     orderby p.nome
                     select p).ToList();
                return l;
            }
        }

        //recupera pessoas por empresa
        public List<Pessoa> GetPessoas(int idcompany)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Pessoa> l = new List<Pessoa>(); 
                l = (from c in bd.Clientes join 
                         p in bd.Pessoas on c.pessoa_id equals p.id join
                         ec in bd.EmpresasClientes on c.pessoa_id equals ec.cliente_id
                     where ec.empresa_id.Equals(idcompany) && ec.status == 1 && p.status == 1
                     orderby p.nome
                     select p).ToList();
                foreach (Pessoa p in l)
                {
                    p.Cliente = new Cliente();
                    p.Cliente = (from c in bd.Clientes where c.pessoa_id == p.id select c).FirstOrDefault();
                }

                return l;
            }
        }

        //pega a empresa do cliente
        public string GetEmpresaDoCliente(int cliente)
        {
             using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                 string l = (from ce in bd.EmpresasClientes from em in bd.Pessoas
                     where ce.cliente_id == cliente && em.id == ce.empresa_id && ce.status == 1
                     select em.nome).FirstOrDefault();
                return l;
            }
        }
        

        //insere um cliente com todas suas informacoes e faz o relacionamento com a empresaclientes
        public bool Insert(Pessoa p,string[] emails, string[] telefones, int company)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bool ok = false;
                try
                {
                    bd.Pessoas.InsertOnSubmit(p);
                    bd.SubmitChanges();            
                    Email email;
                    Telefone telefone;
                    EmpresasCliente emp = new EmpresasCliente();
                    emp.status = 1;
                    emp.empresa_id = company;
                    emp.cliente_id = p.id;
                    bd.EmpresasClientes.InsertOnSubmit(emp);
                    bd.SubmitChanges();
                    for (int i = 0; i < emails.Length; i++)
                    {
                        email = new Email();
                        email.pessoa_id = p.id;
                        if(i!=0)
                        {
                            email.endereco = emails[i];
                            email.status = 1;
                        }
                        else{
                            if(emails[i]!=null){
                            email.endereco = emails[i];
                            email.status = 3;
                            }
                        }                        
                        bd.Emails.InsertOnSubmit(email);
                        bd.SubmitChanges();
                    }
                    for (int i = 0; i < telefones.Length; i++)
                    {
                        telefone = new Telefone();
                        telefone.pessoa_id = p.id;
                        if (i != 0)
                        {
                            telefone.numero = telefones[i];
                            telefone.status = 1;
                        }
                        else
                        {
                            if(telefones[i]!=null){
                            telefone.numero = telefones[i];
                            telefone.status = 3;
                            }
                        }                        
                        bd.Telefones.InsertOnSubmit(telefone);
                        bd.SubmitChanges();
                    }

                    
                    ok = true;
                }
                catch (Exception ed)
                {
                    Console.WriteLine(ed.Message);
                }
                return ok;
            }
        }


        //altera o cliente
        public bool Update(Pessoa p, string[] emails, string[] telefones, int company)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bool ok = false;
                try
                {
                    Pessoa pessoadobanco = bd.Pessoas.Single(pe => pe.id.Equals(p.id));
                    pessoadobanco.Cliente = bd.Clientes.Single(cl => cl.pessoa_id.Equals(p.id));

                    pessoadobanco.nome = p.nome;
                    pessoadobanco.Cliente.cpf = p.Cliente.cpf;
                    pessoadobanco.Cliente.profissao = p.Cliente.profissao;
                    pessoadobanco.cep = p.cep;
                    pessoadobanco.logradouro = p.logradouro;
                    pessoadobanco.numero = p.numero;
                    pessoadobanco.bairro = p.bairro;
                    pessoadobanco.complemento = p.complemento;
                    pessoadobanco.cidade_id = p.cidade_id;
                    pessoadobanco.status = 1;

                    bd.SubmitChanges();

                    EmpresasCliente emp = bd.EmpresasClientes.FirstOrDefault(empcl => empcl.cliente_id.Equals(p.id) && empcl.status == 1);

                    if (emp.empresa_id != company)
                    {
                        emp.status = 0;
                        bd.SubmitChanges();
                        EmpresasCliente empteste = bd.EmpresasClientes.FirstOrDefault(empcl => empcl.cliente_id.Equals(p.id) && empcl.status == 0 && empcl.empresa_id == company);
                        if (empteste != null)
                        {
                            empteste.status = 1;
                            bd.SubmitChanges();
                        }
                        else
                        {
                            EmpresasCliente empnovo = new EmpresasCliente();
                            empnovo.empresa_id = company;
                            empnovo.cliente_id = p.id;
                            empnovo.status = 1;
                            bd.EmpresasClientes.InsertOnSubmit(empnovo);
                            bd.SubmitChanges();
                        }
                    }

                    bd.ExecuteCommand("DELETE FROM Emails WHERE pessoa_id = {0}",p.id);
                    bd.ExecuteCommand("DELETE FROM Telefones WHERE pessoa_id = {0}", p.id);

                    List<Email> listaemailsedit = new List<Email>();
                    List<Telefone> listatelefonesedit = new List<Telefone>();
                    Email email;
                    Telefone telefone;

                    //cria lista do edit
                    for (int i = 0; i < emails.Length; i++)
                    {
                        email = new Email();
                        email.pessoa_id = p.id;
                        if (i != 0)
                        {
                            email.endereco = emails[i];
                            email.status = 1;
                        }
                        else
                        {
                            email.endereco = emails[i];
                            email.status = 3;
                        }
                        listaemailsedit.Add(email);
                    }

                    for (int i = 0; i < telefones.Length; i++)
                    {
                        telefone = new Telefone();
                        telefone.pessoa_id = p.id;
                        if (i != 0)
                        {
                            telefone.numero = telefones[i];
                            telefone.status = 1;
                        }
                        else
                        {
                            if (telefones[i] != null)
                            {
                                telefone.numero = telefones[i];
                                telefone.status = 3;
                            }
                        }
                        listatelefonesedit.Add(telefone);
                    }


                    foreach (Email e in listaemailsedit) 
                    {

                        bd.Emails.InsertOnSubmit(e);
                        bd.SubmitChanges();
                    
                    }

                    foreach (Telefone t in listatelefonesedit) 
                    {

                        bd.Telefones.InsertOnSubmit(t);
                        bd.SubmitChanges();
                    }


                    ok = true;
                }
                catch (Exception ed)
                {
                    Console.WriteLine(ed.Message);
                }
                return ok;
            }
        }



        //muda o status do para 0 ou seja esta excluido pois na tabela de consulta a funcao pega apenas o q tem status = 1
        public bool Delete(int id)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Pessoa p = bd.Pessoas.Single(pe => pe.id.Equals(id));
                    p.status = 0;
                    bd.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }

        //manda email de notificacao
        public void SendEmailCliente(string email, string msg, string assunto)
        {
            string remetenteEmail = "mygprojectfatec@gmail.com"; //O e-mail do remetente
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(remetenteEmail, "MyGProject", System.Text.Encoding.UTF8);
            mail.Subject = assunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = msg;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
 public bool Ativar(int id)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Pessoa p = bd.Pessoas.Single(pe => pe.id.Equals(id));
                    p.status = 1;
                    bd.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }

        }

    }

