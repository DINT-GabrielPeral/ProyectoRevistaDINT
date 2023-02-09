using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using ProyectoRevistaDINT.Clases;
using System.Collections.ObjectModel;

namespace ProyectoRevistaDINT.Mensajeria
{
    public class ArticulosCreadosRequestMessage : RequestMessage<ObservableCollection<Articulo>> { }
}