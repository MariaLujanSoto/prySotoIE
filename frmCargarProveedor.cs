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
using System.Runtime.InteropServices;

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
        clsArchivo x = new clsArchivo();
        public void btnCargarProveedor_Click(object sender, EventArgs e)
        {
            if( txtNumeroProveedor.Text != "" && txtEntidad.Text != "" && txtEntidad.Text !="" && txtDireccion.Text != "" && txtNExp.Text != "" && txtJurisdiccion.Text != "" && txtLiquidadorResp.Text != "")
            {
                string[] datosProveedor = new string[] { txtNumeroProveedor.Text = frmMain.numGuia.ToString(), txtEntidad.Text, txtApertura.Text, txtNExp.Text, txtJurisdiccion.Text, txtLiquidadorResp.Text };
                string datosConcatenados = string.Join(";", datosProveedor);
                x.Grabar(datosConcatenados);
                frmMain.numGuia++;

                MessageBox.Show("cargado correctamente");
                txtNumeroProveedor.Clear();
                txtEntidad.Clear();
                txtApertura.Clear();
                txtDireccion.Clear();
                txtNExp.Clear();
                txtJurisdiccion.Clear();
                txtLiquidadorResp.Clear();
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            
            
            
            
            
        }



        string rutaArchivo = "../../Resources/Proveedores/Aseguradoras.csv";

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string ID = txtNumeroProveedor.Text;
            string nuevaLinea = $"{txtNumeroProveedor.Text};{txtEntidad.Text};{txtApertura.Text};{txtNExp.Text};{txtJurisdiccion.Text};{txtDireccion.Text};{txtLiquidadorResp.Text};";

            List<string> lineasArchivo = File.ReadAllLines(rutaArchivo)
                .Select(linea =>
                {
                    string[] parametros = linea.Split(';');
                    return parametros[0] != ID ? linea : nuevaLinea;
                })
                .ToList();

            File.WriteAllLines(rutaArchivo, lineasArchivo);
            MessageBox.Show("Cambios Guardados");
            txtNumeroProveedor.Clear();
            txtEntidad.Clear();
            txtApertura.Clear();
            txtJurisdiccion.Clear();
            txtNExp.Clear();
            txtDireccion.Clear();
            txtLiquidadorResp.Clear();
        }

        private void frmCargarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void frmCargarProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        public void txtEntidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmMain frmMain= new frmMain();
            frmMain.Show();

            this.Hide();
        }
    }
}
