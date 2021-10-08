using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConexionBD
{
    //Creamos una clase con la función conexión para usarla en los demás formularios
    class Conexion
    {
        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(@"Server=localhost;Database=municipios;
                                    Uid = root; Pwd = usbw; SSL Mode = None");
            conexion.Open();
            return conexion;
        }
    }
}
