using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ProjetoBackEnd.Data
{
    class CompanyData
    {
        //pega os ids das empresas
        public List<int> GetIdEmpresas()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<int> l = (from e in bd.Empresas
                               from p in bd.Pessoas
                               where e.pessoa_id == p.id && p.status == 1
                               select e.pessoa_id).ToList();
                return l;
            }
        }

       //pega uma lista das pessoas que sao empresas
        public List<Pessoa> GetPessoas()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Pessoa> l = new List<Pessoa>();

                l = (from e in bd.Empresas
                     from p in bd.Pessoas
                     where p.id == e.pessoa_id && p.status == 1 
                     orderby p.nome
                     select p).ToList();
                return l;
            }
        }

        //pega uma lista das pessoas q comecam com uma determinada letra
        public List<Pessoa> GetPessoas(string letra)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Pessoa> l = new List<Pessoa>();

                l = (from e in bd.Empresas
                     from p in bd.Pessoas
                     where p.id == e.pessoa_id && p.status == 1 && p.nome.StartsWith(letra)
                     orderby p.nome
                     select p).ToList();
                return l;

            }
        }

        //pega uma empresa a partir do id de pessoa
        public Empresa GetEmpresa(int id)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                Pessoa pessoa = (from e in bd.Pessoas
                                 where e.id == id
                                 select e).FirstOrDefault();
                Cidade cid = (from e in bd.Cidades
                              where e.id == pessoa.cidade_id
                              select e).FirstOrDefault();
                Estado est = (from e in bd.Estados
                              where e.sigla == cid.estado_sigla
                              select e).FirstOrDefault();

                Empresa empresa = new Empresa();

                empresa = (from e in bd.Empresas
                                   where e.pessoa_id == id
                                   select e).FirstOrDefault();
                //empresa.Pessoa = new Pessoa();
                //empresa.Pessoa.Cidade = new Cidade();
                //empresa.Pessoa.Cidade.Estado = new Estado();
                empresa.Pessoa = pessoa;
                empresa.Pessoa.Cidade = cid;
                empresa.Pessoa.Cidade.Estado = est;
                return empresa;

            }
        }

        //insere uma pessoa que é uma empresa
        public bool Insert(Pessoa e, string[] emails, string[] telefones)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bool ok = false;
                  
                try{     
          
                bd.Pessoas.InsertOnSubmit(e); 
                bd.SubmitChanges();
                Email email;
                Telefone telefone;
                for (int i = 0; i < emails.Length; i++)
                {
                    email = new Email();
                    email.pessoa_id = e.id;
                    if (i != 0)
                    {
                        email.endereco = emails[i];
                        email.status = 1;
                    }
                    else
                    {
                        if(emails[i]!=null){
                        email.endereco = emails[i];
                        email.status = 3;
                        }
                    }
                    bd.Emails.InsertOnSubmit(email);
                    bd.SubmitChanges();
                }
                for (int i = 0; i < telefones.Length; i++)
                {
                    telefone = new Telefone();
                    telefone.pessoa_id = e.id;
                    if (i != 0)
                    {
                        telefone.numero = telefones[i];
                        telefone.status = 1;
                    }
                    else
                    {
                        if(telefones[i]!=null){
                        telefone.numero = telefones[i];
                        telefone.status = 3;
                        }
                    }
                    bd.Telefones.InsertOnSubmit(telefone);
                    bd.SubmitChanges();
                }
                
                    ok=true;
                }
                catch(Exception ed)
                {
                    Console.WriteLine(ed.Message);
                }                
                return ok;
            }
        }

        //altera a empresa
        public bool Update(Pessoa p, string[] emails, string[] telefones)
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                bool ok = false;
                try
                {
                    Pessoa pessoadobanco = bd.Pessoas.Single(pe => pe.id.Equals(p.id));
                    pessoadobanco.Empresa = bd.Empresas.Single(emp => emp.pessoa_id.Equals(p.id));

                    pessoadobanco.nome = p.nome;
                    pessoadobanco.Empresa.cnpj = p.Empresa.cnpj;
                    pessoadobanco.Empresa.area_de_atuacao = p.Empresa.area_de_atuacao;
                    if (p.imagem != null)
                    {
                        pessoadobanco.imagem = p.imagem; 
                    }
                    pessoadobanco.cep = p.cep;
                    pessoadobanco.logradouro = p.logradouro;
                    pessoadobanco.numero = p.numero;
                    pessoadobanco.bairro = p.bairro;
                    pessoadobanco.complemento = p.complemento;
                    pessoadobanco.cidade_id = p.cidade_id;
                    pessoadobanco.status = 1;

                    bd.SubmitChanges();

                    bd.ExecuteCommand("DELETE FROM Emails WHERE pessoa_id = {0}", p.id);
                    bd.ExecuteCommand("DELETE FROM Telefones WHERE pessoa_id = {0}", p.id);

                    List<Email> listaemailsedit = new List<Email>();
                    List<Telefone> listatelefonesedit = new List<Telefone>();
                    Email email;
                    Telefone telefone;

                    //cria lista do edit
                    for (int i = 0; i < emails.Length; i++)
                    {
                        email = new Email();
                        email.pessoa_id = p.id;
                        if (i != 0)
                        {
                            email.endereco = emails[i];
                            email.status = 1;
                        }
                        else
                        {
                            email.endereco = emails[i];
                            email.status = 3;
                        }
                        listaemailsedit.Add(email);
                    }

                    for (int i = 0; i < telefones.Length; i++)
                    {
                        telefone = new Telefone();
                        telefone.pessoa_id = p.id;
                        if (i != 0)
                        {
                            telefone.numero = telefones[i];
                            telefone.status = 1;
                        }
                        else
                        {
                            if (telefones[i] != null)
                            {
                                telefone.numero = telefones[i];
                                telefone.status = 3;
                            }
                        }
                        listatelefonesedit.Add(telefone);
                    }


                    foreach (Email e in listaemailsedit)
                    {

                        bd.Emails.InsertOnSubmit(e);
                        bd.SubmitChanges();

                    }

                    foreach (Telefone t in listatelefonesedit)
                    {

                        bd.Telefones.InsertOnSubmit(t);
                        bd.SubmitChanges();
                    }                      

                    ok = true;
                }
                catch (Exception ed)
                {
                    Console.WriteLine(ed.Message);
                }
                return ok;
            }
        }

            //muda o status do para 0 ou seja esta excluido pois na tabela de consulta a funcao pega apenas o q tem status = 1
        public bool Delete(int id)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Pessoa p = bd.Pessoas.Single(pe => pe.id.Equals(id));
                    p.status = 0;
                    bd.SubmitChanges();

                    List<EmpresasCliente> le = (from ec in bd.EmpresasClientes where ec.empresa_id == p.id && ec.status == 1 select ec).ToList();
                    foreach(EmpresasCliente e in le)
                    {
                        Pessoa c = bd.Pessoas.FirstOrDefault(pe => pe.id == e.cliente_id);
                        c.status = 0;
                        bd.SubmitChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }
        
 //pega uma lista das pessoas que sao empresas inativas
        public List<Pessoa> GetPessoasInat()
        {
            using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
            {
                List<Pessoa> l = new List<Pessoa>();

                l = (from e in bd.Empresas
                     from p in bd.Pessoas
                     where p.id == e.pessoa_id && p.status == 0
                     orderby p.nome
                     select p).ToList();
                return l;
            }
        }
public bool Ativar(int id)
        {
            bool ok = false;
            try
            {
                using (BDMyGProjectDataContext bd = new BDMyGProjectDataContext())
                {
                    Pessoa p = bd.Pessoas.Single(pe => pe.id.Equals(id));
                    p.status = 1;
                    bd.SubmitChanges();

                    List<EmpresasCliente> le = (from ec in bd.EmpresasClientes where ec.empresa_id == p.id && ec.status == 1 select ec).ToList();
                    foreach (EmpresasCliente e in le)
                    {
                        Pessoa c = bd.Pessoas.FirstOrDefault(pe => pe.id == e.cliente_id);
                        c.status = 1;
                        bd.SubmitChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ok;
        }

    }
}
