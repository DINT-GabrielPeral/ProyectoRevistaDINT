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
    /// <summary>
    /// Esta clase sirve para ofrecer las navegaciones por las diferentes vistas de la aplicación.
    /// </summary>
    public class ServicioNavegacion
    {
        /// <summary>
        /// Este método sirve para cargar la vista de gestión de autores.
        /// </summary>
        /// <returns>Este método devuelve la vista de gestión de autores como un UserControl.</returns>
        public UserControl CargaGestionAutores()
        {
            return new GestionAutores();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de gestión de artículos.
        /// </summary>
        /// <returns>Este método devuelve la vista de gestión de artículos como un UserControl.</returns>
        public UserControl CargaGestionArticulos() 
        {
            return new GestionArticulos();
        }

        /// <summary>
        /// Este método sirve para cargar un diálogo de pregunta diciendo si está seguro de que quiere eliminar el autor seleccionado.
        /// </summary>
        /// <returns>Este método devuelve un booleano indicando si el usuario le ha dado a Sí (true) o a No (false).</returns>
        public bool? AbrirEliminarAutor()
        {
            return MessageBox.Show(
                "¿Estás seguro de que desea eliminar este autor?",
                "ELIMINAR AUTOR",
                MessageBoxButton.YesNo,
                MessageBoxImage.Exclamation) == MessageBoxResult.Yes;

        }

        /// <summary>
        /// Este método sirve para cargar la vista inicial de la aplicación de la revista.
        /// </summary>
        /// <returns>Este método devuelve la vista inicial como un UserControl.</returns>
        internal UserControl CargaInicio()
        {
            return new InicioUC();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de crear un autor como un diálogo.
        /// </summary>
        /// <returns>Este método devuelve un booleano indicando si el usuario ha creado el autor (true) o no (false).</returns>
        public bool? AbrirCrearAutor()
        {
            CrearAutorVentana dialog = new CrearAutorVentana();
            return dialog.ShowDialog();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de editar un autor como un diálogo.
        /// </summary>
        /// <param name="autorSeleccionado">En este parámetro se recibe el autor que haya seleccionado el usuario para editarle sus datos.</param>
        /// <returns>Este método devuelve un booleano indicando si el usuario ha editado el autor (true) o no (false).</returns>
        public bool? AbrirEditarAutor(Autor autorSeleccionado)
        {
            EditarAutorWindow dialog = new EditarAutorWindow();
            WeakReferenceMessenger.Default.Send(new AutorSeleccionadoEditarMessage(autorSeleccionado));
            return dialog.ShowDialog();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de publicar un artículo.
        /// </summary>
        /// <returns>Este método devuelve la vista de publicar un artículo como un UserControl.</returns>
        internal UserControl AbrirPublicarArticulo()
        {
            return new PublicarArticuloUserControl1();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de crear un artículo.
        /// </summary>
        /// <returns>Este método devuelve la vista de crear un artículo como un UserControl.</returns>
        public UserControl AbrirCrearArticulo()
        {
            return new CrearArticuloUserControl();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de eliminar un artículo como un diálogo.
        /// </summary>
        /// <returns>Este método devuelve un booleano indicando si el usuario ha eliminado el autor (true) o no (false).</returns>
        internal bool? AbrirEliminarArticulo()
        {
            return MessageBox.Show(
                "¿Estás seguro de que desea eliminar este artículo?",
                "ELIMINAR ARTÍCULO",
                MessageBoxButton.YesNo,
                MessageBoxImage.Exclamation) == MessageBoxResult.Yes;
        }

        /// <summary>
        /// Este método sirve para cargar la vista de firmar un artículo como un diálogo.
        /// </summary>
        /// <returns>Este método devuelve un booleano indicando si el usuario ha firmado el artículo (true) o no (false).</returns>
        public bool? AbrirFirmarArticulo()
        {
            FirmarArticulo dialog = new FirmarArticulo();
            return dialog.ShowDialog();
        }

        /// <summary>
        /// Este método sirve para cargar la vista de moderar un artículo como un diálogo.
        /// </summary>
        /// <param name="articuloSeleccionado">En este parámetro se recibe el artículo que haya seleccionado el usuario para moderarle el contenido.</param>
        /// <returns>Este método devuelve un booleano indicando si el usuario ha moderado el artículo (true) o no (false).</returns>
        public bool? AbrirModerarArticulo(Articulo articuloSeleccionado)
        {
            ModerarArticulo dialog = new ModerarArticulo();
            WeakReferenceMessenger.Default.Send(new ArticuloModerarChangedMessage(articuloSeleccionado));
            return dialog.ShowDialog();
        }
    }
}