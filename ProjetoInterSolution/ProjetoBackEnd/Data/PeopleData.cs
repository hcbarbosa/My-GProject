using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBackEnd.Data
{
    class PeopleData
    {
        public PeopleData() { }

        public Pessoa GetPessoa(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Pessoa p = (from c in bd.Pessoas
                                  where c.id == codigo
                                  select c).FirstOrDefault();

                return p;
            }

        }

        //pega o email default da pessoa (aquele com status = 3)
        public String GetDefaultEmailPessoa(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                string email = (from e in bd.Emails
                                where e.pessoa_id == codigo && e.status == 3
                                select e.endereco).FirstOrDefault();
                return email;
            }
        }

        //pega o telefone default da pessoa (aquele com status = 3)
        public String GetDefaultPhonePessoa(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                string phone = (from p in bd.Telefones
                                where p.pessoa_id == codigo && p.status == 3
                                select p.numero).FirstOrDefault();
                return phone;
            }
        }

        //verifica o email padrao para poder enviar email
        public bool IsValidEmail(string email)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                var resp = from e in bd.Emails
                           from p in bd.Pessoas
                           where e.endereco == email && e.pessoa_id == p.id
                           && p.status == 1 && e.status == 3
                           select e;
                if (resp.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //pega o codigo da pessoa do email
        public int GetIdLoginPessoa(string email)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                int codigo = (from e in bd.Emails
                              from p in bd.Pessoas
                              where e.endereco == email && e.pessoa_id == p.id
                              && p.status == 1 && e.status == 3
                              select e.pessoa_id).First();

                return codigo;
            }
        }


        // pega o login da pessoa do email
        public string GetLoginPessoa(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {

                string login = "";

                Cliente cliente = (from c in bd.Clientes
                                   where c.pessoa_id == codigo
                                   select c).FirstOrDefault();

                if (cliente != null)
                {
                    login += "Login: " + cliente.login + "<br/>Password: " + cliente.senha;
                }
                else
                {
                    Gerente gerente = (from g in bd.Gerentes
                                       where g.pessoa_id == codigo
                                       select g).FirstOrDefault();
                    if (gerente != null)
                    {
                        login += "Login: " + gerente.login + "<br/>Password: " + gerente.senha;
                    }
                }
                return login;
            }
        }

        // preenche o select de estados
        public List<Estado> ListEstados()
        {

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Estado> l = new List<Estado>();
                return l = bd.Estados.OrderBy(e => e.nome).ToList();
            }
        }

        //preenche o select de cidades a partir de um estado selecionado
        public List<Cidade> ListCidades(string estado)
        {

            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Cidade> l = new List<Cidade>();
                estado = estado.TrimStart();
                l = (from c in bd.Cidades where c.estado_sigla == estado  orderby c.nome select c).ToList();

                return l;
            }
        }

        //pega o estado de onde a pessoa eh a partir do id da cidade dela
        public string EstadoDaPessoa(int cidade)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                string uf = (from c in bd.Cidades where c.id == cidade select c.estado_sigla).FirstOrDefault();               
                return uf;
            }
        }

        //pega todos os emails ativos da pessoa
        public List<Email> ListEmails(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Email> l = new List<Email>();
                l = (from e in bd.Emails where e.pessoa_id == codigo && e.status == 3 ||  e.pessoa_id == codigo && e.status== 1 orderby e.status descending  select e).ToList();
                return l;
            }
        }
        //pega todos os telefones ativos da pessoa
        public List<Telefone> ListTelefones(int codigo)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Telefone> l = new List<Telefone>();
                l = (from t in bd.Telefones where t.pessoa_id == codigo && t.status == 3 || t.pessoa_id == codigo && t.status == 1 orderby t.status descending select t).ToList();
                return l;
            }
        }

        //pega img da pessoa
        public string GetImagem(int codigo)
        {
             using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                 string img = (from p in bd.Pessoas where p.id == codigo select p.imagem).FirstOrDefault();
                 return img;
            }
        }

        //Insere a imagem em pessoa pelo id
        public bool InsertImagem(int id, string imagem)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var p = (from pes in bd.Pessoas where pes.id == id select pes).FirstOrDefault();
                    p.imagem = imagem;
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

        //Altera o nome da pessoa pelo id
        public bool AlterName(int id, string nome)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var p = (from pes in bd.Pessoas where pes.id == id select pes).FirstOrDefault();
                    p.nome = nome;
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

        //Altera email da pessoa pelo id
        public bool AlterEmail(int id, string email)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    var pea = (from e in bd.Emails where e.pessoa_id == id && e.status == 3 select e).FirstOrDefault();
                    pea.status = 1;
                    bd.SubmitChanges();
                    var pen = (from e in bd.Emails where e.pessoa_id == id && e.endereco == email select e).FirstOrDefault();
                    pen.status = 3;
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


    }
}
