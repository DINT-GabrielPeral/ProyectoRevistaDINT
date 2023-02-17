using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Servicios
{
    /// <summary>
    /// Esta clase sirve para ofrecer información relacionada con las redes sociales.
    /// </summary>
    public class RedesSocialesService
    {
        /// <summary>
        /// Este método sirve para obtener las redes sociales de los autores.
        /// </summary>
        /// <returns>Este método devuelve una lista de redes sociales para ofrecerlas en la aplicación.</returns>
        public ObservableCollection<string> GetRedesSociales()
        {
            return new ObservableCollection<string>
            {
                "Instagram",
                "Twitter",
                "Facebook"
            };
        }
    }
}