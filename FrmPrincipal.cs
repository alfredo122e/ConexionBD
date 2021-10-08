using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConexionBD
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Instanciar formulario Test
            FrmTest frm = new FrmTest();
            //Indicar quién es el formulario padre
            frm.MdiParent = this;
            //Mostrar formulario Test
            frm.Show();

        }

        private void municipioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Instanciar formulario Municipio
            FrmMunicipio frm = new FrmMunicipio();
            //Indicar quién es el formulario padre
            frm.MdiParent = this;
            //Mostrar formulario Municipio
            frm.Show();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
