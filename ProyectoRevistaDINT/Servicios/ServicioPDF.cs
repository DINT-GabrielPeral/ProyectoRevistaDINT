using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Servicios
{
    class ServicioPDF
    {
        public void generarPDF()
        {
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            gfx.DrawString("TITULO", font, XBrushes.Black,
                    new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            string filename = "NOMBRE_PDF.pdf";

            document.Save(filename);

            //Process.Start(filename);
        }
    }
}
