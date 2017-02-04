using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class CommentData
    {
        //retorna os comentarios do projeto
        public List<Comentario> ListComentarios(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from c in bd.Comentarios where c.status == 1 && c.projeto_codigo == projeto select c).ToList();
            }
        }

        //comentar no projeto
        public bool Insert(Comentario c)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    bd.Comentarios.InsertOnSubmit(c);
                    bd.SubmitChanges();

                    Cliente cl = new Cliente();
                    cl = bd.Clientes.FirstOrDefault(cli => cli.pessoa_id == c.pessoa_id);
                    if (cl != null)
                    {
                        //notificar o gerente se a pessoa q comentou eh cliente
                        Notificacoe n = new Notificacoe();
                        n.gerente_id = (from p in bd.Projetos where c.projeto_codigo == p.codigo select p.gerente_id).FirstOrDefault();
                        n.informacao = "" + (from pe in bd.Pessoas where pe.id == c.pessoa_id select pe.nome).FirstOrDefault();
                        n.informacao += " commented in the project " + (from p in bd.Projetos where c.projeto_codigo == p.codigo select p.nome).FirstOrDefault();
                        n.informacao += ".";
                        n.projeto_codigo = c.projeto_codigo;
                        n.status = 1;
                        NotificationData nd = new NotificationData();
                        nd.Insert(n);
                        //manda email pra gerente e outras pessoas
                        //gerente
                        /*string msg = (from pe in bd.Pessoas where pe.id == c.pessoa_id select pe.nome).FirstOrDefault();
                        msg += " commented: " + c.descricao;
                        msg += ". In the project: " + (from pr in bd.Projetos where c.projeto_codigo == pr.codigo select pr.nome).FirstOrDefault();
                        string email = (from e in bd.Emails where e.pessoa_id == n.gerente_id && e.status == 3 select e.endereco).FirstOrDefault();
                        string assunto = "MyGProject - Comment in the project";
                        CustomerData cd = new CustomerData();
                        cd.SendEmailCliente(email, msg, assunto);
                        //outros clientes
                        List<ProjetosEmpresasCliente> lpec = new List<ProjetosEmpresasCliente>();
                        lpec = (from p in bd.ProjetosEmpresasClientes where p.projeto_codigo == c.projeto_codigo && p.status == 1 && p.cliente_id != c.pessoa_id select p).ToList();
                        foreach (ProjetosEmpresasCliente p in lpec)
                        {
                            msg = (from pe in bd.Pessoas where pe.id == c.pessoa_id select pe.nome).FirstOrDefault();
                            msg += " commented: " + c.descricao;
                            msg += ". In the project: " + (from pr in bd.Projetos where c.projeto_codigo == pr.codigo select pr.nome).FirstOrDefault();
                            email = (from e in bd.Emails where e.pessoa_id == p.cliente_id && e.status == 3 select e.endereco).FirstOrDefault();
                            assunto = "MyGProject - Comment in the project";
                            cd.SendEmailCliente(email, msg, assunto);
                        }
                         */
                    }
                    else
                    {
                        //manda email pra os clientes
                       /* List<ProjetosEmpresasCliente> lpec = new List<ProjetosEmpresasCliente>();
                        lpec = (from p in bd.ProjetosEmpresasClientes where p.projeto_codigo == c.projeto_codigo && p.status == 1 select p).ToList();
                        foreach (ProjetosEmpresasCliente p in lpec)
                        {
                            string msg = (from pe in bd.Pessoas where pe.id == c.pessoa_id select pe.nome).FirstOrDefault();
                            msg += " commented: " + c.descricao;
                            msg += ". In the project: " + (from pr in bd.Projetos where c.projeto_codigo == pr.codigo select pr.nome).FirstOrDefault();
                            string email = (from e in bd.Emails where e.pessoa_id == p.cliente_id && e.status == 3 select e.endereco).FirstOrDefault();
                            string assunto = "MyGProject - Comment in the project";
                            CustomerData cd = new CustomerData();
                            cd.SendEmailCliente(email, msg, assunto);
                        }
                        */
                    }
                    //log
                    DateTime data = DateTime.Now;
                    string desc = "" + (from pe in bd.Pessoas where pe.id == c.pessoa_id select pe.nome).FirstOrDefault();
                    desc += " commented in the project.";
                    int pessoa = c.pessoa_id;
                    int projeto = c.projeto_codigo;
                    LogData ld = new LogData();
                    ld.Insert(projeto, data, desc, pessoa);

                }
                ok = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }

        //apaga comentario
        public void Delete(int id)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Comentario co = bd.Comentarios.FirstOrDefault(c=> c.id == id);
                co.status = 0;
                bd.SubmitChanges();
            }
        }

    }
}
