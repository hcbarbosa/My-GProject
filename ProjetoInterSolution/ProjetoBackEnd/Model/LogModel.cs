using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class LogModel
    {
        public List<Log> listlogs(int projeto)
        {
            LogData ld = new LogData();
            return ld.listlogs(projeto);
        }

        public void Insert(int projeto, DateTime data, string msg, int pessoa)
        {
            LogData ld = new LogData();
            ld.Insert(projeto,data,msg,pessoa);
        }
    }
}
