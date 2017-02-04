using ProjetoBackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Model
{
    public class StepModel
    {
        public Fase Insert(Fase f)
        {
            StepData sd = new StepData();
            return sd.Insert(f);           
        }

        public bool Update(Fase f)
        {
            StepData sd = new StepData();
            return sd.Update(f);   
        }

        public List<Fase> listFases(int projeto)
        {
            StepData sd = new StepData();
            return sd.listFases(projeto);
        }

        public Fase GetFase(int numero)
        {
            StepData sd = new StepData();
            return sd.GetFase(numero);
        }

        public void Delete(int numero)
        {
            StepData sd = new StepData();
            sd.Delete(numero);
        }

        public void Reactivate(int numero)
        {
            StepData sd = new StepData();
            sd.Reactivate(numero);
        }

        public void Complete(int numero)
        {
            StepData sd = new StepData();
            sd.Complete(numero);
        }
    }
}
