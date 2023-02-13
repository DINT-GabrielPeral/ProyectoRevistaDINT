using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Servicios
{
    class ServicioHTML
    {
        public void GenerarRevista()
        {
            String path = @"./Borrar/web.html";
            String revista = "<!DOCTYPE html>" +
                "<html lang=\"es\" xmlns=\"http://www.w3.org/1999/xhtml \">" +
                "<head>" +
                    "<meta charset=\"utf-8\"/>" +
                    "<title></title>" +
                "</head>" +
                "<body>";
                
                revista += "</body>" +"</html>";

            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(revista);
                fs.Write(info, 0, info.Length);
            }


        }
    }
}
