using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRevistaDINT.Clases
{
    public class Autor : ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

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

        public Autor(int id, string nombre, string imagen, string redSocial, string nickRedSocial)
        {
            Id = id;
            Nombre = nombre;
            Imagen = imagen;
            RedSocial = redSocial;
            NickRedSocial = nickRedSocial;
        }
        public Autor( string nombre, string imagen, string redSocial, string nickRedSocial)
        {
            Nombre = nombre;
            Imagen = imagen;
            RedSocial = redSocial;
            NickRedSocial = nickRedSocial;
        }

        public Autor()
        {
        }

    }
}

