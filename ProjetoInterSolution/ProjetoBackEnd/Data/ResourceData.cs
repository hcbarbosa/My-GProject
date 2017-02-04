using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class ResourceData
    {
        public ResourceData() { }

        //inseri um recurso
        public bool Insert(Recurso r) 
        { 
        
            bool res = false ;

            using( BDMyGProjectDataContext bd = new BDMyGProjectDataContext() )
            {

                try
                {
                    Recurso rc = new Recurso();                    
                    rc.tipo_id = r.tipo_id;
                    rc.descricao = r.descricao;
                    rc.qtd_hora_disponivel = r.qtd_hora_disponivel;
                    rc.qtd_unid_disponivel = r.qtd_unid_disponivel;
                    rc.valor = r.valor;
                    rc.status = 1;

                    bd.Recursos.InsertOnSubmit(rc);
                    bd.SubmitChanges();

                    res = true;
                    
                }
                catch (Exception e)
                {

                    res = false;
                    return res;

                    Console.WriteLine(e.Message);
                
                }

            }

            return res;
        }

        //pega uma lista de recurso com status = 1 (ativo) usada para preencher a tabela de consulta 
        public List<Recurso> ListResources() 
        {
            using(BDMyGProjectDataContext bd =new BDMyGProjectDataContext()){

            List<Recurso> l = new List<Recurso>();

            l = (from r in bd.Recursos where r.status == 1 select r).ToList();
 
                return l;

            }
        }

//pega uma lista de recurso com status = 0 (inativo) usada para preencher a tabela de consulta 
        public List<Recurso> ListResourcesInat()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                List<Recurso> l = new List<Recurso>();

                l = (from r in bd.Recursos where r.status == 0 select r).ToList();

                return l;

            }
        }

        //pega um recurso a partir de um id
        public Recurso GetResource(int id)
        {

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bd.DeferredLoadingEnabled = false;
                var teste = (from r in bd.Recursos join t in bd.Tipos on r.tipo_id equals t.id 
                             where r.id.Equals(id)
                             select new {descricao = r.descricao , tipo = t.descricao, quantidade_hora = r.qtd_hora_disponivel, quantidade_unidade = r.qtd_unid_disponivel, valor = r.valor }).Single();

                Recurso re = new Recurso();
                re.Tipo = new Tipo();

                re.descricao = teste.descricao;
                re.Tipo.descricao = teste.tipo;
                re.valor = teste.valor;
                re.qtd_hora_disponivel = teste.quantidade_hora;
                re.qtd_unid_disponivel = teste.quantidade_unidade;

                return re;

            }
        }

        //altera o recurso
        public bool Update(Recurso recurso)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Recurso r = bd.Recursos.Single(re => re.id.Equals(recurso.id));
                   
                        r.descricao = recurso.descricao;
                        r.qtd_hora_disponivel = recurso.qtd_hora_disponivel;
                        r.qtd_unid_disponivel = recurso.qtd_unid_disponivel;
                        r.valor = recurso.valor;
                   
                    bd.SubmitChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        //muda o status do recurso para 0 ou seja esta excluido pois na tabela de consulta a funcao pega apenas o q tem status = 1
        public bool Delete(int id)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Recurso r = bd.Recursos.Single(re => re.id.Equals(id));                    
                    r.status = 0;
                    bd.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public List<CronogramaRecurso> ListResourcesProjeto(int projeto) 
        {
            using(BDMyGProjectDataContext bd =new BDMyGProjectDataContext()){
                    
               return (from cr in bd.CronogramaRecursos where cr.status == 1 && cr.projeto_codigo == projeto orderby cr.atividade_numero ascending select cr).ToList();
 
            }
        }

 public bool Ativar(int id)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Recurso r = bd.Recursos.Single(pe => pe.id.Equals(id));
                    r.status = 1;
                    bd.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }
    }
}
