using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class TypeData
    {
        public TypeData() { }

        //pega um objeto tipo a partir de um id, usado para mostra a descricao do tipo  de recurso na tabela recurso
        public Tipo GetTipo(int id) 
        {
            Tipo t = new Tipo();

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                try
                {
                    t = bd.Tipos.First(ti => ti.id.Equals(id));
                    return t;
                }
                catch (Exception ex)
                {
                    return null;
                
                }

            }

        }
       
        //retorna a lista de tipos para preencher o select tipo do recurso
        public List<Tipo> ListTipos() 
        {
            using(BDMyGProjectDataContext bd =new BDMyGProjectDataContext()){

            List<Tipo> l = new List<Tipo>();

            l = bd.Tipos.ToList();
 
                return l;

            }
        }     
        

        }
    }

