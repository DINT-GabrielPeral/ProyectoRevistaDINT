using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoRevistaDINT.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.VistasModelo
{
    class EditarAutorVM : ObservableObject
    {
        private ObservableCollection<Autor> listaAutores;
        public ObservableCollection<Autor> ListaAutores
        {
            get { return listaAutores; }
            set { SetProperty(ref listaAutores, value); }
        }

        public EditarAutorVM() 
        {
            //Aquí se carga la lista de autores desde la BD
            //listaAutores =
        }
    }
}
