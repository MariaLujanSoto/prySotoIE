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
using System.Security.Cryptography.X509Certificates;

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
        Int32 numGuia = 158;
        clsArchivo x = new clsArchivo();
        public void btnCargarProveedor_Click(object sender, EventArgs e)
        {
            string[] datosProveedor = new string[] {numGuia.ToString(),txtEntidad.Text,txtApertura.Text,txtNExp.Text,txtJurisdiccion.Text,txtLiquidadorResp.Text};
            string datosConcatenados = string.Join(";",datosProveedor);
            x.Grabar(datosConcatenados);
            numGuia++;

            MessageBox.Show("cargado correctamente");
            txtEntidad.Text = "";
            txtApertura.Text = "";
            txtDireccion.Text = "";
            txtNExp.Text = "";
            txtJurisdiccion.Text = "";
            txtLiquidadorResp.Text = "";

            frmCargarProveedor cargarProveedor = new frmCargarProveedor();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
        }

        private void frmCargarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void frmCargarProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
            this.Hide();
        }

        public void txtEntidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
