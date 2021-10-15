using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionBD
{
    public partial class FormBuscar : Form
    {
        public FormBuscar()
        {
            InitializeComponent();
        }
        //Creamos un objeto
        public ClassMunicipio MunSeleccionado { get; set; }
        private void FormBuscar_Load(object sender, EventArgs e)
        {
            //Mostramos los datos en el DataGridView al cargar el formulario
            DataGrid1.DataSource = Funciones.mostrar();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            //Mostramos el dato resultante de la búsqueda en el DataGridVIew
            DataGrid1.DataSource = Funciones.Buscar(txtnombre.Text);

            //llamamos al metodo limpiar
            Limpiar();
        }

        private void metroButton4_Click_2(object sender, EventArgs e)
        {
            //Si seleccionamos una fila, obtenemos el id de ella, sino, mostramos un mensaje indicando que seleccione una fila
            if (DataGrid1.SelectedRows.Count == 1)
            {
                int ID = Convert.ToInt32(DataGrid1.CurrentRow.Cells[0].Value);
                MunSeleccionado = Funciones.obtenerMunicipio(ID);
                this.Close();
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "¡Debe de seleccionar una fila!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Creamos un método para limpiar los TextBox
        void Limpiar()
        {
            txtnombre.Clear();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Limpiar();

            //Llamamos al formulario Buscar y lo cierra
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //Llamamos al formulario Municipio y lo cierra
            this.Hide();
            FrmMunicipio frm = new FrmMunicipio();
            frm.Show();

        }
    }
    }

