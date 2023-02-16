using ProyectoRevistaDINT.Clases;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer la generación de los artículos creados a formato PDF.
    /// </summary>
    class ServicioPDF
    {
        private ServicioAccesoBD sbd = new ServicioAccesoBD();

        /// <summary>
        /// Este método sirve para generar todos los artículos que hayan creados en la revista a formato PDF.
        /// </summary>
        /// <param name="listaArticulos">En este parámetro se recibe la lista de todos los artículos creados en la revista.</param>
        public void generarTodosPDF(ObservableCollection<Articulo> listaArticulos)
        {
            
            foreach (Articulo a in listaArticulos)
            {
                if (a.Pdf == "")
                {
                    String path = "./Borrar";
                    if (!File.Exists(path)) Directory.CreateDirectory(path);
                    path += "/"+a.Titulo+".jpg";
                    Document
                        .Create(documento =>
                        {
                            documento.Page(page =>
                            {
                                page.Size(PageSizes.A4);
                                page.Margin(2, Unit.Centimetre);
                                page.DefaultTextStyle(x => x.FontSize(15));
                                switch (a.Seccion)
                                {
                                    case "Fútbol":
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Green.Medium);
                                        break;
                                    case "Tenis":
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Yellow.Medium);
                                        break;
                                    case "Baloncesto":
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Orange.Medium);
                                        break;
                                    default:
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Black);
                                        break;

                                }
                                page.Content()
                                    .PaddingVertical(1, Unit.Centimetre)
                                    .Column(x =>
                                    {
                                        x.Spacing(20);

                                        if (a.Imagen != "")
                                        {
                                            using (WebClient client = new WebClient())
                                            {
                                                client.DownloadFile(new Uri(a.Imagen), path);
                                            }

                                            x.Item()
                                               .Image(path);
                                            
                                        }
                                        x.Item().Text(a.Texto);
                                    });

                            });
                        }).GeneratePdf("./Borrar/" + a.Titulo + ".pdf");
                }
            }

        }

        /// <summary>
        /// Este método sirve para generar un artículo de los existentes de la revista a formato PDF.
        /// </summary>
        /// <param name="a">En este parámetro se recibe el artículo que se desea generar a formato PDF.</param>
        public string generarPDF(Articulo a)
        {
                
                    String path = "./Borrar";
                    if (!File.Exists(path)) Directory.CreateDirectory(path);
                String id = generateID();
                    path += "/" + id + ".jpg";
                    Document
                        .Create(documento =>
                        {
                            documento.Page(page =>
                            {
                                page.Size(PageSizes.A4);
                                page.Margin(2, Unit.Centimetre);
                                page.DefaultTextStyle(x => x.FontSize(15));
                                switch (a.Seccion)
                                {
                                    case "Fútbol":
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Green.Medium);
                                        break;
                                    case "Tenis":
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Yellow.Medium);
                                        break;
                                    case "Baloncesto":
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Orange.Medium);
                                        break;
                                    default:
                                        page.Header()
                                            .AlignCenter()
                                            .Text(a.Titulo)
                                            .SemiBold().FontSize(30).FontColor(Colors.Black);
                                        break;

                                }
                                page.Content()
                                    .PaddingVertical(1, Unit.Centimetre)
                                    .Column(x =>
                                    {
                                        x.Spacing(20);

                                        if (a.Imagen != "")
                                        {
                                            using (WebClient client = new WebClient())
                                            {
                                                client.DownloadFile(new Uri(a.Imagen), path);
                                            }

                                            x.Item()
                                               .Image(path);
                                        }
                                        x.Item().Text(a.Texto);
                                    });
                                page.Footer()
                                    .AlignCenter()
                                    .Text(x =>
                                    {
                                        Autor autor = sbd.GetAutor(a.AutorArticulo);
                                        if(autor.RedSocial != "" && autor.NickRedSocial != "")
                                            x.Span(autor.RedSocial + ": "+ autor.NickRedSocial);
                                    });

                            });
                        }).GeneratePdf("./Borrar/" + id + ".pdf");
                
            return System.IO.Directory.GetCurrentDirectory() + "\\Borrar\\" + id + ".pdf";
        }

        public string generateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }
    }
}
