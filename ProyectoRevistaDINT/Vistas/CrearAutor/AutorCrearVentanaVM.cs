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
        public RelayCommand ExaminarCommand { get; }

        private Autor autorNuevo;

        public Autor AutorNuevo
        {
            get { return autorNuevo; }
            set { SetProperty(ref autorNuevo, value); }
        }

        private string ponerNombre;

        public string PonerNombre
        {
            get { return ponerNombre; }
            set { SetProperty(ref ponerNombre, null); }
        }


        private ObservableCollection<string> redesSociales;

        public ObservableCollection<string> RedesSociales
        {
            get { return redesSociales; }
            set { SetProperty(ref redesSociales, value); }
        }

        public AutorCrearVentanaVM()
        {
            AutorNuevo = new Autor();
            redesSociales = new ObservableCollection<string> { "Instagram", "Twitter", "Facebook" };
            AñadirAutorCommand = new RelayCommand(AñadirAutor);
            ExaminarCommand = new RelayCommand(Examinar);
            ponerNombre = "";
        }

        public void AñadirAutor()
        {
            if(AutorNuevo.Nombre != null && AutorNuevo.Nombre !="")
            {
                sn.crearAutor(AutorNuevo);
                ponerNombre = "";
            }
            else
            {
                ponerNombre = "Necesitas rellenar como minimo el nombre del autor ";
            }
            
        }

        public void Examinar()
        {
            
        }
        
    }
}
