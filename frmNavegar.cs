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
    public partial class frmNavegar : Form
    {
        public frmNavegar()
        {
            InitializeComponent();
        }

        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            ventanaCarpetas.ShowDialog();
            // seleccion de carpeta

            lblRuta.Text = ventanaCarpetas.SelectedPath;

        }

        private void btnGrabarArchivo_Click(object sender, EventArgs e)
        {
            //ruta del archivo
            string ruta = lblRuta.Text;
            //nombre del archivo
            ruta += "/" + txtNombreArchivo.Text;

            StreamWriter manejoArchivo = new StreamWriter(ruta);
            MessageBox.Show("Archivo creeado " + txtNombreArchivo.Text);

        }
    }
}
