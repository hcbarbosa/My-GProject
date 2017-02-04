using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class NotificationModel
    {
        public List<Notificacoe> listNot(int gerente)
        {
            NotificationData nm = new NotificationData();
            return nm.listNot(gerente);
        }

        public void ViuNotificacoes(int gerente)
        {
            NotificationData nm = new NotificationData();
            nm.ViuNotificacoes(gerente);
        }

        public int PegaNumerodeNaoLida(int gerente)
        {
            NotificationData nm = new NotificationData();
            return nm.PegaNumerodeNaoLida(gerente);
        }

    }
}
