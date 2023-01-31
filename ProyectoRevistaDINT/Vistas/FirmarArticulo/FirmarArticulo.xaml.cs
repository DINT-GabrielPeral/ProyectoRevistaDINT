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

namespace ProyectoRevistaDINT.Vistas.FirmarArticulo
{
    /// <summary>
    /// Lógica de interacción para FirmarArticulo.xaml
    /// </summary>
    public partial class FirmarArticulo : Window
    {
        private FirmarArticuloVM vm;
        public FirmarArticulo()
        {
            vm = new FirmarArticuloVM();
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
