using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CronogramaRecursoModel
    {
        public CronogramaRecurso GetCR(int at)
        {
            CronogramaRecursoData cr = new CronogramaRecursoData();
            return cr.GetCR(at);
        }

        public void Delete(int rec, int at)
        {
            CronogramaRecursoData cr = new CronogramaRecursoData();
            cr.Delete(rec,at);
        }

        public List<Recurso> listRecursosSemRelacao(int tipo, int projeto, int fase, int at)
        {
            CronogramaRecursoData cr = new CronogramaRecursoData();
            return cr.listRecursosSemRelacao(tipo, projeto, fase, at);
        }

        public void Insert(CronogramaRecurso c)
        {
            CronogramaRecursoData cr = new CronogramaRecursoData();
            cr.Insert(c);
        }

        public decimal GetTotalAt(int at)
        {
            CronogramaRecursoData cr = new CronogramaRecursoData();
            return cr.GetTotalAt(at);
        }
    }
}
