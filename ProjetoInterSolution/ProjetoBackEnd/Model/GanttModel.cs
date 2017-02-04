using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
   public class GanttModel
    {

       public List<SerializeGanttLink> GetDependency(int codigo)
       {

           GanttData gd = new GanttData();

           return gd.GetDependency(codigo);

       }
       public List<SerializeGanttData> GetGanttData(int codigo)
       {
             GanttData gd = new GanttData();
             return gd.GetGanttData(codigo);
       }

    }
}
