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
    public partial class frmLogo : Form
    {
        public frmLogo()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmLogo_KeyDown);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmUsuario frmUsuario = new frmUsuario();
            frmUsuario.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void frmLogo_KeyDown(object sender, KeyEventArgs e)
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
