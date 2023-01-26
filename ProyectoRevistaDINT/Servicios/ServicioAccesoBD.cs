using Microsoft.Data.Sqlite;
using ProyectoRevistaDINT.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoRevistaDINT.Servicios
{
    class ServicioAccesoBD
    {
        public ServicioAccesoBD()
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");

            //Abre la conexión con la base de datos
            conexion.Open();

            //Creamos una tabla utilizando un comando
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = @"CREATE TABLE IF NOT EXISTS autor (
                                    nombre varchar(100) primary key, 
                                    imagen varchar(500),
                                    redSocial varchar(100),
                                    nickRedSocial varchar(100))";
            comando.ExecuteNonQuery(); //Este método ejecuta consultas que no son SELECT

            //Inserción de datos con parámetros
            comando.CommandText = "INSERT INTO autor VALUES (@nombre,@imagen,@redSocial,@nickRedSocial)";
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@redSocial", SqliteType.Text);
            comando.Parameters.Add("@nickRedSocial", SqliteType.Text);
            comando.Parameters["@nombre"].Value = "Juan Lucas";
            comando.Parameters["@imagen"].Value = "imagen";
            comando.Parameters["@redSocial"].Value = "Twitter";
            comando.Parameters["@nickRedSocial"].Value = "xX_JuanLukas_Xx";
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public ObservableCollection<Autor> recibirAutores() 
        {
            ObservableCollection<Autor> listaAutores = new ObservableCollection<Autor>();

            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM autor";
            SqliteDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //Distintas formas de acceder a los campos de la fila actual
                    string nombre = (string)lector["nombre"];
                    string imagen = (string)lector["imagen"];
                    string redSocial = (string)lector["redSocial"];
                    string nickRedSocial = (string)lector["nickRedSocial"];
                    listaAutores.Add(new Autor(nombre, imagen, redSocial, nickRedSocial));
                    MessageBox.Show($"Nombre:{ nombre} - Imagen:{imagen} - RedSocial:{redSocial} - NickRedSocial:{nickRedSocial}");
                }
            }

            conexion.Close();

            return listaAutores;
        }
    }
}
