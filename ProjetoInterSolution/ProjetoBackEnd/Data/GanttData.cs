using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class GanttData
    {
        public List<SerializeGanttLink> GetDependency(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext()) {

                List<SerializeGanttLink> lsl = new List<SerializeGanttLink>();

                List<Dependencia> ld = (from d in bd.Dependencias where d.projeto.Equals(codigo) select d).ToList();
                SerializeGanttLink sl;

                foreach (Dependencia dp in ld)
                {
                    sl = new SerializeGanttLink();

                    sl.id = dp.id.ToString();
                    sl.target = dp.atividadePrincipal != null ? dp.atividadePrincipal.ToString()+".2" : dp.fasePrincipal != null ? dp.fasePrincipal.ToString()+".1" : "";
                    sl.source = dp.atividadeDependente != null ? dp.atividadeDependente.ToString()+".2" : dp.faseDependente != null ? dp.faseDependente.ToString()+".1" : "";
                    sl.type = dp.tipo.ToString();

                    lsl.Add(sl);


                }
            
              return lsl ;

            }

        }

        public List<SerializeGanttData> GetGanttData(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                List<SerializeGanttData> lsd = new List<SerializeGanttData>();

                

                List<Fase> lf = (from f in bd.Fases join c in bd.Cronogramas on f.numero equals c.fase_numero where c.projeto_codigo.Equals(codigo) select f).ToList();

                SerializeGanttData sd;

               foreach (Fase f in lf) {
                   sd = new SerializeGanttData();

                   sd.id = decimal.Parse(""+f.numero.ToString()+",1");
                   sd.parent = codigo.ToString();
                   sd.text = f.nome;
                   sd.progress = f.porc_completo/100;
                   sd.start_date = f.data_inicio.ToString().Substring(0,10).Replace('/','-');
                   TimeSpan tm = DateTime.Parse(f.data_termino.ToString().Substring(0, 10).Replace('/', '-')) - DateTime.Parse(f.data_inicio.ToString().Substring(0, 10).Replace('/', '-'));
                   sd.duration = (tm.TotalDays).ToString();
                   sd.open = true;

                   lsd.Add(sd);


               
                   List<Atividade> atividade = ( from a in bd.Atividades 
                                     join c in bd.Cronogramas on a.numero equals c.atividade_numero
                                     where c.projeto_codigo.Equals(codigo) && c.fase_numero.Equals(f.numero)
                                     select a).ToList();
                   foreach(Atividade a in atividade){

                       sd = new SerializeGanttData();

                       sd.id = decimal.Parse(""+a.numero.ToString()+",2");
                       sd.parent = ""+f.numero.ToString()+".1";
                       sd.text = a.nome;
                       sd.progress = a.porc_completo / 100;
                       sd.start_date = a.data_inicio.ToString().Substring(0, 10).Replace('/', '-');
                       TimeSpan tma = DateTime.Parse(a.data_termino.ToString().Substring(0, 10).Replace('/', '-')) - DateTime.Parse(a.data_inicio.ToString().Substring(0, 10).Replace('/', '-'));
                       sd.duration = (tma.TotalDays).ToString();
                       sd.open = true;

                       lsd.Add(sd);

                   }
                       
                       

               }

                return lsd;

            }

        }
    }
}
