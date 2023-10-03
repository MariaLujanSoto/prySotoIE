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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        Int32 contError = 0;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtContraseña.Text == "admin1") {
                frmMain frmMain = new frmMain();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                contError++;
                
                txtContraseña.Clear();
                txtContraseña.Focus();
                if (contError > 2 ) {
                    MessageBox.Show("Datos Incorrectos");
                    txtContraseña.Clear();
                    txtUsuario.Clear();
                    contError = 0;
                }
                else
                {
                    MessageBox.Show("la contraseña no coincide, vuelva a intentar");
                }
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
