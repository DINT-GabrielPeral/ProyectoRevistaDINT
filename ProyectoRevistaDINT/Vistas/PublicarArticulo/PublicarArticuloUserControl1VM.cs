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

namespace ProyectoRevistaDINT.Vistas.PublicarArticulo
{
    class PublicarArticuloUserControl1VM : ObservableObject
    {
        private ServicioAccesoBD sbd = new ServicioAccesoBD();
        private ServicioNavegacion sn = new ServicioNavegacion();
        private ObservableCollection<Articulo> articulos;
        public ObservableCollection<Articulo> Articulos
        {
            get { return articulos; }
            set { SetProperty(ref articulos, value); }
        }
        private Articulo articuloSeleccionado;
        public Articulo ArticuloSeleccionado
        {
            get { return articuloSeleccionado; }
            set { SetProperty(ref articuloSeleccionado, value); }
        }

        public RelayCommand ComandoPublicarArticulo { get; }
        public RelayCommand ComandoEliminarArticulo { get; }

        public PublicarArticuloUserControl1VM()
        {
            sn = new ServicioNavegacion();
            ComandoPublicarArticulo = new RelayCommand(AbrirPublicarArticulos);
            ComandoEliminarArticulo = new RelayCommand(AbrirEliminarArticulo);
            ArticuloSeleccionado = new Articulo();
            Articulos = new ObservableCollection<Articulo>();

            /*sbd.crearArticulo(new Articulo("prueba", "prueba", "prueba", "prueba", 1));*/
            Articulos = sbd.recibirArticulos();

            
            WeakReferenceMessenger.Default.Register<ArticulosChangedMessage>(this, (r, m) =>
            {
                Articulos = m.Value;
            });
        }

        public void AbrirPublicarArticulos()
        {
            
        }
        
        public void AbrirEliminarArticulo()
        {
            bool? eliminar = sn.AbrirEliminarArticulo();
            if (eliminar == true)
                sbd.eliminarArticulo(ArticuloSeleccionado);
            Articulos = sbd.recibirArticulos();
        }
        
    }
}
