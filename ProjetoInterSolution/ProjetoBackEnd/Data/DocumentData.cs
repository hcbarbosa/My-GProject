using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class DocumentData
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

        //pega todos os documentos do projeto
        public List<Cronograma> GetDocumentosProjeto(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cronograma> cr = new List<Cronograma>();
                cr = (from c in bd.Cronogramas where c.projeto_codigo == projeto && c.documento_numero != null orderby c.fase_numero ascending select c).ToList();
                return cr;
            }
        }

        //PRECISO RETORNAR UMA LISTA COM AS ATIVIDADES QUE NAO TEM DOCUMENTO PRA INSERIR NA MODAL E O CARA ESCOLHER QUAL ELE QUER ADICIONAR UM DOCUMENTO

        //pega todos os documentos do projeto
        public List<Cronograma> GetNoDocSteps(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cronograma> cr = new List<Cronograma>();
                cr = (from c in bd.Cronogramas where c.projeto_codigo == projeto && c.documento_numero == null orderby c.fase_numero ascending select c).ToList();
                return cr;
            }
        }


        //pega nome da fase 
        public string GetNomeFase(int fase)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from f in bd.Fases where f.numero == fase select f.nome).FirstOrDefault();
            }
        }

        //pega fases de um projeto 
        public List<Cronograma> GetProjetoFases(int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cronograma> l = new List<Cronograma>();

                l = (from c in bd.Cronogramas where c.projeto_codigo == projeto select c).ToList();

                foreach (Cronograma c3 in l)
                {
                    c3.Atividade = (from a in bd.Atividades where c3.atividade_numero == a.numero select a).FirstOrDefault();
                }
                return l;
            }
        }

        //Insere a imagem em pessoa pelo id
        public bool InsertDoc(int ativ_id, Documento doc)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Documento d = new Documento();
                    d.nome = doc.nome;
                    d.tipo = doc.tipo;
                    d.local = doc.nome;
                    d.status = 1;
                    bd.Documentos.InsertOnSubmit(d);
                    bd.SubmitChanges();
                    var a = (from c in bd.Cronogramas where c.atividade_numero == ativ_id  && c.documento_numero == null select c).FirstOrDefault();
                    a.documento_numero = d.numero;
                    bd.SubmitChanges();
                }

                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }

        //pega nome da atividade
        public string GetNomeAtividade(int atividade)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from a in bd.Atividades where a.numero == atividade select a.nome).FirstOrDefault();
            }
        }

        //pega nome do projeto
        public string GetNomeProjeto( int projeto)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from p in bd.Projetos where p.codigo == projeto select p.nome).FirstOrDefault();
            }
        }

        public Documento GetDocumento(int documento)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from d in bd.Documentos where d.numero == documento select d).FirstOrDefault();
            }
        }

        //lista todos os documentos inativos
        public List<Cronograma> GetDocInat()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cronograma> l = new List<Cronograma>();


                l = (from c in bd.Cronogramas
                     from d in bd.Documentos
                     from p in bd.Projetos
                     from f in bd.Fases
                     from a in bd.Atividades
                     where c.documento_numero == d.numero && c.projeto_codigo == p.codigo && c.fase_numero == f.numero && c.atividade_numero == a.numero && d.status == 0
                     orderby p.nome
                     select c).ToList();

                foreach (Cronograma c1 in l)
                {
                    c1.Projeto = (from p in bd.Projetos where c1.projeto_codigo == p.codigo select p).FirstOrDefault();
                }

                foreach (Cronograma c2 in l)
                {
                    c2.Fase = bd.Fases.FirstOrDefault(f => f.numero == c2.fase_numero);
                }

                foreach (Cronograma c3 in l)
                {
                    c3.Atividade = (from a in bd.Atividades where c3.atividade_numero == a.numero select a).FirstOrDefault();
                }

                foreach (Cronograma c4 in l)
                {
                    c4.Documento = bd.Documentos.FirstOrDefault(d => d.numero == c4.documento_numero);
                }

                return l;
            }
        }




    }
}
