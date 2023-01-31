using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Vistas.FirmarArticulo
{
    class FirmarArticuloVM : ObservableObject
    {
        
        private ServicioAccesoBD sbd;

        private ObservableCollection<Autor> autoresActual;

        public ObservableCollection<Autor> AutoresActual
        {
            get { return autoresActual; }
            set { SetProperty(ref autoresActual, value); }
        }

        private Autor autorSeleccionado;
        public Autor AutorSeleccionado
        {
            get { return autorSeleccionado; }
            set { SetProperty(ref autorSeleccionado, value); }
        }

        internal void FirmarArticulo()
        {
            
        }

        public FirmarArticuloVM() {
            sbd = new ServicioAccesoBD();
            AutoresActual = sbd.recibirAutores();
        }
    }
}
