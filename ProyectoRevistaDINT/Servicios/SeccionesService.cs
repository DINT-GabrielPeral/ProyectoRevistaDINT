using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Servicios
{
    public class SeccionesService
    {
        public ObservableCollection<string> GetSecciones()
        {
            return new ObservableCollection<string>
            {
                "Fútbol",
                "Tenis",
                "Baloncesto",
                "Rugby",
                "Automovilismo",
                "Bádminton",
                "Béisbol",
                "Boxeo",
                "Ciclismo",
                "Hockey",
                "Golf",
                "Motociclismo",
                "Natación",
                "Padel",
                "Voleibol"
            };
        }
    }
}