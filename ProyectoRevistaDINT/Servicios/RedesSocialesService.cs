using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Servicios
{
    public class RedesSocialesService
    {
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