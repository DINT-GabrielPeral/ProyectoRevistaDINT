﻿using Microsoft.Toolkit.Mvvm.Messaging;
using ProyectoRevistaDINT.Clases;
using ProyectoRevistaDINT.Mensajeria;
using ProyectoRevistaDINT.Vistas.CrearArticulo;
using ProyectoRevistaDINT.Vistas.CrearAutor;
using ProyectoRevistaDINT.Vistas.EditarAutor;
using ProyectoRevistaDINT.Vistas.EliminarAutor;
using ProyectoRevistaDINT.Vistas.FirmarArticulo;
using ProyectoRevistaDINT.Vistas.GestionArticulos;
using ProyectoRevistaDINT.Vistas.GestionAutores;
using ProyectoRevistaDINT.Vistas.Inicio;
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
        public UserControl CargaGestionArticulos() 
        {
            return new GestionArticulos();
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

        internal UserControl CargaInicio()
        {
            return new InicioUC();
        }

        public bool? AbrirCrearAutor()
        {
            CrearAutorVentana dialog = new CrearAutorVentana();
            return dialog.ShowDialog();
        }

        public bool? AbrirEditarAutor( Autor autorSeleccionado)
        {
            EditarAutorWindow dialog = new EditarAutorWindow();
            WeakReferenceMessenger.Default.Send(new AutorSeleccionadoEditarMessage(autorSeleccionado));
            return dialog.ShowDialog();
        }

        public UserControl AbrirCrearArticulo()
        {
            return new CrearArticuloUserControl();
        }

        public bool? AbrirFirmarArticulo()
        {
            FirmarArticulo dialog = new FirmarArticulo();
            return dialog.ShowDialog();
        }
    }
}
