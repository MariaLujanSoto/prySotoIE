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
        string Entidad;
        private void btnCargarProveedor_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo("../../Resources/Proveedores");
            string ruta = info.FullName;
            Entidad = txtEntidad.Text;

            StreamWriter objsw = new StreamWriter(ruta + "/" + Entidad , true);
            objsw.WriteLine(txtNumeroProveedor.Text);
            objsw.WriteLine(txtEntidad.Text);
            objsw.WriteLine(txtApertura.Text);
            objsw.WriteLine(txtNExp.Text);
            objsw.WriteLine(txtJurisdiccion.Text);
            objsw.WriteLine(txtDireccion.Text);
            objsw.WriteLine(txtLiquidadorResp.Text);
            objsw.Close();

            MessageBox.Show("Cargado Correctamente");
            txtNumeroProveedor.Text = "";
            txtEntidad.Text = "";
            txtApertura.Text = "";
            txtNExp.Text = "";
            txtJurisdiccion.Text = "";
            txtDireccion.Text = "";
            txtLiquidadorResp.Text = "";


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
    }
}
