using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySotoIE
{
    public partial class frmMostrarBD : Form
    {
        clsLogs objBaseDatos;

        public frmMostrarBD()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmMostrarBD_KeyDown);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            this.Hide();
            frmMain.Show();
        }

        private void frmMostrarBD_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsLogs();
            lblEstadoConexion.Text = objBaseDatos.estadoConexion;
        }

        private void frmMostrarBD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        private void frmMostrarBD_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es ESC
            if (e.KeyCode == Keys.Escape)
            {
                // Cerrar el formulario
                this.Close();
            }
        }
    }
}
