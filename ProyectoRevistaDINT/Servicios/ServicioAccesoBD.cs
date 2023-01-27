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
                                    id integer primary key,
                                    nombre varchar(100), 
                                    imagen varchar(500),
                                    redSocial varchar(100),
                                    nickRedSocial varchar(100))";
            comando.ExecuteNonQuery(); //Este método ejecuta consultas que no son SELECT


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
            int id;
            string nombre, imagen, redSocial, nickRedSocial;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //Distintas formas de acceder a los campos de la fila actual
                    id = int.Parse(lector["id"].ToString());
                    nombre = (string)lector["nombre"];
                    imagen = (string)lector["imagen"];
                    redSocial = (string)lector["redSocial"];
                    nickRedSocial = (string)lector["nickRedSocial"];
                    listaAutores.Add(new Autor(id, nombre, imagen, redSocial, nickRedSocial));
                }
            }

            conexion.Close();

            return listaAutores;
        }

        public void crearAutor(Autor autor) 
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "INSERT INTO autor VALUES (@id,@nombre,@imagen,@redSocial,@nickRedSocial)";
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@redSocial", SqliteType.Text);
            comando.Parameters.Add("@nickRedSocial", SqliteType.Text);
            comando.Parameters["@nombre"].Value = autor.Nombre;
            comando.Parameters["@imagen"].Value = autor.Imagen;
            comando.Parameters["@redSocial"].Value = autor.RedSocial;
            comando.Parameters["@nickRedSocial"].Value = autor.NickRedSocial;
            comando.Parameters["@id"].Value = autor.Id;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void editarAutor(Autor autor)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "UPDATE autor SET nombre = @nombre, imagen = @imagen, redSocial = @redSocial, nickRedSocial = @nickRedSocial WHERE rowid = @id";
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@redSocial", SqliteType.Text);
            comando.Parameters.Add("@nickRedSocial", SqliteType.Text);
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters["@nombre"].Value = autor.Nombre;
            comando.Parameters["@imagen"].Value = autor.Imagen;
            comando.Parameters["@redSocial"].Value = autor.RedSocial;
            comando.Parameters["@nickRedSocial"].Value = autor.NickRedSocial;
            comando.Parameters["@id"].Value = autor.Id;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void eliminarAutor(Autor autor)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "DELETE FROM autor WHERE rowid = @id";
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters["@id"].Value = autor.Id;
            comando.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
