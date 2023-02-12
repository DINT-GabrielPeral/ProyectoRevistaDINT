using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Mensajeria;
using ProyectoRevistaDINT.Vistas.CrearArticulo;
using ProyectoRevistaDINT.Vistas.CrearAutor;
using ProyectoRevistaDINT.Vistas.EditarAutor;
using ProyectoRevistaDINT.Vistas.FirmarArticulo;
using ProyectoRevistaDINT.Vistas.GestionArticulos;
using ProyectoRevistaDINT.Vistas.GestionAutores;
using ProyectoRevistaDINT.Vistas.Inicio;
using ProyectoRevistaDINT.Vistas.ModerarArticulo;
using ProyectoRevistaDINT.Vistas.PublicarArticulo;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoRevistaDINT.Servicios
{
    public class ServicioNavegacion
    {
        public UserControl CargaGestionAutores()
        {
            return new GestionAutores();
        }
        public UserControl CargaGestionArticulos() 
        {
            return new GestionArticulos();
        }

        public bool? AbrirEliminarAutor()
        {
            return MessageBox.Show(
                "¿Estás seguro de que desea eliminar este autor?",
                "ELIMINAR AUTOR",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Exclamation) == MessageBoxResult.OK;

        }

        internal UserControl CargaInicio()
        {
            return new InicioUC();
        }

        public bool? AbrirCrearAutor()
        {
            CrearAutorVentana dialog = new CrearAutorVentana();
            return dialog.ShowDialog();
        }

        public bool? AbrirEditarAutor(Autor autorSeleccionado)
        {
            EditarAutorWindow dialog = new EditarAutorWindow();
            WeakReferenceMessenger.Default.Send(new AutorSeleccionadoEditarMessage(autorSeleccionado));
            return dialog.ShowDialog();
        }

        internal UserControl AbrirPublicarArticulo()
        {
            return new PublicarArticuloUserControl1();
        }

        public UserControl AbrirCrearArticulo()
        {
            return new CrearArticuloUserControl();
        }

        internal bool? AbrirEliminarArticulo()
        {
            return MessageBox.Show(
                "¿Estás seguro de que desea eliminar este artículo?",
                "ELIMINAR ARTÍCULO",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Exclamation) == MessageBoxResult.OK;
        }

        public bool? AbrirFirmarArticulo()
        {
            FirmarArticulo dialog = new FirmarArticulo();
            return dialog.ShowDialog();
        }

        public bool? AbrirModerarArticulo(Articulo articuloSeleccionado)
        {
            ModerarArticulo dialog = new ModerarArticulo();
            WeakReferenceMessenger.Default.Send(new ArticuloModerarChangedMessage(articuloSeleccionado));
            return dialog.ShowDialog();
        }
    }
}