
using System.Windows.Controls;

namespace ProyectoRevistaDINT.Vistas.CrearArticulo
{
    /// <summary>
    /// Lógica de interacción para CrearArticuloWindow.xaml
    /// </summary>
    public partial class CrearArticuloUserControl : UserControl
    {
        private readonly CrearArticuloUserControlVM vm;

        public CrearArticuloUserControl()
        {
            InitializeComponent();
            vm = new CrearArticuloUserControlVM();
            DataContext = vm;
        }
    }
}