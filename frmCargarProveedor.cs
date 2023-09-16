using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace prySotoIE
{
    public partial class frmCargarProveedor : Form
    {
        public frmCargarProveedor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarProveedor_Click(object sender, EventArgs e)
        {
            StreamWriter objsw = new StreamWriter("Nuevoproveedor", true);
            objsw.WriteLine(txtNombreProveedor.Text);
            objsw.Close();

            MessageBox.Show("Cargado Correctamente");
            txtNombreProveedor.Text = "";
            txtNombreProveedor.Focus();

        }
    }
}
