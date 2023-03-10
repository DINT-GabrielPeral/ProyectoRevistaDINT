using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using ProyectoRevistaDINT.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Mensajeria
{
    class ArticulosChangedMessage : ValueChangedMessage<ObservableCollection<Articulo>>
    {
        public ArticulosChangedMessage(ObservableCollection<Articulo> articulos) : base(articulos) { }
    }
}
