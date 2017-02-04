using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CompanyModel
    {
        public List<int> ListIdEmpresas()
        {
            CompanyData cd = new CompanyData();
            return cd.GetIdEmpresas();
        }

        public List<Pessoa> ListPessoas()
        {
            CompanyData cd = new CompanyData();
            return cd.GetPessoas();
        }

       
        public List<Pessoa> ListPessoas( string letra)
        {
            CompanyData cd = new CompanyData();
            return cd.GetPessoas(letra);
        }

        public Empresa GetEmpresa(int id)
        {
            CompanyData cd = new CompanyData();
            return cd.GetEmpresa(id);
        }

        public bool Insert(Pessoa em, string[] emails, string[] telefones)
        {
            CompanyData cd = new CompanyData();
            return cd.Insert(em,emails,telefones);
        }

        public bool Update(Pessoa em, string[] emails, string[] telefones)
        {
            CompanyData cd = new CompanyData();
            return cd.Update(em, emails, telefones);
        }

        public bool Delete(int id)
        {
            CompanyData cd = new CompanyData();
            return cd.Delete(id);
        }

	public bool Ativar(int id)
        {
            CompanyData cd = new CompanyData();
            return cd.Ativar(id);
        }
	public List<Pessoa> ListPessoasInat()
        {
            CompanyData cd = new CompanyData();
            return cd.GetPessoasInat();
        }
    }
}
