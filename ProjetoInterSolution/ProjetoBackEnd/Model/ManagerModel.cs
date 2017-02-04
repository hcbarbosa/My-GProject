using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ManagerModel
    {
        public ManagerModel() { }

        public Gerente IsvalidUser(string login, string password)
        {
            ManagerData md = new ManagerData();
            return md.IsvalidUser(login, password);
        }

        public bool IsvalidPass(int id, string password)
        {
            ManagerData md = new ManagerData();
            return md.IsvalidPass(id, password);
        }

        public void AlterLogin(int id, string login)
        {
            ManagerData md = new ManagerData();
            md.AlterLogin(id, login);
        }

        public void AlterPass(int id, string pass)
        {
            ManagerData md = new ManagerData();
            md.AlterPass(id, pass);
        }

        public Pessoa GetPessoa(int codigo)
        {
            ManagerData md = new ManagerData();
            return md.GetPessoa(codigo);
        }

    }
}
