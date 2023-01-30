using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Vistas.GestionArticulos
{
    class GestionArticulosVM : ObservableObject
    {
        private ServicioAccesoBD sbd = new ServicioAccesoBD();
        private ServicioNavegacion sn = new ServicioNavegacion();
        private ObservableCollection<Articulo> articulos;
        public ObservableCollection<Articulo> Articulos
        {
            get { return articulos; }
            set { SetProperty(ref articulos, value); }
        }

        public RelayCommand ComandoCrearArticulo { get; }
        public RelayCommand ComandoModerarArticulo { get; }
        public RelayCommand ComandoEliminarArticulo { get; }

        public GestionArticulosVM()
        {
            sn = new ServicioNavegacion();
            ComandoCrearArticulo = new RelayCommand(AbrirCrearArticulo);
            ComandoModerarArticulo = new RelayCommand(AbrirModerarArticulo);
            ComandoEliminarArticulo = new RelayCommand(AbrirEliminarArticulo);
            Articulos = new ObservableCollection<Articulo>();

            Articulos = sbd.recibirArticulos();
        }
        public void AbrirCrearArticulo()
        {
        
        }
        public void AbrirModerarArticulo()
        {

        }
        public void AbrirEliminarArticulo()
        {

        }
    }
}
