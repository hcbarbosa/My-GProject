using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class ProjectData
    {
        LogData ld = new LogData();

        //pega uma lista de projetos do cliente que estao no banco independente de estarem em progresso, cancelados, concluidos
        public List<Projeto> ListProjetosGerente(int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Projeto> l = new List<Projeto>();
                l = (from p in bd.Projetos where p.gerente_id == pessoa select p).ToList();
                return l;
            }
        }


        //pega uma lista de projetos do cliente que estao no banco independente de estarem em progresso, cancelados, concluidos
        public List<Projeto> ListProjetosCliente(int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                List<ProjetosEmpresasCliente> pec = new List<ProjetosEmpresasCliente>();
                pec = (from pe in bd.ProjetosEmpresasClientes where pe.cliente_id == pessoa && pe.status == 1 select pe).ToList();

                List<Projeto> l = new List<Projeto>();
                foreach(ProjetosEmpresasCliente pe2 in pec)
                {
                    l.Add((from p in bd.Projetos where p.codigo == pe2.projeto_codigo select p).FirstOrDefault());
                }
                return l;
            }
        }

        //pega o nome da empresa de onde aquele projeto pertence
        public string GetEmpresaProjeto(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                int emp =  (from p in bd.ProjetosEmpresasClientes where p.projeto_codigo == codigo select p.empresa_id).FirstOrDefault();
                string empresa = (from p in bd.Pessoas where p.id == emp select p.nome).FirstOrDefault();
                return empresa;
            }
        }
        
        //pegar um projeto por codigo
        public Projeto GetProjeto(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return bd.Projetos.FirstOrDefault(p=> p.codigo == codigo);
            }
        }


        //inserir um projeto
        public bool Insert(Projeto p, int company, string[] clientes, DataTable dt)
        {
             bool res = false ;

             using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
             {
                 try
                 {
                    
                     bd.Projetos.InsertOnSubmit(p);
                     bd.SubmitChanges();

                     DateTime data = DateTime.Now;
                     string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                     msg += " created the project.";
                     int pessoa = p.gerente_id;
                     int projeto = p.codigo;
                     ld.Insert(projeto, data, msg, pessoa);


                     int i= 0 ;
                     ProjetosEmpresasCliente emp;
                     for (i = 0; i < clientes.Count(); i++)
                     {
                         emp = new ProjetosEmpresasCliente();
                         emp.projeto_codigo = p.codigo;
                         emp.empresa_id = company;
                         emp.cliente_id = Int32.Parse(clientes[i]);
                         emp.status = 1;
                         bd.ProjetosEmpresasClientes.InsertOnSubmit(emp);
                         bd.SubmitChanges();

                         
                         data = DateTime.Now;
                         msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                         msg += " add the customer " + (from pe in bd.Pessoas where pe.id == emp.cliente_id select pe.nome).FirstOrDefault();
                         msg += " in the project.";
                         pessoa = p.gerente_id;
                         projeto = p.codigo;
                         ld.Insert(projeto, data, msg, pessoa);

                         msg = (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                         msg += " add you " + (from pe in bd.Pessoas where pe.id == emp.cliente_id select pe.nome).FirstOrDefault();
                         msg += " in the project: " + p.nome;
                         string email = (from e in bd.Emails where e.pessoa_id == emp.cliente_id && e.status == 3 select e.endereco).FirstOrDefault();
                         string assunto = "MyGProject - You were added in the project";
                         CustomerData cd = new CustomerData();
                         //cd.SendEmailCliente(email, msg, assunto);
                     }
                                        
                     Cronograma cr;                    

                     foreach (DataRow dr in dt.Rows)
                     {
                         cr = new Cronograma();
                         cr.projeto_codigo = p.codigo;
                         cr.fase_numero = Int32.Parse(dr["step"].ToString());
                         cr.atividade_numero = Int32.Parse(dr["activity"].ToString());
                         cr.documento_numero = null;
                         cr.status = 1;
                         bd.Cronogramas.InsertOnSubmit(cr);
                         bd.SubmitChanges();

                         data = DateTime.Now;
                         msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                         msg += " create the activity " + (from a in bd.Atividades where a.numero == cr.atividade_numero select a.nome).FirstOrDefault();
                         msg += " in the step " + (from f in bd.Fases where f.numero == cr.fase_numero select f.nome).FirstOrDefault();
                         msg += ".";
                         pessoa = p.gerente_id;
                         projeto = p.codigo;
                         ld.Insert(projeto, data, msg, pessoa);
                         res = true;
                     }     
                 }
                 catch (Exception e)
                 {
                     res = false; 
                     Console.WriteLine(e.Message);
                 }
                 return res;
             }
        }

        //cancelar projeto e tudo q ele tiver dentro
        public bool Delete(int codigo)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    //muda status projeto
                    Projeto p = bd.Projetos.Single(pe => pe.codigo.Equals(codigo));
                    p.status = 0;
                    bd.SubmitChanges();

                    DateTime data = DateTime.Now;
                    string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                    msg += " deactive the project " + p.nome;
                    msg += ".";
                    int pessoa = p.gerente_id;
                    int projeto = p.codigo;
                    ld.Insert(projeto, data, msg, pessoa);

                    //pega lista do cronograma
                    List<Cronograma> cr = new List<Cronograma>();
                    cr = (from c in bd.Cronogramas where c.projeto_codigo == codigo select c).ToList();
                    //como nao iremos mudar o status de fases e atividades pois caso o gerente deseja reativar o projeto
                    //as fases e atividades estariam do jeito q ele deixo
                    //faz vetores das fases e atividades do projeto
                    //int[] fases = new int[cr.Count];
                    //int[] atividades = new int[cr.Count];
                    //int f = 0, a = 0;
                    foreach(Cronograma c in cr)
                    {
                        /*if (f == 0 && a == 0)
                        {
                            fases[0] = c.fase_numero;
                            f++;
                        }
                        else if (fases[f - 1] != c.fase_numero)
                        {
                            fases[f] = c.fase_numero;
                            f++;
                        }
                            atividades[a] = c.atividade_numero;
                            a++;*/

                        c.status = 0;
                        bd.SubmitChanges();
                    }
                    //muda status das fases do projeto
                    /*Fase fase;
                    for (int i = 0; i < f; i++)
                    {
                        fase = new Fase();
                        fase = bd.Fases.Single(fa=>fa.numero==fases[i]);
                        fase.status = 0;
                        bd.SubmitChanges();
                    }

                    //muda status das atividades do projeto
                    Atividade at;
                    for (int i = 0; i < a; i++)
                    {
                        at = new Atividade();
                        at = bd.Atividades.Single(ati => ati.numero == atividades[i]);
                        at.status = 0;
                        bd.SubmitChanges();
                    }*/
                    ok = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        //reativa projeto e tudo q ele tiver dentro
        public bool Ativar(int codigo)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    //muda status projeto
                    Projeto p = bd.Projetos.Single(pe => pe.codigo.Equals(codigo));
                    p.status = 1;
                    bd.SubmitChanges();

                    DateTime data = DateTime.Now;
                    string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                    msg += " reactive the project " + p.nome;
                    msg += ".";
                    int pessoa = p.gerente_id;
                    int projeto = p.codigo;
                    ld.Insert(projeto, data, msg, pessoa);

                    //pega lista do cronograma
                    List<Cronograma> cr = new List<Cronograma>();
                    cr = (from c in bd.Cronogramas where c.projeto_codigo == codigo select c).ToList();
                    //faz vetores das fases e atividades do projeto
                    //int[] fases = new int[cr.Count];
                    //int[] atividades = new int[cr.Count];
                    //int f = 0, a = 0;
                   foreach (Cronograma c in cr)
                    {
                       /* if (f == 0 && a == 0)
                        {
                            fases[0] = c.fase_numero;
                            f++;
                        }
                        else if (fases[f - 1] != c.fase_numero)
                        {
                            fases[f] = c.fase_numero;
                            f++;
                        }
                        atividades[a] = c.atividade_numero;
                        a++;
                    */
                        c.status = 1;
                        bd.SubmitChanges();
                    }
                    //muda status das fases do projeto
                    /*Fase fase;
                    for (int i = 0; i < f; i++)
                    {
                        fase = new Fase();
                        fase = bd.Fases.Single(fa => fa.numero == fases[i]);
                        fase.status = 1;
                        bd.SubmitChanges();
                    }

                    //muda status das atividades do projeto
                    Atividade at;
                    for (int i = 0; i < a; i++)
                    {
                        at = new Atividade();
                        at = bd.Atividades.Single(ati => ati.numero == atividades[i]);
                        at.status = 1;
                        bd.SubmitChanges();
                    }*/
                    ok = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }






        /////////////// rotina para limpar fases e atividades q nao tem relacionamento no cronograma
        public void RotinaLimpar()
        {
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    List<Fase> fases = new List<Fase>();
                    List<Atividade> ativ = new List<Atividade>();
                    fases = bd.Fases.ToList();
                    ativ = bd.Atividades.ToList();

                    Cronograma cr;
                    foreach(Fase f in fases)
                    {
                        cr = new Cronograma();
                        cr = bd.Cronogramas.FirstOrDefault(c => c.fase_numero == f.numero);
                        if (cr == null)
                        {
                            bd.Fases.DeleteOnSubmit(f);
                            bd.SubmitChanges();
                        }
                    }
                    foreach (Atividade a in ativ)
                    {
                        cr = new Cronograma();
                        cr = bd.Cronogramas.FirstOrDefault(c => c.atividade_numero == a.numero);
                        if (cr == null)
                        {
                            bd.Atividades.DeleteOnSubmit(a);
                            bd.SubmitChanges();
                        }
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //pega clientes do projeto
        public List<Cliente> GetClientesProjeto(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                List<ProjetosEmpresasCliente> pec = new List<ProjetosEmpresasCliente>();
                pec = (from pe in bd.ProjetosEmpresasClientes where pe.projeto_codigo == codigo && pe.status == 1 select pe).ToList();

                List<Cliente> l = new List<Cliente>();
                foreach (ProjetosEmpresasCliente pe2 in pec)
                {
                    l.Add((from p in bd.Clientes where p.pessoa_id == pe2.cliente_id select p).FirstOrDefault());
                }

                foreach (Cliente pes in l)
                {
                    pes.Pessoa = ((from p in bd.Pessoas where p.id == pes.pessoa_id select p).FirstOrDefault());
                }

                return l;
            }
        }

        //retorna projetos que contem oq foi pesquisado para clientes
        public List<Projeto> ListProjetosCliente(string palavra, int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<ProjetosEmpresasCliente> pec = new List<ProjetosEmpresasCliente>();
                pec = (from pe in bd.ProjetosEmpresasClientes where pe.cliente_id == pessoa && pe.status == 1 select pe).ToList();

                List<Projeto> l = new List<Projeto>();
                foreach (ProjetosEmpresasCliente pe2 in pec)
                {
                    Projeto pr = (from p in bd.Projetos where p.codigo == pe2.projeto_codigo && p.nome.Contains(palavra) orderby p.nome ascending select p).FirstOrDefault();
                    if (pr != null)
                    {
                        l.Add(pr);
                    }
                }
                return l;
            }
        }

        //retorna projetos que contem oq foi pesquisado para gerentes
        public List<Projeto> ListProjetosGerente(string palavra, int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from p in bd.Projetos where p.gerente_id==pessoa && p.nome.Contains(palavra) orderby p.nome ascending select p).ToList();
            }
        }

        //alterar projeto
        public bool Update(Projeto p, int empresa, string[] clientes)
        {
            bool res = false;

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                try
                {

                    Projeto projbanco = bd.Projetos.FirstOrDefault(pr => pr.codigo == p.codigo);
                    projbanco.nome = p.nome;
                    projbanco.valor_previsto = p.valor_previsto;
                    projbanco.data_termino = p.data_termino;
                    projbanco.data_inicio = p.data_inicio;
                    projbanco.modelo_numero = p.modelo_numero;
                    bd.SubmitChanges();

                    DateTime data = DateTime.Now;
                    string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                    msg += " edited the project.";
                    int pessoa = projbanco.gerente_id;
                    int projeto = p.codigo;
                    ld.Insert(projeto, data, msg, pessoa);


                    int i = 0;
                    ProjetosEmpresasCliente emp;
                    for (i = 0; i < clientes.Count(); i++)
                    {
                        emp = new ProjetosEmpresasCliente();
                        emp = bd.ProjetosEmpresasClientes.FirstOrDefault(pec => pec.empresa_id == empresa && pec.projeto_codigo == projbanco.codigo && pec.status == 1);
                        if (emp != null)
                        {
                            emp = new ProjetosEmpresasCliente();
                            emp = bd.ProjetosEmpresasClientes.FirstOrDefault(pec => pec.cliente_id == Int32.Parse(clientes[i]));
                            if (emp == null)
                            {

                                emp = new ProjetosEmpresasCliente();
                                emp.projeto_codigo = p.codigo;
                                emp.empresa_id = empresa;
                                emp.cliente_id = Int32.Parse(clientes[i]);
                                emp.status = 1;
                                bd.ProjetosEmpresasClientes.InsertOnSubmit(emp);
                                bd.SubmitChanges();

                                data = DateTime.Now;
                                msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                                msg += " add the customer " + (from pe in bd.Pessoas where pe.id == emp.cliente_id select pe.nome).FirstOrDefault();
                                msg += " in the project.";
                                pessoa = projbanco.gerente_id;
                                projeto = p.codigo;
                                ld.Insert(projeto, data, msg, pessoa);

                                msg = (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                                msg += " add you " + (from pe in bd.Pessoas where pe.id == emp.cliente_id select pe.nome).FirstOrDefault();
                                msg += " in the project: " + p.nome;
                                string email = (from e in bd.Emails where e.pessoa_id == emp.cliente_id && e.status == 3 select e.endereco).FirstOrDefault();
                                string assunto = "MyGProject - You were added in the project";
                                CustomerData cd = new CustomerData();
                                cd.SendEmailCliente(email, msg, assunto);
                            }
                            else if(emp.status == 0)
                            {
                                emp.status = 1;
                                bd.SubmitChanges();
                            }
                        }
                        else
                        {
                            List<ProjetosEmpresasCliente> lpec = new List<ProjetosEmpresasCliente>();
                            lpec = (from pec in bd.ProjetosEmpresasClientes where pec.status == 1 && pec.projeto_codigo == p.codigo select pec).ToList();
                            foreach (ProjetosEmpresasCliente pec in lpec)
                            {
                                pec.status = 0;
                                bd.SubmitChanges();
                            }
                            emp = new ProjetosEmpresasCliente();
                            emp.projeto_codigo = p.codigo;
                            emp.empresa_id = empresa;
                            emp.cliente_id = Int32.Parse(clientes[i]);
                            emp.status = 1;
                            bd.ProjetosEmpresasClientes.InsertOnSubmit(emp);
                            bd.SubmitChanges();

                            data = DateTime.Now;
                            msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                            msg += " add the customer " + (from pe in bd.Pessoas where pe.id == emp.cliente_id select pe.nome).FirstOrDefault();
                            msg += " in the project.";
                            pessoa = projbanco.gerente_id;
                            projeto = p.codigo;
                            ld.Insert(projeto, data, msg, pessoa);

                            msg = (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                            msg += " add you " + (from pe in bd.Pessoas where pe.id == emp.cliente_id select pe.nome).FirstOrDefault();
                            msg += " in the project: " + p.nome;
                            string email = (from e in bd.Emails where e.pessoa_id == emp.cliente_id && e.status == 3 select e.endereco).FirstOrDefault();
                            string assunto = "MyGProject - You were added in the project";
                            CustomerData cd = new CustomerData();
                            cd.SendEmailCliente(email, msg, assunto);
                        }
                    }

                    List<Cliente> lc = GetClientesProjeto(p.codigo);
                    int aux = 0;
                    foreach(Cliente c in lc)
                    {
                        for (i = 0; i < clientes.Count(); i++)
                        {
                            if (c.pessoa_id == Int32.Parse(clientes[i]))
                            {
                                aux = 1;
                            }
                        }
                        if (aux == 0)
                        {
                            ProjetosEmpresasCliente prc = bd.ProjetosEmpresasClientes.FirstOrDefault(pr => pr.cliente_id == c.pessoa_id && pr.status == 1);
                            prc.status = 0;
                            bd.SubmitChanges();

                        }
                        aux = 0;
                    }


                    res = true;
                }
                catch (Exception ex)
                {
                    res = false;
                }
                return res;
            }
        }
              
         //completar projeto
        public bool Complete(int codigo)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    //muda status projeto
                    Projeto p = bd.Projetos.Single(pe => pe.codigo.Equals(codigo));
                    p.status = 3;
                    bd.SubmitChanges();

                    DateTime data = DateTime.Now;
                    string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                    msg += " completed the project " + p.nome;
                    msg += ".";
                    int pessoa = p.gerente_id;
                    int projeto = p.codigo;
                    ld.Insert(projeto, data, msg, pessoa);
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
            }
                return ok;
      }


        public void UpdateValor(Projeto p)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                try
                {
                    Projeto projbanco = bd.Projetos.FirstOrDefault(pr => pr.codigo == p.codigo);
                    projbanco.valor_utilizado = p.valor_utilizado;
                    bd.SubmitChanges();
                }
                catch (Exception e)
                {
                }
            }
        }

    }
}
