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

namespace ProyectoRevistaDINT.Vistas.CrearAutor
{
    class AutorCrearVentanaVM: ObservableObject
    {
        private ServicioAccesoBD sn;
        public RelayCommand AñadirAutorCommand { get; }

        public AutorCrearVentanaVM()
        {
            AñadirAutorCommand = new RelayCommand(AñadirAutor);
        }

        public void AñadirAutor()
        {
           // sn.crearAutor(new Autor());
        }
    }
}
