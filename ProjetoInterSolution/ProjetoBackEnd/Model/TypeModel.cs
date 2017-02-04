using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class TypeModel
    {
        public TypeModel() { }


        public Tipo GetTipo(int id)
        {
            TypeData td = new TypeData();
            return td.GetTipo(id);
        }

        public List<Tipo> ListTipos()
        {
            TypeData td = new TypeData();
            return td.ListTipos();
        }
    }
}
