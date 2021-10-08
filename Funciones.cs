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


        }


    }

