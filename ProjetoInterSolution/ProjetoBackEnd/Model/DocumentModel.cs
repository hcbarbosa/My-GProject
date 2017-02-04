using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class DocumentModel
    {
        public List<Projeto> ListProjetosGerente(int pessoa)
        {
            DocumentData dd = new DocumentData();
            return dd.ListProjetosGerente(pessoa);
        }

        public List<Projeto> ListProjetosCliente(int pessoa)
        {
            DocumentData dd = new DocumentData();
            return dd.ListProjetosCliente(pessoa);
        }

        public List<Cronograma> GetDocumentosProjeto(int projeto)
        {
            DocumentData dd = new DocumentData();
            return dd.GetDocumentosProjeto(projeto);
        }

        public List<Cronograma> GetNoDocSteps(int projeto)
        {
            DocumentData dd = new DocumentData();
            return dd.GetNoDocSteps(projeto);
        }

        public string GetNomeFase(int fase)
        {
            DocumentData dd = new DocumentData();
            return dd.GetNomeFase(fase);
        }

        public bool InsertDoc(int ativ_id, Documento doc)
        {
            DocumentData dd = new DocumentData();
            return dd.InsertDoc(ativ_id, doc);
        }

        public string GetNomeAtividade(int atividade)
        {
            DocumentData dd = new DocumentData();
            return dd.GetNomeAtividade(atividade);
        }

        public string GetNomeProjeto(int projeto)
        {
            DocumentData dd = new DocumentData();
            return dd.GetNomeProjeto(projeto);
        }

        public List<Cronograma> GetProjetoFases(int projeto)
        {
            DocumentData dd = new DocumentData();
            return dd.GetProjetoFases(projeto);
        }

        public Documento GetDocumento(int documento)
        {
            DocumentData dd = new DocumentData();
            return dd.GetDocumento(documento);
        }

        public List<Cronograma> GetDocInat()
        {
            DocumentData dd = new DocumentData();
            return dd.GetDocInat();
        }


    }
}
