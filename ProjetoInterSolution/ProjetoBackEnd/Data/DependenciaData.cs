using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class DependenciaData
    {

        public void CriaDep(Dependencia d ) 
        {

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext()) 
            {

                

                    bd.Dependencias.InsertOnSubmit(d);
                    bd.SubmitChanges();
                
                
            
            }
        
        }


        public List<Dependencia> DependenciaFase(int projeto, int fase) 
        {

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from d in bd.Dependencias where d.projeto.Equals(projeto) && d.fasePrincipal.Equals(fase) select d).ToList();
            }
        
        }

        public List<Dependencia> DependenciaAtividade(int projeto, int atividade)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from d in bd.Dependencias where d.projeto.Equals(projeto) && d.atividadePrincipal.Equals(atividade)  select d).ToList();
            
            }
        }

    }
}
