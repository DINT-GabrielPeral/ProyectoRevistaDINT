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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoRevistaDINT.Vistas.GestionAutores
{
    /// <summary>
    /// Lógica de interacción para GestionAutores.xaml
    /// </summary>
    public partial class GestionAutores : UserControl
    {
        private GestionAutoresVM vm;
        public GestionAutores()
        {
            InitializeComponent();
            vm = new GestionAutoresVM();
            this.DataContext = vm;
        }

        private void Item_DobleClick(object sender, MouseButtonEventArgs e)
        {
            vm.AbrirEditarAutor();
        }


    }
}
