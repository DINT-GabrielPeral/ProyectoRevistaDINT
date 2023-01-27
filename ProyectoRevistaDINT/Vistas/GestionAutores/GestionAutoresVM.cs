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

namespace ProyectoRevistaDINT.Vistas.GestionAutores
{
    
    class GestionAutoresVM : ObservableObject
    {
        private ServicioAccesoBD sbd = new ServicioAccesoBD();
        private ServicioNavegacion sn = new ServicioNavegacion();
        private ObservableCollection<Autor> autores;
        public ObservableCollection<Autor> Autores
        {
            get { return autores; }
            set { SetProperty(ref autores, value); }
        }

        public RelayCommand ComandoCrearAutor { get; }

        public GestionAutoresVM()
        {
            sn = new ServicioNavegacion();
            ComandoCrearAutor = new RelayCommand(AbrirCrearAutor);
            Autores = new ObservableCollection<Autor>();

            Autores = sbd.recibirAutores();

            bool hayPrueba = false;
            if(Autores != null)
            {
                foreach (Autor a in Autores)
                {
                    if (a.Id == 0) hayPrueba = true;
                }
            }
            

            if(!hayPrueba) sbd.crearAutor(new Autor(0, "Prueba", "Imagen", "RedSocial", "Nick"));
            
            Autores = sbd.recibirAutores();
        }

        public void AbrirCrearAutor()
        {
            sn.AbrirCrearAutor();
        }
    }
}
