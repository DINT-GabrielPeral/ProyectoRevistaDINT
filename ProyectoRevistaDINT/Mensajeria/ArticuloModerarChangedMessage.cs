using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using ProyectoRevistaDINT.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Mensajeria
{
    class ArticuloModerarChangedMessage : ValueChangedMessage<Articulo>
    {
        public ArticuloModerarChangedMessage(Articulo articulo) : base(articulo) { }
    }
}
