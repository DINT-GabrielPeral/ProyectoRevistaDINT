using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoRevistaDINT.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProyectoRevistaDINT
{
    class MainWindowVM : ObservableObject
    {
        private UserControl contenidoMostrar;
        public UserControl ContenidoMostrar
        {
            get { return contenidoMostrar; }
            set { SetProperty(ref contenidoMostrar, value); }
        }
        private ServicioNavegacion sn;
        private ServicioHTML shtml;
        public RelayCommand comandoGestionAutores { get; }
        public RelayCommand comandoGestionArticulos { get; }
        public RelayCommand comandoCrearArticulo { get; }
        public RelayCommand comandoPublicarArticulo { get; }
        public RelayCommand comandoGenerarRevista { get; }
        public RelayCommand comandoInicio { get; }
        public RelayCommand comandoAyuda { get; }
        public MainWindowVM()
        {
            sn = new ServicioNavegacion();
            shtml = new ServicioHTML();
            comandoGestionAutores = new RelayCommand(MuestraGestionAutores);
            comandoGestionArticulos = new RelayCommand(MuestraGestionArticulos);
            comandoCrearArticulo = new RelayCommand(MuestraCrearArticulo);
            comandoInicio = new RelayCommand(MuestraInicio);
            comandoPublicarArticulo = new RelayCommand(MuestraPublicarArticulo);
            comandoGenerarRevista = new RelayCommand(GeneraRevista);
            comandoAyuda = new RelayCommand(MuestraAyuda);
            MuestraInicio();
        }
        public void MuestraInicio()
        {
            ContenidoMostrar = sn.CargaInicio();
        }
        public void MuestraGestionAutores()
        {
            ContenidoMostrar = sn.CargaGestionAutores();
        }
        public void MuestraGestionArticulos()
        {
            ContenidoMostrar = sn.CargaGestionArticulos();
        }

        public void MuestraCrearArticulo()
        {
            ContenidoMostrar = sn.AbrirCrearArticulo();
        }
        public void MuestraPublicarArticulo()
        {
            ContenidoMostrar = sn.AbrirPublicarArticulo();
        }
        public void MuestraAyuda() 
        {
            string rutaAyuda = System.IO.Directory.GetCurrentDirectory() + "\\Ayuda\\ProyectoRevistaDINT help.chm";
            System.Diagnostics.Process.Start(rutaAyuda);
        }

        public void GeneraRevista()
        {
            shtml.GenerarRevista();
        }
    }
}
