using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CustomerModel
    {
        public CustomerModel() { }

        public Cliente IsvalidUser(string login, string password)
        {
            CustomerData cd = new CustomerData();
            return cd.IsvalidUser(login,password);
        }

        public bool IsvalidPass(int id, string password)
        {
            CustomerData cd = new CustomerData();
            return cd.IsvalidPass(id, password);
        }

        public void AlterLogin(int id, string login)
        {
            CustomerData cd = new CustomerData();
            cd.AlterLogin(id, login);
        }

        public void AlterPass(int id, string pass)
        {
            CustomerData cd = new CustomerData();
            cd.AlterPass(id, pass);
        }

        public Pessoa GetPessoa(int codigo)
        {
            CustomerData cd = new CustomerData();
            return cd.GetPessoa(codigo);
        }

        public Cliente GetCliente(int codigo)
        {
            CustomerData cd = new CustomerData();
            return cd.GetCliente(codigo);
        }

        public List<Pessoa> ListPessoas()
        {
            CustomerData cd = new CustomerData();
            return cd.ListPessoas();
        }
        public List<Pessoa> GetPessoas( int idCompany)
        {
            CustomerData cd = new CustomerData();
            return cd.GetPessoas(idCompany);
        }

        public List<Cliente> GetClientes()
        {
            CustomerData cd = new CustomerData();
            return cd.GetClientes() ;
        }

        public string GetEmpresaDoCliente(int cliente)
        {
            CustomerData cm = new CustomerData();
            return cm.GetEmpresaDoCliente(cliente);
        }

        public bool Insert(Pessoa p, string[] emails, string[] telefones, int company)
        {
            CustomerData cm = new CustomerData();
            return cm.Insert(p, emails, telefones,company);
        }

        public bool Update(Pessoa p, string[] emails, string[] telefones, int company)
        {
            CustomerData cm = new CustomerData();
            return cm.Update(p, emails, telefones, company);
        }

        public bool Delete(int id)
        {
            CustomerData cm = new CustomerData();
            return cm.Delete(id);
        }

	 public bool Ativar(int id)
        {
            CustomerData cd = new CustomerData();
            return cd.Ativar(id);
        }
	
	public List<Pessoa> ListPessoasInat()
        {
            CustomerData cd = new CustomerData();
            return cd.GetPessoasInat();
        }

    }
}
