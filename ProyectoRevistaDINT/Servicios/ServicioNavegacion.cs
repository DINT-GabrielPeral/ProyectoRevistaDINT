using ProyectoRevistaDINT.Vistas.CrearAutor;
using ProyectoRevistaDINT.Vistas.EditarAutor;
using ProyectoRevistaDINT.Vistas.EliminarAutor;
using ProyectoRevistaDINT.Vistas.GestionAutores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoRevistaDINT.Servicios
{
    class ServicioNavegacion
    {
        public UserControl CargaGestionAutores()
        {
            return new GestionAutores();
        }

        public bool? AbrirEliminarAutor()
        {
            //EliminarAutor dialog = new EliminarAutor();
            //return dialog.ShowDialog();
            return MessageBox.Show("¿Estás seguro de que desea eliminar este autor?",
                        "Eliminar autor",
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Exclamation) == MessageBoxResult.OK;

        }

        public bool? AbrirCrearAutor()
        {
            CrearAutorVentana dialog = new CrearAutorVentana();
            return dialog.ShowDialog();
        }

        public bool? AbrirEditarAutor()
        {
            EditarAutorWindow dialog = new EditarAutorWindow();
            return dialog.ShowDialog();
        }
    }
}
