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

namespace ProyectoRevistaDINT.Vistas.CrearAutor
{
   
    public partial class CrearAutorVentana : Window
    {
        AutorCrearVentanaVM vm;
        public CrearAutorVentana()
        {
            vm = new AutorCrearVentanaVM();
            InitializeComponent();
            this.DataContext = vm;
        }

        
    }
}
