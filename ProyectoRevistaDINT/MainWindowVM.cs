﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
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
        public RelayCommand comandoGestionAutores { get; }
        public RelayCommand comandoGestionArticulos { get; }
        public RelayCommand comandoCrearArticulo { get; }
        public MainWindowVM()
        {
            sn = new ServicioNavegacion();
            comandoGestionAutores = new RelayCommand(MuestraGestionAutores);
            comandoGestionArticulos = new RelayCommand(MuestraGestionArticulos);
            comandoCrearArticulo = new RelayCommand(MuestraCrearArticulo);
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
    }
}
