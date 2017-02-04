using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ReportModel
    {
        public List<Projeto> ListProjetosGerente(int pessoa)
        {
            ReportData rd = new ReportData();
            return rd.ListProjetosGerente(pessoa);
        }

        public List<Projeto> ListProjetosCliente(int pessoa)
        {
            ReportData rd = new ReportData();
            return rd.ListProjetosCliente(pessoa);
        }

    }
}
