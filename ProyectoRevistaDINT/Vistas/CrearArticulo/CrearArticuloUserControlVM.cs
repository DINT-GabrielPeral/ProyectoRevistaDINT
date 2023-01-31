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
        private readonly ServicioNavegacion sn;

        public RelayCommand SeleccionarImagenCommand { get; }
        public RelayCommand EliminarImagenCommand { get; }
        public RelayCommand FirmarCommand { get; }
        public RelayCommand FinalizarCommand { get; }
        private bool hayImagen;

        public bool HayImagen
        {
            get { return hayImagen; }
            set { SetProperty(ref hayImagen, value); }
        }

        private bool hayFirma;

        public bool HayFirma
        {
            get { return hayFirma; }
            set { SetProperty(ref hayFirma, value); }
        }

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
            sn = new ServicioNavegacion();
            NuevaImagen = "";
            HayImagen = false;
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagen);
            EliminarImagenCommand = new RelayCommand(EliminarImagen);
            FirmarCommand = new RelayCommand(FirmarArticulo);
            FinalizarCommand = new RelayCommand(FinalizarArticulo);

            Secciones = servicioSecciones.GetSecciones();
        }

        public void SeleccionarImagen()
        {
            NuevaImagen = servicioDialogos.AbrirDialogoCargar("IMAGEN");
            if (string.IsNullOrEmpty(NuevaImagen)) HayImagen = false;
            else HayImagen = true;
        }

        public void EliminarImagen()
        {
            NuevaImagen = "";
            HayImagen = false;
        }

        public void FirmarArticulo()
        {
            bool? firmar = sn.AbrirFirmarArticulo();
            if (firmar == true)
            {
                HayFirma = true;
            }
            else HayFirma = false;
        }

        public void FinalizarArticulo()
        {

        }
    }
}