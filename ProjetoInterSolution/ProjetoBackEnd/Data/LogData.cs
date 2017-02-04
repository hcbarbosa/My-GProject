using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class LogData
    {
        //historico de mudancas
        public List<Log> listlogs(int projeto)
        {
             using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from l in bd.Logs where l.projeto_codigo==projeto select l).ToList();
           }
        }

        public void Insert(int projeto, DateTime data, string msg, int pessoa)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Log l = new Log();
                l.data_hora = data;
                l.descricao = msg;
                l.pessoa_id = pessoa;
                l.projeto_codigo = projeto;
                bd.Logs.InsertOnSubmit(l);
                bd.SubmitChanges();
            }
        }
    }
}
