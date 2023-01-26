using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Clases
{
    class Autor : ObservableObject
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string imagen;
        public string Imagen
        {
            get { return imagen; }
            set { SetProperty(ref imagen, value); }
        }

        private string redSocial;
        public string RedSocial
        {
            get { return redSocial; }
            set { SetProperty(ref redSocial, value); }
        }

        private string nickRedSocial;
        public string NickRedSocial
        {
            get { return nickRedSocial; }
            set { SetProperty(ref nickRedSocial, value); }
        }
    }
}
