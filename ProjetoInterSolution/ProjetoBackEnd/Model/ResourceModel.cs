using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
   public class ResourceModel
    {

       public ResourceModel() { }

       public bool Insert(Recurso r)
       {
           ResourceData rd = new ResourceData();
          return rd.Insert(r);
       }

       public List<Recurso> ListResources()
       {
           ResourceData rd = new ResourceData();
           return rd.ListResources();
       }

       public Recurso GetResource(int id)
       {
           ResourceData rd = new ResourceData();
           return rd.GetResource(id);
       }

       public bool Update(Recurso r)
       {
           ResourceData rd = new ResourceData();
           return rd.Update(r);
       }

       public bool Delete(int id)
       {
           ResourceData rd = new ResourceData();
           return rd.Delete(id);
       }

       public List<CronogramaRecurso> ListResourcesProjeto(int projeto)
       {
           ResourceData rd = new ResourceData();
           return rd.ListResourcesProjeto(projeto);
       }

	 public List<Recurso> ListResourcesInat()
       {
           ResourceData rd = new ResourceData();
           return rd.ListResourcesInat();
       }

	 public bool Ativar(int id)
       {
           ResourceData rd = new ResourceData();
           return rd.Ativar(id);
       }
    }
}
