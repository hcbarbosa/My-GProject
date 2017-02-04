using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class ModelData
    {
        //preenche o select de modelo no wizard de projeto
        public List<Modelo> ListModelos()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Modelo> l = new List<Modelo>();
                l = bd.Modelos.ToList();
                return l;
            }
        }

        //pega um modelo a partir de um numero
        public Modelo GetModelo(int numero)
        {
             using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Modelo m = new Modelo();
                m = bd.Modelos.FirstOrDefault(mo => mo.numero == numero);
                return m;
             }
        }

        //pega um modelo a partir de um numero
        public Modelo GetModeloPorProjeto(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Modelo m = new Modelo();
                m = bd.Modelos.FirstOrDefault(mo => mo.projeto_codigo == projeto && mo.status == 1);
                return m;
            }
        }

        //insere modelo
        public bool Insert(Modelo m)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    bd.Modelos.InsertOnSubmit(m);
                    bd.SubmitChanges();

                    Projeto p = bd.Projetos.FirstOrDefault(pr => pr.codigo == m.projeto_codigo);
                    p.status = 2;
                    bd.SubmitChanges();
                    ok = true;
                }
            }
            catch(Exception e)
            {
            }
            return ok;
        }

         //altera modelo
        public bool Update(Modelo m)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Modelo mol = bd.Modelos.FirstOrDefault( mo => mo.projeto_codigo == m.projeto_codigo && mo.status ==1);
                    mol.nome = m.nome;
                    mol.descricao = m.descricao;
                    bd.SubmitChanges();
                    ok = true;
                }
            }
            catch (Exception e)
            {
            }
            return ok;
        }

        //deleta modelo
        public bool Delete(int numero)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Modelo mol = bd.Modelos.FirstOrDefault(mo => mo.projeto_codigo == numero && mo.status == 1);
                    mol.status = 0;
                    bd.SubmitChanges();
                    ok = true;
                    Projeto p = bd.Projetos.FirstOrDefault(pr => pr.codigo == numero);
                    p.status = 3;
                    bd.SubmitChanges();
                }
            }
            catch (Exception e)
            {
            }
            return ok;
        }
    }
}
