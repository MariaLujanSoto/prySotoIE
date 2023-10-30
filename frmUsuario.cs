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
        clsUsuarios objBaseDatos;

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsUsuarios();
            objBaseDatos.ConectarBD();
            lblEstadoConexion.Text = objBaseDatos.estadoConexion;

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        public static string usuario;
        public static string contraseña;
        public static bool hide = false;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            contraseña = txtContraseña.Text;
            usuario = txtUsuario.Text;

            objBaseDatos.Busqueda(contraseña, usuario);

            txtContraseña.Text=contraseña;
            txtUsuario.Text = usuario;
        if (hide) {
                        this.Hide();
                    }

        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            frmRegistroUsuario frmRegistroUsuario = new frmRegistroUsuario();
            frmRegistroUsuario.Show();
        }

        private void lblEstadoConexion_Click(object sender, EventArgs e)
        {

        }
    }
}
