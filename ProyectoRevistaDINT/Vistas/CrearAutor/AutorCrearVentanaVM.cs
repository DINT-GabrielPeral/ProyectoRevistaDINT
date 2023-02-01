using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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

namespace ProyectoRevistaDINT.Vistas.CrearAutor
{
    class AutorCrearVentanaVM: ObservableObject
    {
        private ServicioAccesoBD sb;
        private AzureService sa;
        public RelayCommand AñadirAutorCommand { get; }
        public RelayCommand ExaminarCommand { get; }

        private Autor autorNuevo;

        public Autor AutorNuevo
        {
            get { return autorNuevo; }
            set { SetProperty(ref autorNuevo, value); }
        }

        private ObservableCollection<string> redesSociales;

        public ObservableCollection<string> RedesSociales
        {
            get { return redesSociales; }
            set { SetProperty(ref redesSociales, value); }
        }

        private ObservableCollection<Autor> autores;

        public ObservableCollection<Autor> Autores
        {
            get { return autores; }
            set { SetProperty(ref autores, value); }
        }

        public AutorCrearVentanaVM()
        {
            sb = new ServicioAccesoBD();
            sa = new AzureService();
            Autores = sb.recibirAutores();
            AutorNuevo = new Autor();
            redesSociales = new ObservableCollection<string> { "Instagram", "Twitter", "Facebook" };
            AñadirAutorCommand = new RelayCommand(AñadirAutor);
            ExaminarCommand = new RelayCommand(Examinar);
        }

        public void AñadirAutor()
        {
            if(AutorNuevo.Nombre != null && AutorNuevo.Nombre !="")
            {
                sb.crearAutor(AutorNuevo);
            }
            Autores = sb.recibirAutores();

            WeakReferenceMessenger.Default.Send(new AutoresChangedMessage(Autores));

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
                AutorNuevo.Imagen = sa.SubirImagen(filename);
            }
        }
        
    }
}
