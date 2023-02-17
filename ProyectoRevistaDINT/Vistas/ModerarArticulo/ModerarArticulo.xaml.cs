using System;
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
using System.Windows.Shapes;

namespace ProyectoRevistaDINT.Vistas.ModerarArticulo
{
    /// <summary>
    /// Lógica de interacción para ModerarArticulo.xaml
    /// </summary>
    public partial class ModerarArticulo : Window
    {
        ModerarArticuloVM vm = new ModerarArticuloVM();
        public ModerarArticulo()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vm.AñadirArticulo())
            {
                DialogResult = true;
            }
        }
    }
}
