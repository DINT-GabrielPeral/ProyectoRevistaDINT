using ProyectoRevistaDINT.Clases;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer la generación de la página web de la revista en formato HTML.
    /// </summary>
    class ServicioHTML
    {
        /// <summary>
        /// Este método sirve para generar la página web de la revista en un fichero en formato HTML.
        /// </summary>
        public void GenerarRevista()
        {
            ServicioAccesoBD sbd = new ServicioAccesoBD();
            ObservableCollection<Articulo> articulos = sbd.recibirArticulos();
            String path = @"./Borrar/web.html";
            String revista = "<!DOCTYPE html>" +
                "<html lang=\"es\" xmlns=\"http://www.w3.org/1999/xhtml \">" +
                "<head>" +
                    "<style>* { font-weight: lighter;}h1 { color: rgb(128, 128, 129); margin-top: 50px; height:90%; text-align: center;}nav { margin: 0px auto 0; position: relative; width: 590px; height: 50px; background-color: #34495e; border-radius: 8px; font-size: 0;}nav a { text-decoration:none; line-height: 50px; height: 100%; font-size: 15px; display: inline-block; position: relative; z-index: 1; text-decoration: none; text-transform: uppercase; text-align: center; color: white; cursor: pointer;}nav .animation { position: absolute; height: 100%; top: 0; z-index: 0; transition: all .5s ease 0s; border-radius: 8px;}nav a:nth-child(1) { width: 100px;}nav a:nth-child(2) { width: 110px;}nav a:nth-child(3) { width: 100px;}nav a:nth-child(4) { width: 160px;}nav a:nth-child(5) { width: 120px;}nav .start-home, a:nth-child(1):hover~.animation { width: 100px; left: 0; background-color: #28b379;}nav .start-about, a:nth-child(2):hover~.animation { width: 110px; left: 100px; background-color: #c26d0c;}nav .start-blog, a:nth-child(3):hover~.animation { width: 100px; left: 210px; background-color: #d8cc28;}nav .start-portefolio, a:nth-child(4):hover~.animation { width: 160px; left: 310px; background-color: #a82020;}nav .start-contact, a:nth-child(5):hover~.animation { width: 120px; left: 470px; background-color: #313258;}.card { --background: linear-gradient(to left, #28b379 0%, #313258 100%); width: 190px; height: 254px; padding: 5px; border-radius: 1rem; overflow: visible; background: #2b94f7; background: var(--background); position: relative; z-index: 1; margin: 0px 10px 0px 10px;}.card::after { position: absolute; content: \"\"; top: 30px; left: 0; right: 0; z-index: -1; height: 100%; width: 100%; transform: scale(0.8); filter: blur(25px); background: #f7ba2b; background: var(--background); transition: opacity .5s;}.card-info { --color: #2b2d30; background: var(--color); color: var(--color); display: flex; justify-content: center; align-items: center; width: 100%; height: 100%; overflow: visible; border-radius: .7rem; display: flex;flex-direction: column;}.card .title { font-weight: lighter; letter-spacing: .1em; width: 93%; height: 7%; text-align: center; color: #ecf0f1; font-size: 16px; flex-wrap: nowrap; overflow: hidden;}/*Hover*/.card:hover::after { opacity: 0;}.card:hover .card-info { color: #2ba5f7; transition: color 1s;}body { font-size: 12px; font-family: sans-serif; background: #2c3e50; overflow-x: hidden;}.huecoCategoria { height: 35vh;}.huecoInicio { height: 10vh;}header { position: fixed; width: 100vw; z-index: 1000 !important;}h2 { text-decoration: none; text-transform: uppercase; text-align: center; font-weight: lighter; color: #ecf0f1;}.articulos { display: flex; flex-direction: row; align-items: center; align-content: center; justify-content: center;}.huecoImagen{ width: 90%; height: 70%;} a:hover, a:visited, a:link, a:active{ text-decoration: none;}</style>" +
                    "<meta charset=\"utf-8\"/>" +
                    "<title></title>" +
                "</head>" +
                "<body>";
            revista += "<header> <nav> <a href=\"#inicio\">Fútbol</a> <a href=\"#futbol\">Basket</a> <a href=\"#basket\">Tenis</a> <a href=\"#tenis\">Boxeo</a> <a href=\"#boxeo\">Mas...</a> <div class=\"animation start-home\"></div> </nav></header><div id=\"inicio\" class=\"huecoInicio\"> <h2 class=\"nombreCategoria\"> </h2></div>";
           

            ObservableCollection<Articulo> articulosFutbol = new ObservableCollection<Articulo>();
            ObservableCollection<Articulo> articulosBasket = new ObservableCollection<Articulo>();
            ObservableCollection<Articulo> articulosTenis = new ObservableCollection<Articulo>();
            ObservableCollection<Articulo> articulosBoxeo = new ObservableCollection<Articulo>();
            ObservableCollection<Articulo> articulosOtros = new ObservableCollection<Articulo>();
            foreach (Articulo a in articulos)
            {
                if(a.Pdf != "")
                {
                    if (a.Seccion.Equals("Fútbol")) articulosFutbol.Add(a);
                    else if (a.Seccion.Equals("Baloncesto")) articulosBasket.Add(a);
                    else if (a.Seccion.Equals("Tenis")) articulosTenis.Add(a);
                    else if (a.Seccion.Equals("Boxeo")) articulosBoxeo.Add(a);
                    else  articulosOtros.Add(a);
                    
                    //revista += a.Pdf;
                }
                
            }
            revista += "<div id=\"futbol\" class=\"huecoCategoria\" style=\"margin - top: 5vh; \"> <h2 class=\"nombreCategoria\">FÚTBOL</h2>";
            if(articulosFutbol.Count != 0)
            {
                revista += "<div class=\"articulos\">";
                foreach (Articulo a in articulosFutbol)
                {
                    string rutaLocal = System.IO.Directory.GetCurrentDirectory();
                    
                    
                    String imagen = rutaLocal.Replace("bin\\Debug", "Recursos\\revistaIcono.png");
                    if (a.Imagen != "") imagen = a.Imagen;
                    revista += "<a href=\"" + a.Pdf + "\">";
                    revista += "<div class=\"card\"><div class=\"card-info\"><img class=\"huecoImagen\" src =\"" + imagen + "\"></img>";
                    revista += "<p class=\"title\">" + a.Titulo + "</p> </div> </div> </a>";
                }
                revista += "</div>";
            }
            else
            {
                revista += "<h1>PROXIMAMENTE...</h1>";
            }
            revista += "</div>";

            revista += "<div id=\"basket\" class=\"huecoCategoria\" style=\"margin - top: 5vh; \"> <h2 class=\"nombreCategoria\">BASKET</h2>";
            if (articulosBasket.Count != 0)
            {
                revista += "<div class=\"articulos\">";
                foreach (Articulo a in articulosBasket)
                {
                    string rutaLocal = System.IO.Directory.GetCurrentDirectory();


                    String imagen = rutaLocal.Replace("bin\\Debug", "Recursos\\revistaIcono.png");
                    if (a.Imagen != "") imagen = a.Imagen;
                    revista += "<a href=\"" + a.Pdf + "\">";
                    revista += "<div class=\"card\"><div class=\"card-info\"><img class=\"huecoImagen\" src =\"" + imagen + "\"></img>";
                    revista += "<p class=\"title\">" + a.Titulo + "</p> </div> </div> </a>";
                }
                revista += "</div>";
            }
            else
            {
                revista += "<h1>PROXIMAMENTE...</h1>";
            }
            revista += "</div>";


            revista += "<div id=\"tenis\" class=\"huecoCategoria\" style=\"margin - top: 5vh; \"> <h2 class=\"nombreCategoria\">TENIS</h2>";
            if (articulosTenis.Count != 0)
            {
                revista += "<div class=\"articulos\">";
                foreach (Articulo a in articulosTenis)
                {
                    string rutaLocal = System.IO.Directory.GetCurrentDirectory();


                    String imagen = rutaLocal.Replace("bin\\Debug", "Recursos\\revistaIcono.png");
                    if (a.Imagen != "") imagen = a.Imagen;
                    revista += "<a href=\"" + a.Pdf + "\">";
                    revista += "<div class=\"card\"><div class=\"card-info\"><img class=\"huecoImagen\" src =\"" + imagen + "\"></img>";
                    revista += "<p class=\"title\">" + a.Titulo + "</p> </div> </div> </a>";
                }
                revista += "</div>";
            }
            else
            {
                revista += "<h1>PROXIMAMENTE...</h1>";
            }
            revista += "</div>";

            revista += "<div id=\"boxeo\" class=\"huecoCategoria\" style=\"margin - top: 5vh; \"> <h2 class=\"nombreCategoria\">BOXEO</h2>";
            if (articulosBoxeo.Count != 0)
            {
                revista += "<div class=\"articulos\">";
                foreach (Articulo a in articulosBoxeo)
                {
                    string rutaLocal = System.IO.Directory.GetCurrentDirectory();


                    String imagen = rutaLocal.Replace("bin\\Debug", "Recursos\\revistaIcono.png");
                    if (a.Imagen != "") imagen = a.Imagen;
                    revista += "<a href=\"" + a.Pdf + "\">";
                    revista += "<div class=\"card\"><div class=\"card-info\"><img class=\"huecoImagen\" src =\"" + imagen + "\"></img>";
                    revista += "<p class=\"title\">" + a.Titulo + "</p> </div> </div> </a>";
                }
                revista += "</div>";
            }
            else
            {
                revista += "<h1>PROXIMAMENTE...</h1>";
            }
            revista += "</div>";

            revista += "<div id=\"otros\" class=\"huecoCategoria\" style=\"margin - top: 5vh; \"> <h2 class=\"nombreCategoria\">OTROS</h2>";
            if (articulosOtros.Count != 0)
            {
                revista += "<div class=\"articulos\">";
                foreach (Articulo a in articulosOtros)
                {
                    string rutaLocal = System.IO.Directory.GetCurrentDirectory();


                    String imagen = rutaLocal.Replace("bin\\Debug", "Recursos\\revistaIcono.png");
                    if (a.Imagen != "") imagen = a.Imagen;
                    revista += "<a href=\"" + a.Pdf + "\">";
                    revista += "<div class=\"card\"><div class=\"card-info\"><img class=\"huecoImagen\" src =\"" + imagen + "\"></img>";
                    revista += "<p class=\"title\">" + a.Titulo + "</p> </div> </div> </a>";
                }
                revista += "</div>";
            }
            else
            {
                revista += "<h1>PROXIMAMENTE...</h1>";
            }
            revista += "</div>";

            revista += "</body>" +"</html>";

            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(revista);
                fs.Write(info, 0, info.Length);

            }
            string rutaLocalPdf = System.IO.Directory.GetCurrentDirectory() + "\\Borrar\\web.html";
            System.Diagnostics.Process.Start(rutaLocalPdf);
        }
    }
}
