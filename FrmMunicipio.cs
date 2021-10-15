using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConexionBD
{
    public partial class FrmMunicipio : Form
    {
        public FrmMunicipio()
        {
            InitializeComponent();
        }

        //Creamos un objeto
        public ClassMunicipio municipioactual { get; set; }
        private void FrmMunicipio_Load(object sender, EventArgs e)
        {
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Si algún campo está vacío, mostrará un mensaje indicándolo
            if (string.IsNullOrWhiteSpace(Txt1.Text) ||
               string.IsNullOrWhiteSpace(Txt2.Text) ||
               string.IsNullOrWhiteSpace(Txt3.Text) ||
               string.IsNullOrWhiteSpace(Txt4.Text))

                MetroFramework.MetroMessageBox.Show(this, "¡Hay uno o más campos vacíos!", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {

                //Llamamos a la clase municipio
                ClassMunicipio agregar = new ClassMunicipio();
                //Obtenemos los datos ingresados por el usuario mediante los Textbox
                agregar.nombre = Txt1.Text;
                agregar.poblacion = Txt2.Text;
                agregar.latitud = Txt3.Text;
                agregar.longitud = Txt4.Text;

                //Llamamos a la función agregar, que contiene la consulta a la Base de Datos
                int retorno = Funciones.agregar(agregar);
                //Si los datos se obtienen correctamente, se muestra un mensaje indicándolo,al igual que si los registros no se han agregado
                if (retorno > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Se han agregado los registros", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //llamamos al metodo limpiar
                    Limpiar();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se han agregado los registros", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void metroButton4_Click(object sender, EventArgs e)
        {
            //Llamamos al formulario Buscar y lo muestra
            FormBuscar buscar = new FormBuscar();
            buscar.ShowDialog();

            //Si al objeto no está nulo, le asignamos los datos que tiene el municipio seleccionado a los textbox
            if (buscar.MunSeleccionado != null)
            {
                municipioactual = buscar.MunSeleccionado;
                Txt1.Text = buscar.MunSeleccionado.nombre;
                Txt2.Text = buscar.MunSeleccionado.poblacion;
                Txt3.Text = buscar.MunSeleccionado.latitud;
                Txt4.Text = buscar.MunSeleccionado.longitud;

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //Si algún campo está vacío, mostrará un mensaje indicándolo
            if (string.IsNullOrWhiteSpace(Txt1.Text) ||
               string.IsNullOrWhiteSpace(Txt2.Text) ||
               string.IsNullOrWhiteSpace(Txt3.Text) ||
               string.IsNullOrWhiteSpace(Txt4.Text))

                MetroFramework.MetroMessageBox.Show(this, "¡Hay uno o más campos vacíos!", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //Llamamos a la clase municipio
                ClassMunicipio nombreM = new ClassMunicipio();

                //Obtenemos los datos ingresados por el usuario mediante los Textbox
                nombreM.nombre = Txt1.Text;
                nombreM.poblacion = Txt2.Text;
                nombreM.latitud = Txt3.Text;
                nombreM.longitud = Txt4.Text;
                nombreM.id = municipioactual.id;

                //Si los datos se actualizan correctamente, se muestra un mensaje indicándolo,al igual que si los registros no se han actualizado

                if (Funciones.modificar(nombreM) > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "¡Los datos han sido actualizados correctamente!", "Operación con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //llamamos al metodo limpiar
                    Limpiar();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se ha actualizado el registro", "Error al actualizar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //Hacemos la validación de la selección del usuario, se le mostrará un mensaje preguntándole si desea eliminar el registro
            if (MetroFramework.MetroMessageBox.Show(this, "¿Está seguro que desea eliminar el municipio actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                //Si los datos se eliminan correctamente, se muestra un mensaje indicándolo,al igual que si los registros no se han eliminado

                if (Funciones.eliminar(municipioactual.id) > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "El municipio se ha eliminado correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //llamamos al metodo limpiar
                    Limpiar();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se pudo eliminar el municipio", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Si el cliente decide no eliminar el registro, se le muestra un mensaje indicando la cancelación de la operación
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Se ha cancelado la eliminación", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
  
        }
        //Creamos un método para limpiar los TextBox
        void Limpiar()
        {
            Txt1.Clear();
            Txt2.Clear();
            Txt3.Clear();
            Txt4.Clear();
        }
    }
}
