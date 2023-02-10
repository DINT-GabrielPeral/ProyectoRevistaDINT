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
        private ServicioPDF spdf = new ServicioPDF();
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

        public RelayCommand ComandoPublicarTodos { get; }
        public RelayCommand ComandoPublicarUno{ get; }
        public RelayCommand ComandoEliminarArticulo { get; }

        public PublicarArticuloUserControl1VM()
        {
            sn = new ServicioNavegacion();
            ComandoPublicarTodos = new RelayCommand(PublicarTodos);
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

        public void PublicarTodos()
        {
            spdf.generarTodosPDF(Articulos);
            sd.MostrarDialogo("Se han generado los pdf", "Generacion correcta", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            
        }

        public void PublicarUno()
        {
            spdf.generarPDF(ArticuloSeleccionado);
            sd.MostrarDialogo("Se ha generado el pdf", "Generacion correcta", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

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
