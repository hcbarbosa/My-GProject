using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class StepData
    {
        //inserir uma fase no wizard do projeto por isso o retorno do objeto
        public Fase Insert(Fase f)
        {
            using(BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bd.Fases.InsertOnSubmit(f);
                bd.SubmitChanges();
                return f;
            }
        }

        //altera a fase
        public bool Update(Fase f)
        {
            bool resp = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Fase fase = (from fs in bd.Fases where fs.numero == f.numero select fs).FirstOrDefault();
                    fase.nome = f.nome;
                    fase.descricao = f.descricao;
                    fase.data_inicio = f.data_inicio;
                    fase.data_termino = f.data_termino;
                    bd.SubmitChanges();
                    resp = true;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return resp;
        }

        //pegar as fases de um projeto
        public List<Fase> listFases(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                //pega lista do cronograma
                List<Cronograma> cr = new List<Cronograma>();
                cr = (from c in bd.Cronogramas where c.projeto_codigo == projeto select c).ToList();
                //faz lista das fases do projeto
                List<Fase> f = new List<Fase>();
                Fase fase;
                Fase faseteste;
                foreach (Cronograma c in cr)
                {
                    fase = new Fase();
                    fase = (from fa in bd.Fases where fa.numero == c.fase_numero select fa).FirstOrDefault();
                    faseteste = new Fase();
                    faseteste = (from fse in bd.Fases where fse.numero == c.fase_numero select fse).FirstOrDefault();
                    if (f.Contains(faseteste))
                    {
                    }
                    else
                    {
                        f.Add(fase);
                    }
                }
                return f;
            }

        }

        //pegar uma fase
        public Fase GetFase(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from f in bd.Fases where f.numero == numero select f).FirstOrDefault();
            }
        }

        //deleta fase
        public void Delete(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Fase fase = (from fs in bd.Fases where fs.numero == numero select fs).FirstOrDefault();
                fase.status = 0;
                bd.SubmitChanges();

                Projeto p = (from cr in bd.Cronogramas from pr in bd.Projetos where cr.fase_numero == numero && cr.projeto_codigo == pr.codigo select pr).FirstOrDefault();

                LogData ld = new LogData();
                DateTime data = DateTime.Now;
                string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                msg += " canceled the step: ";
                msg += fase.nome +".";
                int pessoa = p.gerente_id;
                int projeto = p.codigo;
                ld.Insert(projeto, data, msg, pessoa);

                List<Atividade> la = (from cr in bd.Cronogramas from a in bd.Atividades where cr.fase_numero == numero && cr.atividade_numero == a.numero  select a).ToList();

                Atividade ati;
                foreach(Atividade a in la)
                {
                    ati = new Atividade();
                    ati = (from at in bd.Atividades where at.numero == a.numero select at).FirstOrDefault();
                    ati.status = 0;
                    bd.SubmitChanges();

                    data = DateTime.Now;
                    msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                    msg += " canceled the activity: ";
                    msg += ati.nome + " of the step ";
                    msg += fase.nome + ".";
                    pessoa = p.gerente_id;
                    projeto = p.codigo;
                    ld.Insert(projeto, data, msg, pessoa);

                }
            }
        }

        //reativar fase
        public void Reactivate(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Fase fase = (from fs in bd.Fases where fs.numero == numero select fs).FirstOrDefault();
                fase.status = 1;
                bd.SubmitChanges();

                Projeto p = (from cr in bd.Cronogramas from pr in bd.Projetos where cr.fase_numero == numero && cr.projeto_codigo == pr.codigo select pr).FirstOrDefault();

                LogData ld = new LogData();
                DateTime data = DateTime.Now;
                string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                msg += " reactivated the step: ";
                msg += fase.nome + ".";
                int pessoa = p.gerente_id;
                int projeto = p.codigo;
                ld.Insert(projeto, data, msg, pessoa);

                List<Atividade> la = (from cr in bd.Cronogramas from a in bd.Atividades where cr.fase_numero == numero && cr.atividade_numero == a.numero select a).ToList();

                Atividade ati;
                foreach (Atividade a in la)
                {
                    ati = new Atividade();
                    ati = (from at in bd.Atividades where at.numero == a.numero select at).FirstOrDefault();
                    ati.status = 1;
                    bd.SubmitChanges();

                    data = DateTime.Now;
                    msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                    msg += " reactivated the activity: ";
                    msg += ati.nome + " of the step ";
                    msg += fase.nome + ".";
                    pessoa = p.gerente_id;
                    projeto = p.codigo;
                    ld.Insert(projeto, data, msg, pessoa);

                }
            }
        }

        //completar fase
        public void Complete(int numero)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Fase fase = (from fs in bd.Fases where fs.numero == numero select fs).FirstOrDefault();
                fase.status = 3;
                bd.SubmitChanges();

                Projeto p = (from cr in bd.Cronogramas from pr in bd.Projetos where cr.fase_numero == numero && cr.projeto_codigo == pr.codigo select pr).FirstOrDefault();

                LogData ld = new LogData();
                DateTime data = DateTime.Now;
                string msg = "" + (from pe in bd.Pessoas where pe.id == p.gerente_id select pe.nome).FirstOrDefault();
                msg += " completed the step: ";
                msg += fase.nome + ".";
                int pessoa = p.gerente_id;
                int projeto = p.codigo;
                ld.Insert(projeto, data, msg, pessoa);

               //mudar porcentagem do projeto

            }
        }


                   
    }
}
