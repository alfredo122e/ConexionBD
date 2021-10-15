using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConexionBD
{
    public class Funciones
    {
        public static int agregar(ClassMunicipio add)
        {
            //Realizamos la consulta a la base de datos para ingresar los registros
            int retorno = 0;
            MySqlCommand commando = new MySqlCommand(String.Format("insert into municipio(nombre, poblacion, latitud, longitud)values('{0}','{1}','{2}','{3}')",add.nombre,add.poblacion, add.latitud,add.longitud),Conexion.obtenerConexion());
            retorno = commando.ExecuteNonQuery();
            return retorno;
        }
        public static List<ClassMunicipio> mostrar()
        {
            //Realizamos la consulta a la base de datos para mostrar los registros mediante una lista en el DataGridView
            List<ClassMunicipio> lista = new List<ClassMunicipio>();
            MySqlCommand comando = new MySqlCommand(String.Format("select * from municipio"), Conexion.obtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();

            //Recorremos cada columna de la tabla y obtenemos los datos
            while (reader.Read()){
                ClassMunicipio mun = new ClassMunicipio();
                mun.id = reader.GetInt32(0);
                mun.nombre = reader.GetString(1);
                mun.poblacion = reader.GetString(2);
                mun.latitud = reader.GetString(3);
                mun.longitud = reader.GetString(4);
                lista.Add(mun);
                
            }
            return lista;
        }
        public static int modificar(ClassMunicipio nombre)
        {
            //Realizamos la consulta a la base de datos para actualizar los registros
            int retorno = 0;
            MySqlConnection conection = Conexion.obtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE municipio set nombre='{0}', poblacion='{1}', latitud='{2}', longitud='{3}' WHERE ID={4}",
                nombre.nombre, nombre.poblacion, nombre.latitud, nombre.longitud, nombre.id), conection);

            retorno = comando.ExecuteNonQuery();
            conection.Close();
            return retorno;
        }

        public static int eliminar(int eliminar)
        {
            //Realizamos la consulta a la base de datos para borrar los registros
            int retorno = 0;
            MySqlConnection conection = Conexion.obtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("DELETE FROM municipio WHERE ID={0}", eliminar),conection);

            retorno = comando.ExecuteNonQuery();
            conection.Close();
            return retorno;
        }

         public static List<ClassMunicipio> Buscar (string nombre)
        {
            //Realizamos la consulta a la base de datos para buscar los registros
            List<ClassMunicipio> lista = new List<ClassMunicipio>();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT ID, nombre,poblacion, latitud, longitud FROM municipio WHERE nombre='{0}'",nombre),Conexion.obtenerConexion());

            MySqlDataReader reader = comando.ExecuteReader();

            //Recorremos cada columna de la tabla y obtenemos los datos según la búsqueda
            while (reader.Read())
            {
                ClassMunicipio muni = new ClassMunicipio();
                muni.id = reader.GetInt32(0);
                muni.nombre = reader.GetString(1);
                muni.poblacion = reader.GetString(2);
                muni.latitud = reader.GetString(3);
                muni.longitud = reader.GetString(4);

                lista.Add(muni);

            }
            return lista;
        }

        public static ClassMunicipio obtenerMunicipio(int mID)
        {
            //Realizamos la consulta a la base de datos para obtener los registros
            ClassMunicipio Municipio = new ClassMunicipio();
            MySqlConnection conection = Conexion.obtenerConexion();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT ID, nombre,poblacion, latitud, longitud FROM municipio WHERE ID={0}", mID), conection);

            MySqlDataReader reader = comando.ExecuteReader();

            //Recorremos cada columna de la tabla y obtenemos los datos 
            while (reader.Read())
            {
                Municipio.id = reader.GetInt32(0);
                Municipio.nombre = reader.GetString(1);
                Municipio.poblacion = reader.GetString(2);
                Municipio.latitud = reader.GetString(3);
                Municipio.longitud = reader.GetString(4);
            
            }
            conection.Close();
            return Municipio;
        }
    }
    }
    

