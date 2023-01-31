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

namespace ProyectoRevistaDINT.Vistas.PublicarArticulo
{
    /// <summary>
    /// Lógica de interacción para PublicarArticuloUserControl1.xaml
    /// </summary>
    public partial class PublicarArticuloUserControl1 : UserControl
    {
        private PublicarArticuloUserControl1VM vm;
        public PublicarArticuloUserControl1()
        {
            InitializeComponent();
            vm = new PublicarArticuloUserControl1VM();
            this.DataContext = vm;
        }
    }
}
