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

        public Articulo() { }

        public Articulo(string titulo, string imagen, string texto, string seccion, int autorArticulo)
        {
            Titulo = titulo;
            Imagen = imagen;
            Texto = texto;
            Seccion = seccion;
            AutorArticulo = autorArticulo;
        }
    }
}