using ProjetoBackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Model
{
   public class DependenciaModel
    {
       public void CriaDep(Dependencia d)
       {
           DependenciaData dd = new DependenciaData();

           dd.CriaDep(d);

       }
        public List<Dependencia> DependenciaFase(int projeto, int fase)
        {
            DependenciaData dd = new DependenciaData();

            return dd.DependenciaFase(projeto, fase);
            

        }

        public List<Dependencia> DependenciaAtividade(int projeto, int atividade)
        {
            DependenciaData dd = new DependenciaData();

            return dd.DependenciaAtividade(projeto, atividade);
        }

    }
}
