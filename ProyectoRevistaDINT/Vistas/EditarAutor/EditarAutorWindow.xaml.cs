using System.Windows;

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
    }
}