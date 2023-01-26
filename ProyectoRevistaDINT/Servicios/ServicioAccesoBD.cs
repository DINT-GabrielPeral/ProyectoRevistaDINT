using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
