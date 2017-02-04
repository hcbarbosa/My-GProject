using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CronogramaModel
    {
        public List<Projeto> ListProjetosGerente(int pessoa)
        {
            CronogramaData cd = new CronogramaData();
            return cd.ListProjetosGerente(pessoa);
        }

        public List<Projeto> ListProjetosCliente(int pessoa)
        {
            CronogramaData cd = new CronogramaData();
            return cd.ListProjetosCliente(pessoa);
        }

        public bool InsertStepAt(int projeto, int fase, int at)
        {
            CronogramaData cd = new CronogramaData();
            return cd.InsertStepAt(projeto,fase,at);
        }

    }
}
