using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using ProyectoRevistaDINT.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Mensajeria
{
    public class NuevoArticuloValueChangedMessage : ValueChangedMessage<Articulo>
    {
        public NuevoArticuloValueChangedMessage(Articulo articulo) : base(articulo) { }
    }
}