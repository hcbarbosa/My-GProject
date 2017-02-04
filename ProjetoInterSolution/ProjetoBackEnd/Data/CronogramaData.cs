using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class CronogramaData
    {
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

        //insere uma atividade de uma fase com os numeros delas
        public bool InsertStepAt(int projeto, int fase, int at)
        {
            bool resp = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Cronograma cr = new Cronograma();
                    cr.atividade_numero = at;
                    cr.fase_numero = fase;
                    cr.projeto_codigo = projeto;
                    cr.status = 1;
                    bd.Cronogramas.InsertOnSubmit(cr);
                    bd.SubmitChanges();
                }
                resp = true;
            }
            catch (Exception e)
            {
            }
            return resp;
        }

        //pega uma lista de projetos do cliente que estao no banco independente de estarem em progresso, cancelados, concluidos
        public List<Projeto> ListProjetosCliente(int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                List<ProjetosEmpresasCliente> pec = new List<ProjetosEmpresasCliente>();
                pec = (from pe in bd.ProjetosEmpresasClientes where pe.cliente_id == pessoa && pe.status == 1 select pe).ToList();

                List<Projeto> l = new List<Projeto>();
                foreach (ProjetosEmpresasCliente pe2 in pec)
                {
                    l.Add((from p in bd.Projetos where p.codigo == pe2.projeto_codigo select p).FirstOrDefault());
                }
                return l;
            }
        }

    }
}
