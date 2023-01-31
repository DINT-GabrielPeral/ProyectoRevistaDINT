using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Mensajeria;
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
        public RelayCommand LimpiarArticuloCommand { get; }
        public RelayCommand FinalizarCommand { get; }
        public RelayCommand FirmarCommand { get; }
        public RelayCommand QuitarAutorCommand { get; }
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

        private Autor firma;

        public Autor Firma
        {
            get { return firma; }
            set { SetProperty(ref firma, value); }
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
            sn = new ServicioNavegacion();
            servicioDialogos = new DialogosService();
            servicioSecciones = new SeccionesService();
            NuevaImagen = "";
            HayFirma = false;
            HayImagen = false;
            QuitarAutorCommand = new RelayCommand(QuitarAutor);
            LimpiarArticuloCommand = new RelayCommand(LimpiarArticulo);
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagen);
            EliminarImagenCommand = new RelayCommand(EliminarImagen);
            FirmarCommand = new RelayCommand(FirmarArticulo);

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
                Firma = WeakReferenceMessenger.Default.Send<AutorFirmaRequestMessage>();
            }
            else HayFirma = false;
        }

        public void QuitarAutor()
        {
            Firma = null;
            HayFirma = false;
        }
        public void LimpiarArticulo()
        {
            HayFirma = false;
            HayImagen = false;
            Firma = null;
            NuevoTexto = "";
            NuevaImagen = "";
            NuevoTitulo = "";
        }
    }
}