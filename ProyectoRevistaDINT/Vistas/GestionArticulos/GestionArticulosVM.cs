using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Mensajeria;
using ProyectoRevistaDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoRevistaDINT.Vistas.GestionArticulos
{
    class GestionArticulosVM : ObservableObject
    {
        private ServicioAccesoBD sbd;
        private ServicioNavegacion sn;
        private DialogosService servicioDialogos;

        private ObservableCollection<Articulo> articulos;
        public ObservableCollection<Articulo> Articulos
        {
            get { return articulos; }
            set { SetProperty(ref articulos, value); }
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
            sn = new ServicioNavegacion();
            sbd = new ServicioAccesoBD();
            servicioDialogos = new DialogosService();

            ComandoModerarArticulo = new RelayCommand(ModerarArticulo);
            ComandoEliminarArticulo = new RelayCommand(EliminarArticulo);
            Articulos = new ObservableCollection<Articulo>();

            Articulos = sbd.recibirArticulos();

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
    }
}