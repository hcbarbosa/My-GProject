using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class ManagerData
    {
        public ManagerData() { }

        //verifica se o login é valido
        public Gerente IsvalidUser(string login, string password)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Gerente gerente = (from g in bd.Gerentes
                                   from p in bd.Pessoas
                                   where g.pessoa_id == p.id &&
                                   g.login == login
                                   && g.senha == password &&
                                   p.status == 1
                                   select g).FirstOrDefault();

                return gerente;
            }
        }
        //Verifica senha do gerente pelo id
        public bool IsvalidPass(int id, string password)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Gerente gerente = (from c in bd.Gerentes
                                   where c.pessoa_id == id
                                   && c.senha == password
                                   select c).FirstOrDefault();
                if (gerente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Altera login manager pelo id
        public bool AlterLogin(int id, string login)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var gerlogin = (from c in bd.Gerentes where c.pessoa_id == id select c).FirstOrDefault();
                    gerlogin.login = login;
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
        //Altera senha manager pelo id
        public bool AlterPass(int id, string pass)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var gerpass = (from c in bd.Gerentes where c.pessoa_id == id select c).FirstOrDefault();
                    gerpass.senha = pass;
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


        //pega uma pessoa de gerente que tem tal codigo
        public Pessoa GetPessoa(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Pessoa gerente = (from g in bd.Pessoas
                                  where g.id == codigo
                                  select g).FirstOrDefault();

                return gerente;
            }
        }
    }
}
