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
        
        private void FrmMunicipio_Load(object sender, EventArgs e)
        {
           
        }


        private void metroButton1_Click(object sender, EventArgs e)
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
                MetroFramework.MetroMessageBox.Show(this,"Se han agregado los registros", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"No se han agregado los registros", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Mostramos los datos en el DataGridView
            DataGrid1.DataSource = Funciones.mostrar();

            //Limpiamos los TextBox
            Txt1.Clear();
            Txt2.Clear();
            Txt3.Clear();
            Txt4.Clear();

        }

        private void DataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
