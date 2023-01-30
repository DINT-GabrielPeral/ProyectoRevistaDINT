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
            sn = new ServicioAccesoBD();
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
            
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            
            Nullable<bool> result = dlg.ShowDialog();


            
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                AutorNuevo.Imagen = filename;
            }
        }
        
    }
}
