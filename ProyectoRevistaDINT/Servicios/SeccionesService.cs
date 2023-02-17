using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer información relacionada con las secciones de la revista.
    /// </summary>
    public class SeccionesService
    {
        /// <summary>
        /// Este método sirve para obtener las secciones que va a contener la revista.
        /// </summary>
        /// <returns>Este método devuelve una lista de secciones para ofrecerlas en la aplicación.</returns>
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