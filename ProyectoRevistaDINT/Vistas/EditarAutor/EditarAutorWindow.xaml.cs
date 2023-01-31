using System.Windows;
using System.Windows.Controls;

namespace ProyectoRevistaDINT.Vistas.EditarAutor
{
    /// <summary>
    /// Lógica de interacción para EditarAutorWindow.xaml
    /// </summary>
    public partial class EditarAutorWindow : Window
    {
        private readonly EditarAutorWindowVM vm;

        public EditarAutorWindow()
        {
            InitializeComponent();
            vm = new EditarAutorWindowVM();
            DataContext = vm;
        }

        private void Cancelar_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Aceptar_Button_Click(object sender, RoutedEventArgs e)
        {
            if (NombreAutor_TextBox.Text != "" && NombreAutor_TextBox.Text != null)
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
            if (NombreAutor_TextBox.Text != "" && NombreAutor_TextBox != null)
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