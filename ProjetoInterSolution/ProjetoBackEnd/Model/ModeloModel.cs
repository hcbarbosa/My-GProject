using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoBackEnd.Model
{
    public class ModeloModel
    {
        public List<Modelo> ListModelos()
        {
            ModelData md = new ModelData();
            return md.ListModelos();
        }

        public Modelo GetModelo(int numero)
        {
            ModelData md = new ModelData();
            return md.GetModelo(numero);
        }

        public Modelo GetModeloPorProjeto(int numero)
        {
            ModelData md = new ModelData();
            return md.GetModeloPorProjeto(numero);
        }

        public bool Insert(Modelo m)
        {
            ModelData md = new ModelData();
            return md.Insert(m);
        }

        public bool Update(Modelo m)
        {
            ModelData md = new ModelData();
            return md.Update(m);
        }

        public bool Delete(int numero)
        {
            ModelData md = new ModelData();
            return md.Delete(numero);
        }
    }
}
