using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    //Definimos la clase
    public class ClassMunicipio
    {
        //Definimos las propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public string poblacion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }

        public ClassMunicipio() { }
        public ClassMunicipio(int id, string nombre, string poblacion, string latitud, string longitud)
        {
            //Hacemos referencia a las propiedades
            this.id = id;
            this.nombre = nombre;
            this.poblacion = poblacion;
            this.latitud = latitud;
            this.longitud = longitud;
        }


    }
}
