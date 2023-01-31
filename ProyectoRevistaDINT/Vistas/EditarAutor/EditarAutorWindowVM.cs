using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Mensajeria;
using ProyectoRevistaDINT.Servicios;
using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Vistas.EditarAutor
{
    public class EditarAutorWindowVM : ObservableObject
    {
        private readonly RedesSocialesService servicioRedesSociales;
        private readonly DialogosService servicioDialogos;
        private ServicioAccesoBD sb;

        public RelayCommand SeleccionarImagenCommand { get; }
        public RelayCommand EditarAutorCommand { get; }

        private Autor autorActual;
        public Autor AutorActual
        {
            get => autorActual;
            set => SetProperty(ref autorActual, value);
        }

        private ObservableCollection<string> redesSociales;
        public ObservableCollection<string> RedesSociales
        {
            get => redesSociales;
            set => SetProperty(ref redesSociales, value);
        }

        public EditarAutorWindowVM()
        {
            servicioRedesSociales = new RedesSocialesService();
            servicioDialogos = new DialogosService();

            SeleccionarImagenCommand = new RelayCommand(SeleccionarImagen);
            EditarAutorCommand = new RelayCommand(EditarAutor);

            RedesSociales = servicioRedesSociales.GetRedesSociales();
            sb = new ServicioAccesoBD();

            WeakReferenceMessenger.Default.Register<AutorSeleccionadoEditarMessage>(this, (r, m) =>
            {
                AutorActual = m.Value;
            });
        }

        public void SeleccionarImagen() => AutorActual.Imagen = servicioDialogos.AbrirDialogoCargar("IMAGEN");

        public void EditarAutor()
        {
            sb.editarAutor(AutorActual);
        }
    }
}