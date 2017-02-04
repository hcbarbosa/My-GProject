using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class ActivityData
    {
        //inserir uma atividade no wizard do projeto por isso o retorno do objeto
        public Atividade Insert(Atividade a)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bd.Atividades.InsertOnSubmit(a);
                bd.SubmitChanges();
                return a;
            }
        }

        //pega uma atividade a partir de um numero
        public Atividade GetAtividade(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return bd.Atividades.FirstOrDefault(a => a.numero == numero);                
            }
        }

        //pega uma atividade a partir de um numero
        public Fase GetFaseDaAtividade(int at)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from c in bd.Cronogramas from f in bd.Fases where c.atividade_numero == at && c.fase_numero == f.numero select f).FirstOrDefault();
            }
        }


        //pegar atividades pelo numero da fase 
        public List<Atividade> GetAtividadesFase(int fase)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cronograma> cr = new List<Cronograma>();
                cr = (from c in bd.Cronogramas where c.fase_numero == fase select c).ToList();
                List<Atividade> l = new List<Atividade>();
                foreach(Cronograma c in cr)
                {
                    l.Add((from a in bd.Atividades where a.numero == c.atividade_numero select a).FirstOrDefault());
                }
                return l;
            }
        }

       
        //pegar todas as atividades do projeto
        public List<Cronograma> GetAtividadesProjeto(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cronograma> cr = new List<Cronograma>();
                cr = (from c in bd.Cronogramas where c.projeto_codigo == projeto orderby c.fase_numero ascending select c).ToList();
                return cr;
            }
        }

        //pegar numero de atividades da fase
        public int CountAtividades(int fase)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from c in bd.Cronogramas where c.fase_numero == fase select c).Count();
            }
        }

        //pegar lista de atividades do dia para cliente
        public List<Atividade> ListAtividadesdodiaCliente(int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                DateTime data = DateTime.Now;
                data = DateTime.Parse((data.ToString()).Substring(0, 10));
                List<Atividade> l = new List<Atividade>();
                List<ProjetosEmpresasCliente> pec = new List<ProjetosEmpresasCliente>();
                pec = (from pe in bd.ProjetosEmpresasClientes where pe.cliente_id == pessoa && pe.status == 1 select pe).ToList();

                List<Projeto> lp = new List<Projeto>();
                foreach (ProjetosEmpresasCliente pe2 in pec)
                {
                    lp.Add((from p in bd.Projetos where p.codigo == pe2.projeto_codigo select p).FirstOrDefault());
                }
                List<Cronograma> cr;
                Atividade a;
                foreach (Projeto p in lp)
                {
                    cr = new List<Cronograma>();
                    cr = (from c in bd.Cronogramas where c.projeto_codigo == p.codigo && c.status == 1 select c).ToList();
                    foreach (Cronograma c in cr)
                    {
                        a = new Atividade();
                        a = bd.Atividades.FirstOrDefault(at => at.numero == c.atividade_numero && at.status == 1);
                        if (a != null)
                        {
                            if (a.data_inicio <= data && a.data_termino >= data)
                            {
                                l.Add(a);
                            }
                        }
                    }
                }
                return l;
            }
        }

        //pegar lista de atividades do dia para gerente
        public List<Atividade> ListAtividadesdodiaGerente(int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                DateTime data = DateTime.Now;
                data = DateTime.Parse((data.ToString()).Substring(0, 10));
                List<Atividade> l = new List<Atividade>();
                List<Projeto> lp = (from p in bd.Projetos where p.gerente_id == pessoa && p.status==1 select p).ToList();
                List<Cronograma> cr;
                Atividade a;
                foreach(Projeto p in lp)
                {
                    cr = new List<Cronograma>();
                    cr = (from c in bd.Cronogramas where c.projeto_codigo == p.codigo && c.status == 1 select c).ToList();
                    foreach (Cronograma c in cr)
                    {
                        a = new Atividade();
                        a = bd.Atividades.FirstOrDefault(at => at.numero == c.atividade_numero && at.status == 1);
                        if (a != null)
                        {
                            if (a.data_inicio <= data && a.data_termino >= data)
                            {
                                l.Add(a);
                            }
                        }
                    }
                }               
                return l;
            }
        }

        //pegar nome do projeto q tem a atividade
        public string GetNomeProjetodaAtividade(int at)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Cronograma c = bd.Cronogramas.FirstOrDefault(cr => cr.atividade_numero == at);
                string projeto = bd.Projetos.FirstOrDefault(p => p.codigo == c.projeto_codigo).nome;
                return projeto;
            }
        }

        
        //deleta atividade
        public void Delete(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Atividade a = (from at in bd.Atividades where at.numero == numero select at).FirstOrDefault();
                a.status = 0;
                bd.SubmitChanges();

                Projeto p = (from cr in bd.Cronogramas from pr in bd.Projetos where cr.atividade_numero == numero && cr.projeto_codigo == pr.codigo select pr).FirstOrDefault();

                LogData ld = new LogData();
                DateTime data = DateTime.Now;
                string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                msg += " canceled the activity: ";
                msg += a.nome + ".";
                int pessoa = p.gerente_id;
                int projeto = p.codigo;
                ld.Insert(projeto, data, msg, pessoa);
            }
        }

        //reativa atividade
        public void Reactivate(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Atividade a = (from at in bd.Atividades where at.numero == numero select at).FirstOrDefault();
                a.status = 1;
                bd.SubmitChanges();

                Projeto p = (from cr in bd.Cronogramas from pr in bd.Projetos where cr.atividade_numero == numero && cr.projeto_codigo == pr.codigo select pr).FirstOrDefault();

                LogData ld = new LogData();
                DateTime data = DateTime.Now;
                string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                msg += " reactivated the activity: ";
                msg += a.nome + ".";
                int pessoa = p.gerente_id;
                int projeto = p.codigo;
                ld.Insert(projeto, data, msg, pessoa);
            }
        }

        //completa atividade
        public void Complete(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Atividade a = (from at in bd.Atividades where at.numero == numero select at).FirstOrDefault();
                a.status = 3;
                a.porc_completo = 100;
                bd.SubmitChanges();

                Projeto p = (from cr in bd.Cronogramas from pr in bd.Projetos where cr.atividade_numero == numero && cr.projeto_codigo == pr.codigo select pr).FirstOrDefault();

                LogData ld = new LogData();
                DateTime data = DateTime.Now;
                string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                msg += " completed the activity: ";
                msg += a.nome + ".";
                int pessoa = p.gerente_id;
                int projeto = p.codigo;
                ld.Insert(projeto, data, msg, pessoa);
                
                //mudar porcentagem do projeto
                Cronograma cra = new Cronograma();
                cra = (from c in bd.Cronogramas where c.atividade_numero == a.numero select c).FirstOrDefault();
                decimal atividadestotaldafase = (from c in bd.Cronogramas from at in bd.Atividades where c.fase_numero == cra.fase_numero && c.atividade_numero == at.numero && at.status !=0  select c).Count();
                decimal atividadescompletasdafase = (from c in bd.Cronogramas from at in bd.Atividades where c.fase_numero == cra.fase_numero && c.atividade_numero == at.numero && at.status == 3 select c).Count();
                decimal porc = (atividadescompletasdafase * 100) / atividadestotaldafase;

                Fase f = new Fase();
                f = (from fs in bd.Fases where fs.numero == cra.fase_numero select fs).FirstOrDefault();
                f.porc_completo = porc;
                bd.SubmitChanges();

                StepData sd = new StepData();
                List<Fase> lf = sd.listFases(p.codigo);
                decimal porcfases = 0;
                foreach (Fase fs in lf)
                {
                    porcfases = porcfases + fs.porc_completo;
                }

                p.porc_completo = (porcfases/lf.Count());
                bd.SubmitChanges();
            }
        }

        //pegar valor gasto na fase
        public decimal GetCustoFase(int fase)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<CronogramaRecurso> cr = new List<CronogramaRecurso>();
                cr = (from c in bd.CronogramaRecursos where c.fase_numero == fase select c).ToList();
                decimal total = 0;
                foreach (CronogramaRecurso c in cr)
                {
                    total = total + c.valortotal;
                }
                return total;
            }
        }

        //altera uma atividade a partir de um numero
        public void Update(Atividade a)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Atividade at =  bd.Atividades.FirstOrDefault(act => act.numero == a.numero);
                at.nome = a.nome;
                at.data_inicio = a.data_inicio;
                at.data_termino = a.data_termino;
                at.descricao = a.descricao;
                at.qtd_hora = a.qtd_hora;
                bd.SubmitChanges();
            }
        }

        public List<Atividade> ListAtividadesdoMes(int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                DateTime data = DateTime.Now;
                string mes = ((data.ToString()).Substring(3,2));
                List<Atividade> l = new List<Atividade>();
                List<Projeto> lp = (from p in bd.Projetos where p.gerente_id == pessoa && p.status == 1 select p).ToList();
                List<Cronograma> cr;
                Atividade a;
                foreach (Projeto p in lp)
                {
                    cr = new List<Cronograma>();
                    cr = (from c in bd.Cronogramas where c.projeto_codigo == p.codigo && c.status == 1 select c).ToList();
                    foreach (Cronograma c in cr)
                    {
                        a = new Atividade();
                        a = bd.Atividades.FirstOrDefault(at => at.numero == c.atividade_numero && at.status == 1);
                        if (a != null)
                        {
                            if ((a.data_inicio).ToString().Substring(3,2) == mes)
                            {
                                l.Add(a);
                            }
                        }
                    }
                }
                return l;
            }
        }


    }
}
