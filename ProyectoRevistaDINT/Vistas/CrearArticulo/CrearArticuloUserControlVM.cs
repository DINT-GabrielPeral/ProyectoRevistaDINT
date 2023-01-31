using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoRevistaDINT.Servicios;
using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Vistas.CrearArticulo
{
    public class CrearArticuloUserControlVM : ObservableObject
    {
        private readonly DialogosService servicioDialogos;
        private readonly SeccionesService servicioSecciones;

        public RelayCommand SeleccionarImagenCommand { get; }

        private string nuevoTitulo;
        public string NuevoTitulo
        {
            get => nuevoTitulo;
            set => SetProperty(ref nuevoTitulo, value);
        }

        private string nuevaImagen;
        public string NuevaImagen
        {
            get => nuevaImagen;
            set => SetProperty(ref nuevaImagen, value);
        }

        private ObservableCollection<string> secciones;
        public ObservableCollection<string> Secciones
        {
            get => secciones;
            set => SetProperty(ref secciones, value);
        }

        private string seccionSeleccionado;
        public string SeccionSeleccionado
        {
            get => seccionSeleccionado;
            set => SetProperty(ref seccionSeleccionado, value);
        }

        private string nuevoTexto;
        public string NuevoTexto
        {
            get => nuevoTexto;
            set => SetProperty(ref nuevoTexto, value);
        }

        public CrearArticuloUserControlVM()
        {
            servicioDialogos = new DialogosService();
            servicioSecciones = new SeccionesService();

            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagen);

            Secciones = servicioSecciones.GetSecciones();
        }

        public void SeleccionarImagen() => NuevaImagen = servicioDialogos.AbrirDialogoCargar("IMAGEN");
    }
}