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
    /// <summary>
    /// Esta clase sirve para ofrecer las acciones que se pueden realizar en la base de datos de la revista en SQLite.
    /// </summary>
    class ServicioAccesoBD
    {
        /// <summary>
        /// En este constructor se inicializa la base de datos creando sus tablas para almacenar los datos.
        /// </summary>
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
                                    pdf varchar(500),
                                    CONSTRAINT fk_autor FOREIGN KEY (autorArticulo) REFERENCES autor(id))";
            comando2.ExecuteNonQuery();
            
            ObservableCollection<Autor> listaAutores = recibirAutores();

            


            
            conexion.Close();
        }

        /// <summary>
        /// Este método sirve para hacer una consulta a la base de datos obteniendo todos los autores almacenados en la tabla autor.
        /// </summary>
        /// <returns>Este método devuelve una lista de autores proveniente de la base de datos después de la consulta realizada.</returns>
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

        /// <summary>
        /// Este método sirve para obtener un autor a partir su id
        /// </summary>
        /// <param name="idAutor">En este parámetro se recibe el id del autor que se quiere obtener</param>
        public Autor GetAutor(int idAutor) 
        {
            Autor autorResultado = new Autor();

            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM autor WHERE id = @id";
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters["@id"].Value = idAutor;
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
                    autorResultado = new Autor(id, nombre, imagen, redSocial, nickRedSocial);
                }
            }
            return autorResultado;
        }

        /// <summary>
        /// Este método sirve para crear un autor nuevo y meterlo en la base de datos.
        /// </summary>
        /// <param name="autor">En este parámetro se recibe el autor nuevo ya creado para luego introducirlo en la base de datos.</param>
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

        /// <summary>
        /// Este método sirve para hacer una consulta a la base de datos obteniendo todos los artículos almacenados en la tabla articulo.
        /// </summary>
        /// <returns>Este método devuelve una lista de artículos proveniente de la base de datos después de la consulta realizada.</returns>
        public ObservableCollection<Articulo> recibirArticulos()
        {
            ObservableCollection<Articulo> listaArticulos = new ObservableCollection<Articulo>();

            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM articulo";
            SqliteDataReader lector = comando.ExecuteReader();
            int autorArticulo;
            string titulo, imagen, texto, seccion, pdf;

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
                    pdf = (string)lector["pdf"];
                    listaArticulos.Add(new Articulo(pdf, titulo, imagen, texto, seccion, autorArticulo));
                }
            }

            conexion.Close();

            return listaArticulos;
        }

        /// <summary>
        /// Este método sirve para crear un artículo nuevo y meterlo en la base de datos.
        /// </summary>
        /// <param name="articulo">En este parámetro se recibe el artículo nuevo ya creado para luego introducirlo en la base de datos.</param>
        public void crearArticulo(Articulo articulo)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "INSERT INTO articulo VALUES (@titulo,@imagen,@texto,@seccion,@autorArticulo,@pdf)";
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters.Add("@imagen", SqliteType.Text);
            comando.Parameters.Add("@texto", SqliteType.Text);
            comando.Parameters.Add("@seccion", SqliteType.Text);
            comando.Parameters.Add("@autorArticulo", SqliteType.Integer);
            comando.Parameters.Add("@pdf", SqliteType.Text);
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.Parameters["@imagen"].Value = articulo.Imagen;
            comando.Parameters["@texto"].Value = articulo.Texto;
            comando.Parameters["@seccion"].Value = articulo.Seccion;
            comando.Parameters["@autorArticulo"].Value = articulo.AutorArticulo;
            comando.Parameters["@pdf"].Value = articulo.Pdf;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        /// <summary>
        /// Este método sirve para modificar los datos de un artículo existente en la base de datos.
        /// </summary>
        /// <param name="articulo">En este parámetro se recibe el artículo existente ya modificado para luego actualizarlo en la base de datos.</param>
        public void modificarArticulo(Articulo articulo)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "UPDATE articulo SET titulo = @titulo, texto = @texto WHERE titulo = @titulo";
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters.Add("@texto", SqliteType.Text);
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.Parameters["@texto"].Value = articulo.Texto;

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

        /// <summary>
        /// Este método sirve para eliminar un autor existente de la base de datos.
        /// </summary>
        /// <param name="autor">En este parámetro se recibe el autor a eliminar de la base de datos.</param>
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

        /// <summary>
        /// Este método sirve para eliminar un artículo existente de la base de datos.
        /// </summary>
        /// <param name="articulo">En este parámetro se recibe el artículo a eliminar de la base de datos.</param>
        public void eliminarArticulo(Articulo articulo)
        {
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "DELETE FROM articulo WHERE titulo = @titulo";
            comando.Parameters.Add("@titulo", SqliteType.Text);
            comando.Parameters["@titulo"].Value = articulo.Titulo;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        /// <summary>
        /// Este método sirve para saber si un autor tiene artículos creados en la base de datos.
        /// </summary>
        /// <param name="autor">En este parámetro se recibe el autor a comprobar sobre sus artículos.</param>
        /// <returns>Este método devuelve un booleano indicando si el autor tiene artículos (true) o no tiene (false).</returns>
        public bool tieneArticulos(Autor autor)
        {
            bool tiene = false;
            SqliteConnection conexion = new SqliteConnection("Data Source=DatosRevista.db");
            conexion.Open();

            SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText = "SELECT COUNT(*) AS 'total' FROM articulo JOIN autor ON articulo.autorArticulo = autor.id WHERE autor.id = @id GROUP BY autor.id";
            comando.Parameters.Add("@id", SqliteType.Integer);
            comando.Parameters["@id"].Value = autor.Id;
            comando.ExecuteNonQuery();

            SqliteDataReader lector = comando.ExecuteReader();
            int total;
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //Distintas formas de acceder a los campos de la fila actual
                    total = int.Parse(lector["total"].ToString());
                    if (total != 0) tiene = true;

                }
            }

            conexion.Close();
            return tiene;
        }
    }
}
