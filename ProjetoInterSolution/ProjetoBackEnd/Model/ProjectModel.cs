using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using ProjetoBackEnd.Data;
using System.Data;

namespace ProjetoBackEnd.Model
{
    public class ProjectModel
    {
        public List<Projeto> ListProjetosGerente(int pessoa)
        {
            ProjectData pd = new ProjectData();
            return pd.ListProjetosGerente(pessoa);
        }

        public List<Projeto> ListProjetosCliente(int pessoa)
        {
            ProjectData pd = new ProjectData();
            return pd.ListProjetosCliente(pessoa);
        }

         public string GetEmpresaProjeto(int codigo)
        {
            ProjectData pd = new ProjectData();
            return pd.GetEmpresaProjeto(codigo);
        }

         public Projeto GetProjeto(int codigo)
         {
             ProjectData pd = new ProjectData();
             return pd.GetProjeto(codigo);
         }

         public bool Insert(Projeto p, int company, string[] clientes, DataTable dt)
         {
             ProjectData pd = new ProjectData();
             return pd.Insert(p, company, clientes, dt);
         }

         public bool Delete(int codigo)
         {
             ProjectData pd = new ProjectData();
             return pd.Delete(codigo);
         }

         public bool Ativar(int codigo)
         {
             ProjectData pd = new ProjectData();
             return pd.Ativar(codigo);
         }

         public void RotinaLimpar()
         {
             ProjectData pd = new ProjectData();
             pd.RotinaLimpar();
         }

         public List<Cliente> GetClientesProjeto(int codigo)
         {
             ProjectData pd = new ProjectData();
             return pd.GetClientesProjeto(codigo);
         }

         public List<Projeto> ListProjetosGerente(string palavra, int pessoa)
         {
             ProjectData pd = new ProjectData();
             return pd.ListProjetosGerente(palavra, pessoa);
         }

         public List<Projeto> ListProjetosCliente(string palavra, int pessoa)
         {
             ProjectData pd = new ProjectData();
             return pd.ListProjetosCliente(palavra, pessoa);
         }

         public bool Update(Projeto p, int empresa, string[] clientes)
         {
             ProjectData pd = new ProjectData();
             return pd.Update(p,empresa,clientes);
         }

         public bool Complete(int codigo)
         {
             ProjectData pd = new ProjectData();
             return pd.Complete(codigo);
         }

         public void UpdateValor(Projeto p)
         {
             ProjectData pd = new ProjectData();
             pd.UpdateValor(p);
         }
    }
}
