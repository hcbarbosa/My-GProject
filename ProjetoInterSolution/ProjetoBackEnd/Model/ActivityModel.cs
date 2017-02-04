using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoBackEnd.Model
{
    public class ActivityModel
    {
        public Atividade Insert(Atividade a)
        {
            ActivityData ad = new ActivityData();
            return ad.Insert(a);
        }

        public Atividade GetAtividade(int numero)
        {
            ActivityData ad = new ActivityData();
            return ad.GetAtividade(numero);
        }

        public Fase GetFaseDaAtividade(int at)
        {
            ActivityData ad = new ActivityData();
            return ad.GetFaseDaAtividade(at);
        }

        public List<Atividade> GetAtividadesFase(int fase)
        {
            ActivityData ad = new ActivityData();
            return ad.GetAtividadesFase(fase);
        }

         public List<Cronograma> GetAtividadesProjeto(int projeto)
        {
            ActivityData ad = new ActivityData();
            return ad.GetAtividadesProjeto(projeto);
        }
        
        public int CountAtividades(int fase)
        {
            ActivityData ad = new ActivityData();
            return ad.CountAtividades(fase);
        }

        public List<Atividade> ListAtividadesdodiaCliente(int pessoa)
        {
            ActivityData ad = new ActivityData();
            return ad.ListAtividadesdodiaCliente(pessoa);
        }

        public List<Atividade> ListAtividadesdodiaGerente(int pessoa)
        {
            ActivityData ad = new ActivityData();
            return ad.ListAtividadesdodiaGerente(pessoa);
        }

         public List<Atividade> ListAtividadesdoMes(int pessoa)
        {
            ActivityData ad = new ActivityData();
            return ad.ListAtividadesdoMes(pessoa);
        }

        public string GetNomeProjetodaAtividade(int at)
        {
            ActivityData ad = new ActivityData();
            return ad.GetNomeProjetodaAtividade(at);
        }

        public void Delete(int numero)
        {
            ActivityData ad = new ActivityData();
            ad.Delete(numero);
        }

        public void Reactivate(int numero)
        {
            ActivityData ad = new ActivityData();
            ad.Reactivate(numero);
        }

        public void Complete(int numero)
        {
            ActivityData ad = new ActivityData();
            ad.Complete(numero);
        }

        public decimal GetCustoFase(int fase)
        {
            ActivityData ad = new ActivityData();
            return ad.GetCustoFase(fase);
        }

        public void Update(Atividade a)
        {
            ActivityData ad = new ActivityData();
            ad.Update(a);
        }
    }
}
