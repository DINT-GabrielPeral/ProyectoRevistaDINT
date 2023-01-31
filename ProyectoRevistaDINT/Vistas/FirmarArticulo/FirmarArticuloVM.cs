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
        private ObservableCollection<String> listaAutores;

        public ObservableCollection<String> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }

        private ObservableCollection<Autor> autoresActual;

        public ObservableCollection<Autor> AutoresActual
        {
            get { return autoresActual; }
            set { SetProperty(ref autoresActual, value); }
        }

        public FirmarArticuloVM() {
            sbd = new ServicioAccesoBD();
            AutoresActual = sbd.recibirAutores();
            foreach(Autor autor in AutoresActual)
            {
                ListaAutores.Add(autor.Nombre);
            }
        }
    }
}
