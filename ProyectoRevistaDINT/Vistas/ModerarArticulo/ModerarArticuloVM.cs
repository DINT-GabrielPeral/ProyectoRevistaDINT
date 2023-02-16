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
using System.Windows;

namespace ProyectoRevistaDINT.Vistas.ModerarArticulo
{
    class ModerarArticuloVM : ObservableRecipient
    {
        private readonly DialogosService servicioDialogos;
        private readonly SeccionesService servicioSecciones;
        private readonly ServicioNavegacion servicioNavegacion;
        private readonly ServicioAccesoBD servicioBD;
        private readonly ServicioModeracion servicioModeracion;

        private Articulo articuloNuevo;
        public Articulo ArticuloNuevo
        {
            get => articuloNuevo;
            set => SetProperty(ref articuloNuevo, value);
        }

        private String palabrasEncontradas;
        public String PalabrasEncontradas
        {
            get => palabrasEncontradas;
            set => SetProperty(ref palabrasEncontradas, value);
        }

        public ModerarArticuloVM()
        {
            servicioNavegacion = new ServicioNavegacion();
            servicioBD = new ServicioAccesoBD();
            servicioDialogos = new DialogosService();
            servicioSecciones = new SeccionesService();
            servicioModeracion = new ServicioModeracion();

            WeakReferenceMessenger.Default.Register<ArticuloModerarChangedMessage>(this, (r, m) =>
            {
                ArticuloNuevo = m.Value;
                PalabrasEncontradas = servicioModeracion.devolverPalabrasFeas(ArticuloNuevo.Texto, "");
            });
        }

        public bool AñadirArticulo()
        {
            bool resultado = false;
            try
            {
                ObservableCollection<Articulo> articulos = WeakReferenceMessenger.Default.Send<ArticulosCreadosRequestMessage>();
                Articulo auxiliar = new Articulo();
                foreach (Articulo articulo in articulos)
                {
                    if (ArticuloNuevo.Titulo == articulo.Titulo && !ArticuloNuevo.Equals(articulo))
                    {
                        auxiliar = articulo;
                        break;
                    }
                }

                if (ArticuloNuevo.Titulo != auxiliar.Titulo)
                {
                    PalabrasEncontradas = servicioModeracion.devolverPalabrasFeas(ArticuloNuevo.Texto, "");
                    if (PalabrasEncontradas == "0")
                    {
                        ArticuloNuevo.Moderado = 1;
                        servicioBD.modificarArticulo(ArticuloNuevo);
                        servicioDialogos.MostrarDialogo(
                            "Artículo modificado correctamente",
                            "GESTIÓN ARTÍCULOS",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );
                        resultado = true;
                    }
                    else 
                    {
                        servicioDialogos.MostrarDialogo(
                        "Por favor, elimina las palabras malsonantes",
                        "AVISO",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                    );
                    }
                }
                else
                {
                    servicioDialogos.MostrarDialogo(
                        "No se ha podido modificar el artículo porque ya existe un artículo con ese título",
                        "ERROR AL MODIFICAR EL ARTÍCULO",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
            catch (InvalidOperationException)
            {
                servicioBD.modificarArticulo(ArticuloNuevo);
                servicioDialogos.MostrarDialogo(
                    "Artículo modificado correctamente",
                    "GESTIÓN ARTÍCULOS",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
                resultado = true;
            }
            return resultado;
        }
    }
}
