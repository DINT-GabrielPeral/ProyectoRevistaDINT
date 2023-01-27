using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Vistas.GestionAutores
{
    
    class GestionAutoresVM : ObservableObject
    {
        private ServicioAccesoBD sbd = new ServicioAccesoBD();
        private ObservableCollection<Autor> autores;
        public ObservableCollection<Autor> Autores
        {
            get { return autores; }
            set { SetProperty(ref autores, value); }
        }

        public GestionAutoresVM()
        {
            Autores = new ObservableCollection<Autor>();
            //sbd.crearAutor(new Autor(0, "Prueba", "Imagen", "RedSocial", "Nick"));
            Autores = sbd.recibirAutores();
        }
    }
}
