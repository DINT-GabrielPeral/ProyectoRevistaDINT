using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ProyectoRevistaDINT.Clases
{
    public class Articulo : ObservableObject
    {
        private string titulo;
        public string Titulo
        {
            get => titulo;
            set => SetProperty(ref titulo, value);
        }

        private string imagen;
        public string Imagen
        {
            get => imagen;
            set => SetProperty(ref imagen, value);
        }

        private string texto;
        public string Texto
        {
            get => texto;
            set => SetProperty(ref texto, value);
        }

        private string seccion;
        public string Seccion
        {
            get => seccion;
            set => SetProperty(ref seccion, value);
        }

        private int autorArticulo;
        public int AutorArticulo
        {
            get => autorArticulo;
            set => SetProperty(ref autorArticulo, value);
        }

        private string pdf;
        public string Pdf
        {
            get => pdf;
            set => SetProperty(ref pdf, value);
        }

        private int moderado;
        public int Moderado
        {
            get => moderado;
            set => SetProperty(ref moderado, value);
        }

        private int publicado;
        public int Publicado
        {
            get => publicado;
            set => SetProperty(ref publicado, value);
        }

        public Articulo(string titulo = "", string imagen = "", string texto = "", string seccion="", int autorArticulo=0)
        {
            Titulo = titulo;
            Imagen = imagen;
            Texto = texto;
            Seccion = seccion;
            AutorArticulo = autorArticulo;
            Pdf = "";
            Moderado = 0;
            Publicado = 0;
        }
        public Articulo(string pdf, int moderado, int publicado, string titulo = "", string imagen = "", string texto = "", string seccion = "", int autorArticulo = 0)
        {
            Titulo = titulo;
            Imagen = imagen;
            Texto = texto;
            Seccion = seccion;
            AutorArticulo = autorArticulo;
            Pdf = pdf;
            Moderado = moderado;
            Publicado = publicado;
        }
    }
}