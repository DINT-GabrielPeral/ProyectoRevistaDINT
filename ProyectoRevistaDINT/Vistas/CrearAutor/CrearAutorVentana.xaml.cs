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

        private void Cancelar_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Aceptar_Button_Click(object sender, RoutedEventArgs e)
        {
            if(NombreAutor_TextBox.Text!=""&&NombreAutor_TextBox.Text!=null)
            {
                this.Close();
            }
            else
            {
                FaltaNombre_Label.Visibility = Visibility.Visible;
            }
            
        }

        private void NombreAutor_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(NombreAutor_TextBox.Text!=""&&NombreAutor_TextBox!=null)
            {
                FaltaNombre_Label.Visibility = Visibility.Collapsed;
            }
            else
            {
                FaltaNombre_Label.Visibility = Visibility.Visible;
            }
            
        }
    }
}
