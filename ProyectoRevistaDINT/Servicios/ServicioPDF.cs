﻿using ProyectoRevistaDINT.Clases;
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
    class ServicioPDF
    {
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

        public void generarPDF(Articulo a)
        {
                if (a.Pdf == "")
                {
                    String path = "./Borrar";
                    if (!File.Exists(path)) Directory.CreateDirectory(path);
                    path += "/" + a.Titulo + ".jpg";
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
}