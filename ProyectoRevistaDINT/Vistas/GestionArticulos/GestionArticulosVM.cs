using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Mensajeria;
using ProyectoRevistaDINT.Servicios;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProyectoRevistaDINT.Vistas.GestionArticulos
{
    class GestionArticulosVM : ObservableObject
    {
        private readonly ServicioAccesoBD sbd;
        private readonly DialogosService servicioDialogos;

        private ObservableCollection<Articulo> articulos;
        public ObservableCollection<Articulo> Articulos
        {
            get => articulos;
            set => SetProperty(ref articulos, value);
        }

        private Articulo articuloSeleccionado;
        public Articulo ArticuloSeleccionado
        {
            get => articuloSeleccionado;
            set => SetProperty(ref articuloSeleccionado, value);
        }

        public RelayCommand ComandoModerarArticulo { get; }
        public RelayCommand ComandoEliminarArticulo { get; }

        public GestionArticulosVM()
        {
            sbd = new ServicioAccesoBD();
            servicioDialogos = new DialogosService();

            ComandoModerarArticulo = new RelayCommand(ModerarArticulo);
            ComandoEliminarArticulo = new RelayCommand(EliminarArticulo);
            Articulos = new ObservableCollection<Articulo>();

            Articulos = sbd.recibirArticulos();

            WeakReferenceMessenger.Default.Register<GestionArticulosVM, ArticulosCreadosRequestMessage>(
                this, (r, m) =>
                {
                    if (!m.HasReceivedResponse)
                    {
                        m.Reply(Articulos);
                    }
                }
            );
            WeakReferenceMessenger.Default.Register<NuevoArticuloValueChangedMessage>(this, (r, m) =>
            {
                ArticuloSeleccionado = m.Value;
            });
        }

        public void ModerarArticulo()
        {

        }

        public void EliminarArticulo()
        {
            if (ArticuloSeleccionado.Pdf == "")
            {
                MessageBoxResult resultado = servicioDialogos.MostrarDialogoPregunta(
                    "¿Estás seguro de que quieres eliminar este artículo?",
                    "AVISO",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                if (resultado == MessageBoxResult.Yes)
                {
                    sbd.eliminarArticulo(ArticuloSeleccionado);
                }

                Articulos = sbd.recibirArticulos();
            }
            else
            {
                servicioDialogos.MostrarDialogo(
                    "No se ha podido eliminar el artículo porque ya está publicado",
                    "ERROR AL ELIMINAR EL ARTÍCULO",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}