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

namespace ProyectoRevistaDINT.Vistas.PublicarArticulo
{
    class PublicarArticuloUserControl1VM : ObservableObject
    {
        private ServicioPDF spdf = new ServicioPDF();
        private AzureService azure = new AzureService();
        private DialogosService sd = new DialogosService();
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

        public RelayCommand ComandoPublicarUno{ get; }
        public RelayCommand ComandoEliminarArticulo { get; }

        public PublicarArticuloUserControl1VM()
        {
            sn = new ServicioNavegacion();
            ComandoEliminarArticulo = new RelayCommand(AbrirEliminarArticulo);
            ComandoPublicarUno = new RelayCommand(PublicarUno);
            ArticuloSeleccionado = new Articulo();
            Articulos = new ObservableCollection<Articulo>();

            //sbd.crearArticulo(new Articulo("prueba", "prueba", "prueba", "prueba", 1));
            Articulos = sbd.recibirArticulos();

            
            WeakReferenceMessenger.Default.Register<ArticulosChangedMessage>(this, (r, m) =>
            {
                Articulos = m.Value;
            });
        }

        

        public void PublicarUno()
        {
            string ruta = spdf.generarPDF(ArticuloSeleccionado);
            string link = azure.SubirImagen(ruta);
            ArticuloSeleccionado.Pdf = link;
            ArticuloSeleccionado.Publicado = 1;
            sbd.modificarArticulo(ArticuloSeleccionado);
            sd.MostrarDialogo("Se ha publicado el artículo", "Publicación correcta", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            
            

        }
        public void AbrirEliminarArticulo()
        {
            if (ArticuloSeleccionado.Pdf == "" || ArticuloSeleccionado.Publicado == 0)
            {
                bool? eliminar = sn.AbrirEliminarArticulo();
                if (eliminar == true)
                    sbd.eliminarArticulo(ArticuloSeleccionado);
            }else
            {
                sd.MostrarDialogo(
                    "No se ha podido eliminar el artículo porque ya está publicado",
                    "ERROR AL ELIMINAR EL ARTÍCULO",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
            Articulos = sbd.recibirArticulos();
        }
        
    }
}
