using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Servicios
{
    public class SeccionesService
    {
        public ObservableCollection<string> GetSecciones()
        {
            return new ObservableCollection<string>
            {
                "Sección 1",
                "Sección 2",
                "Sección 3"
            };
        }
    }
}