using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class CronogramaRecursoData
    {
        //pega o cronograma a partir de uma atividade para verificar se possui recurso ja
        public CronogramaRecurso GetCR(int at)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return bd.CronogramaRecursos.FirstOrDefault(cr => cr.atividade_numero == at);
            }
        }

        //faz a soma do valor da atividade
        public decimal GetTotalAt(int at)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                decimal total;
                if ((from cr in bd.CronogramaRecursos where cr.atividade_numero == at select cr).FirstOrDefault() != null)
                {
                    total = (from cr in bd.CronogramaRecursos where cr.atividade_numero == at select (cr.valortotal)).Sum();
                }
                else
                {
                    total = 0;
                }
               return total;
            }
        }


        //deleta um recurso de um cronograma a partir de seu numero e atividade
        public void Delete(int rec, int at)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                CronogramaRecurso cr = new CronogramaRecurso();
                cr = bd.CronogramaRecursos.FirstOrDefault(c => c.atividade_numero == at && c.recurso_id == rec);                
                bd.CronogramaRecursos.DeleteOnSubmit(cr);
                bd.SubmitChanges();
                
            }
        }

        //lista os recursos q a atividade nao tem ligacao
        public List<Recurso> listRecursosSemRelacao(int tipo, int projeto, int fase, int at)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Recurso> lr = new List<Recurso>();
                List<Recurso> lcr = (from c in bd.CronogramaRecursos from r in bd.Recursos
                                               where c.projeto_codigo == projeto && c.fase_numero == fase && c.atividade_numero == at
                                               && c.recurso_id == r.id
                                               select r).ToList();
                List<Recurso> todosrecursos = (from r in bd.Recursos where r.status == 1 orderby r.descricao ascending select r).ToList();

                foreach (Recurso r in todosrecursos)
                {
                    if (lcr.Contains(r))
                    {
                    }
                    else
                    {
                        if (r.tipo_id == tipo)
                        {
                            lr.Add(r);
                        }
                    }
                }
                return lr;
            }
        }


        //insere um cronogrecurso
        public void Insert(CronogramaRecurso cr)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {                
                bd.CronogramaRecursos.InsertOnSubmit(cr);
                bd.SubmitChanges();

            }
        }
    }
}
