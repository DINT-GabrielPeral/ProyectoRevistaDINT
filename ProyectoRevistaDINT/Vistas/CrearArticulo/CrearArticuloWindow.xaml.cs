using System.Windows;

namespace ProyectoRevistaDINT.Vistas.CrearArticulo
{
    /// <summary>
    /// Lógica de interacción para CrearArticuloWindow.xaml
    /// </summary>
    public partial class CrearArticuloWindow : Window
    {
        private readonly CrearArticuloWindowVM vm;

        public CrearArticuloWindow()
        {
            InitializeComponent();
            vm = new CrearArticuloWindowVM();
            DataContext = vm;
        }
    }
}