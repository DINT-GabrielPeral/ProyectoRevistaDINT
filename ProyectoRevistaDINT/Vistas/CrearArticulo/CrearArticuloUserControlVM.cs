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
        private ServicioAccesoBD sb;

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

        private Articulo articuloNuevo;
        public Articulo ArticuloNuevo
        {
            get => articuloNuevo;
            set => SetProperty(ref articuloNuevo, value);
        }


        public CrearArticuloUserControlVM()
        {
            sn = new ServicioNavegacion();
            sb = new ServicioAccesoBD();
            servicioDialogos = new DialogosService();
            servicioSecciones = new SeccionesService();

            HayFirma = false;
            HayImagen = false;
            ArticuloNuevo = new Articulo();

            QuitarAutorCommand = new RelayCommand(QuitarAutor);
            LimpiarArticuloCommand = new RelayCommand(LimpiarArticulo);
            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagen);
            EliminarImagenCommand = new RelayCommand(EliminarImagen);
            FirmarCommand = new RelayCommand(FirmarArticulo);
            FinalizarCommand = new RelayCommand(AñadirArticulo);

            Secciones = servicioSecciones.GetSecciones();
        }

        public void SeleccionarImagen()
        {
            ArticuloNuevo.Imagen = servicioDialogos.AbrirDialogoCargar("IMAGEN");
            if (string.IsNullOrEmpty(ArticuloNuevo.Imagen)) HayImagen = false;
            else HayImagen = true;
        }

        public void EliminarImagen()
        {
            ArticuloNuevo.Imagen = "";
            HayImagen = false;
        }

        public void FirmarArticulo()
        {
            bool? firmar = sn.AbrirFirmarArticulo();
            if (firmar == true)
            {
                HayFirma = true;
                Firma = WeakReferenceMessenger.Default.Send<AutorFirmaRequestMessage>();
                ArticuloNuevo.AutorArticulo = Firma.Id;
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
            ArticuloNuevo.Texto = "";
            ArticuloNuevo.Imagen = "";
            ArticuloNuevo.Titulo = "";
        }

        public void AñadirArticulo()
        {
            sb.crearArticulo(ArticuloNuevo);
            WeakReferenceMessenger.Default.Send(new NuevoArticuloValueChangedMessage(ArticuloNuevo));
        }
    }
}