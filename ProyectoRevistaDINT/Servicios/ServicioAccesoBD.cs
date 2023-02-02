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
            SqliteConnection conexion = new SqliteConnection("Data Source=./DatosRevista.db");

            //Abre la conexión con la base de datos
            conexion.Open();

            //Creamos una tabla utilizando un comando
            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = @"CREATE TABLE IF NOT EXISTS autor (
                                    id integer,
                                    nombre varchar(100), 
                                    imagen varchar(500),
                                    redSocial varchar(100),
                                    nickRedSocial varchar(100), 
                                    primary key(id))";
            comando.ExecuteNonQuery(); //Este método ejecuta consultas que no son SELECT

            SqliteCommand comando2 = conexion.CreateCommand();
            comando2.CommandText = @"CREATE TABLE IF NOT EXISTS articulo (
                                    titulo varchar(100) primary key,
                                    imagen varchar(500), 
                                    texto varchar(1000),
                                    seccion varchar(100),
                                    autorArticulo integer,
                                    CONSTRAINT fk_autor FOREIGN KEY (autorArticulo) REFERENCES autor(id))";
            comando2.ExecuteNonQuery();
            
            ObservableCollection<Autor> listaAutores = recibirAutores();

            


            
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

            comando.CommandText = "INSERT INTO autor(nombre,imagen,redSocial,nickRedSocial) VALUES (@nombre,@imagen,@redSocial,@nickRedSocial)";
            /*comando.Parameters.Add("@id", SqliteType.Integer);*/
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@redSocial", SqliteType.Text);
            comando.Parameters.Add("@nickRedSocial", SqliteType.Text);
            comando.Parameters["@nombre"].Value = autor.Nombre;
            comando.Parameters["@imagen"].Value = autor.Imagen;
            comando.Parameters["@redSocial"].Value = autor.RedSocial;
            comando.Parameters["@nickRedSocial"].Value = autor.NickRedSocial;
            /*comando.Parameters["@id"].Value = autor.Id;*/
            comando.ExecuteNonQuery();

            conexion.Close();
        }
        public ObservableCollection<Articulo> recibirArticulos()
        {
            ObservableCollection<Articulo> listaArticulos = new ObservableCollection<Articulo>();

            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM articulo";
            SqliteDataReader lector = comando.ExecuteReader();
            int autorArticulo;
            string titulo, imagen, texto, seccion;

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //Distintas formas de acceder a los campos de la fila actual
                    titulo = (string)lector["titulo"];
                    imagen = (string)lector["imagen"];
                    texto = (string)lector["texto"];
                    seccion = (string)lector["seccion"];
                    autorArticulo = int.Parse(lector["autorArticulo"].ToString());
                    listaArticulos.Add(new Articulo(titulo, imagen, texto, seccion, autorArticulo));
                }
            }

            conexion.Close();

            return listaArticulos;
        }

        public void crearArticulo(Articulo articulo)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "INSERT INTO articulo VALUES (@titulo,@imagen,@texto,@seccion,@autorArticulo)";
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@texto", SqliteType.Text);
            comando.Parameters.Add("@seccion", SqliteType.Text);
            comando.Parameters.Add("@autorArticulo", SqliteType.Integer);
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.Parameters["@imagen"].Value = articulo.Imagen;
            comando.Parameters["@texto"].Value = articulo.Texto;
            comando.Parameters["@seccion"].Value = articulo.Seccion;
            comando.Parameters["@autorArticulo"].Value = articulo.AutorArticulo;
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

        public void eliminarArticulo(Articulo articulo)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "DELETE FROM articulo WHERE rowid = @titulo";
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
