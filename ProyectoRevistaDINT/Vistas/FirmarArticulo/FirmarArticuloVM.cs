using Microsoft.Toolkit.Mvvm.ComponentModel;
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

namespace ProyectoRevistaDINT.Vistas.FirmarArticulo
{
    class FirmarArticuloVM : ObservableObject
    {

        private ServicioAccesoBD sbd;
        private ServicioNavegacion sn;

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
            WeakReferenceMessenger.Default.Register<FirmarArticuloVM, AutorFirmaRequestMessage>
                (this, (r, m) =>
                {
                    if (!m.HasReceivedResponse)
                        m.Reply(r.AutorSeleccionado);
                    

                    
                });
        }

        internal void AbreNuevoAutor()
        {
            sn.AbrirCrearAutor();
            AutoresActual = sbd.recibirAutores();
        }

        public FirmarArticuloVM()
        {
            sn = new ServicioNavegacion();
            sbd = new ServicioAccesoBD();
            AutoresActual = sbd.recibirAutores();
        }
    }
}