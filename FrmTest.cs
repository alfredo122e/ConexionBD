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
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }


        private void btnTest_Click_1(object sender, EventArgs e)
        {
            //Realizamos la conexión a la Base de Datos
            string connectionString = "";
            MySqlConnection conn;

            try
            {
                connectionString = @"Server=localhost;Database=municipios;
                                    Uid=root;Pwd=usbw; SSL Mode=None";
                conn = new MySqlConnection(connectionString);
                conn.Open();
                MetroFramework.MetroMessageBox.Show(this, "¡Se ha conectado a la base de datos correctamente!", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                conn.Close();
            }
            catch (Exception Ex)
            {
                MetroFramework.MetroMessageBox.Show(this, Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
