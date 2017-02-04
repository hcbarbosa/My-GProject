using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class PeopleModel
    {
        public PeopleModel() { }

        public Pessoa GetPessoa(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.GetPessoa(codigo);
        }

        public String GetDefaultEmailPessoa(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.GetDefaultEmailPessoa(codigo);
        }

        public String GetDefaultPhonePessoa(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.GetDefaultPhonePessoa(codigo);
        }

        public bool IsValidEmail(string email)
        {
            PeopleData pd = new PeopleData();
            return pd.IsValidEmail(email);
        }

        public int GetIdLoginPessoa(string email)
        {
            PeopleData pd = new PeopleData();
            return pd.GetIdLoginPessoa(email);
        }

        public String GetLoginPessoa(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.GetLoginPessoa(codigo);
        }

        public List<Estado> ListEstados()
        {
            PeopleData pd = new PeopleData();
            return pd.ListEstados();
        }

        public List<Cidade> ListCidades(string estado)
        {
            PeopleData pd = new PeopleData();
            return pd.ListCidades(estado);
        }

        public string EstadoDaPessoa(int cidade)
        {
            PeopleData pd = new PeopleData();
            return pd.EstadoDaPessoa(cidade);
        }

        public List<Email> ListEmails(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.ListEmails(codigo);
        }

        public List<Telefone> ListTelefones(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.ListTelefones(codigo);
        }

        public string GetImagem(int codigo)
        {
            PeopleData pd = new PeopleData();
            return pd.GetImagem(codigo);
        }

        public void InsertImagem(int id, string imagem)
        {
            PeopleData pd = new PeopleData();
            pd.InsertImagem(id, imagem);
        }

        public void AlterName(int id, string nome)
        {
            PeopleData pd = new PeopleData();
            pd.AlterName(id, nome);
        }

        public void AlterEmail(int id, string email)
        {
            PeopleData pd = new PeopleData();
            pd.AlterEmail(id, email);
        }


    }
}
