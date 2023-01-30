﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
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

namespace ProyectoRevistaDINT.Vistas.GestionAutores
{
    
    class GestionAutoresVM : ObservableObject
    {
        private ServicioAccesoBD sbd = new ServicioAccesoBD();
        private ServicioNavegacion sn = new ServicioNavegacion();
        private ObservableCollection<Autor> autores;
        public ObservableCollection<Autor> Autores
        {
            get { return autores; }
            set { SetProperty(ref autores, value); }
        }

        public RelayCommand ComandoCrearAutor { get; }

        public RelayCommand ComandoEditarAutor { get; }
        public RelayCommand ComandoEliminarAutor { get; }

        public GestionAutoresVM()
        {
            sn = new ServicioNavegacion();
            ComandoCrearAutor = new RelayCommand(AbrirCrearAutor);
            ComandoEditarAutor = new RelayCommand(AbrirEditarAutor);
            ComandoEliminarAutor = new RelayCommand(AbrirEliminarAutor);
            Autores = new ObservableCollection<Autor>();

            Autores = sbd.recibirAutores();

            WeakReferenceMessenger.Default.Register<AutoresChangedMessage>(this, (r, m) =>
            {
                Autores = m.Value;
            });
        }

        public void AbrirCrearAutor()
        {
            sn.AbrirCrearAutor();
        }
        public void AbrirEditarAutor()
        {
            sn.AbrirEditarAutor();
        }
        public void AbrirEliminarAutor()
        {
            sn.AbrirEliminarAutor();
        }
    }
}
