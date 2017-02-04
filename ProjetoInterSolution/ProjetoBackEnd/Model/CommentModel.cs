using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CommentModel
    {
        public List<Comentario> ListComentarios(int projeto)
        {
            CommentData cd = new CommentData();
            return cd.ListComentarios(projeto);
        }

        public bool Insert(Comentario c)
        {
            CommentData cd = new CommentData();
            return cd.Insert(c);
        }

        public void Delete(int id)
        {
            CommentData cd = new CommentData();
            cd.Delete(id);
        }

    }
}
