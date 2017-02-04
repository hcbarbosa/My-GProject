using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjetoFrontEnd.Ajax
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUploadDoc : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            if (context.Request.Files.Count > 0)
            {

                string path = context.Server.MapPath("../Documents/");

                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);

                }



                HttpPostedFile postFile = context.Request.Files[0];

                postFile.SaveAs(path + (DateTime.Now).ToString("dd.MM.yyyy") + "-" + postFile.FileName);

                context.Response.ContentType = "text/plain";

                context.Response.Write(postFile.FileName);

            }



        }





        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
