﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoRevistaDINT.Vistas.GestionArticulos
{
    /// <summary>
    /// Lógica de interacción para GestionArticulos.xaml
    /// </summary>
    public partial class GestionArticulos : UserControl
    {
        GestionArticulosVM vm = new GestionArticulosVM();
        public GestionArticulos()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
