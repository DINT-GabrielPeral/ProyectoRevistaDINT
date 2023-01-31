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
    class AutoresChangedMessage : ValueChangedMessage<ObservableCollection<Autor>>
    {
        public AutoresChangedMessage(ObservableCollection<Autor> autores) : base(autores) { }
    }
}
