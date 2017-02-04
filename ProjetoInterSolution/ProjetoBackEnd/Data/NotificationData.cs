using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class NotificationData
    {
        //cria notificacao
        public bool Insert(Notificacoe n)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    bd.Notificacoes.InsertOnSubmit(n);
                    bd.SubmitChanges();
                }
                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;

        }

        public List<Notificacoe> listNot(int gerente)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from n in bd.Notificacoes where n.gerente_id == gerente orderby n.numero descending select n).ToList();
            }
        }

        public void ViuNotificacoes(int gerente)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Notificacoe not;
                List<Notificacoe> ln =  (from n in bd.Notificacoes where n.gerente_id == gerente orderby n.numero descending select n).ToList();
                foreach (Notificacoe n in ln)
                {
                    not = (from nt in bd.Notificacoes where n.numero == nt.numero select nt).FirstOrDefault();
                    not.status = 0;
                    bd.SubmitChanges();
                }
            }
        }

        public int PegaNumerodeNaoLida(int gerente)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                return (from n in bd.Notificacoes where n.gerente_id == gerente && n.status == 1 select n).Count();
               
            }
        }
    }
}
