using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    public class SerializeGanttData
    {
        public decimal id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public string duration { get; set; }
        public decimal  progress { get; set; }
        public string parent { get; set; }
        public bool open { get; set; }

    }
}
