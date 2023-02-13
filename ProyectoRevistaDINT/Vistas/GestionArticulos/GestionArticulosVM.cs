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
    public class GestionArticulosVM : ObservableObject
    {
        private readonly ServicioAccesoBD servicioBD;
        private readonly DialogosService servicioDialogos;
        private readonly ServicioNavegacion servicioNavegacion;

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

        public RelayCommand ModerarArticuloCommand { get; }
        public RelayCommand EliminarArticuloCommand { get; }

        public GestionArticulosVM()
        {
            servicioBD = new ServicioAccesoBD();
            servicioDialogos = new DialogosService();
            servicioNavegacion = new ServicioNavegacion();

            ModerarArticuloCommand = new RelayCommand(ModerarArticulo);
            EliminarArticuloCommand = new RelayCommand(EliminarArticulo);
            Articulos = new ObservableCollection<Articulo>();

            Articulos = servicioBD.recibirArticulos();

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
            servicioNavegacion.AbrirModerarArticulo(ArticuloSeleccionado);
            Articulos = servicioBD.recibirArticulos();
        }

        public void EliminarArticulo()
        {
            if (ArticuloSeleccionado.Pdf == "")
            {
                MessageBoxResult resultado = servicioDialogos.MostrarDialogoPregunta(
                    "¿Estás seguro de que quieres eliminar este artículo?",
                    "AVISO"
                );
                if (resultado == MessageBoxResult.Yes)
                {
                    servicioBD.eliminarArticulo(ArticuloSeleccionado);
                }

                Articulos = servicioBD.recibirArticulos();
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