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
        clsLogs objLogs;
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsUsuarios();
            objBaseDatos.ConectarBD();
            lblEstadoConexion.Text = objBaseDatos.estadoConexion;
            objLogs = new clsLogs();

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
        int errores = 0;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
        




            contraseña = txtContraseña.Text;
            usuario = txtUsuario.Text;
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                if(errores>2) {
                    MessageBox.Show("Intentalo mas tarde", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usuario = "";
                    contraseña = "";
                    //Timer tmrIngreso = new Timer();
                    //tmrIngreso.Interval = 500;
                    //hacer condicion para que desactive el boton
                }
                else
                {
                    if (txtContraseña.Text == "" && txtUsuario.Text == "")
                    {
                        MessageBox.Show("Complete los Datos para poder registrarse", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        usuario = "";
                        contraseña = "";
                        errores++;
                    }
                    else
                    {
                        if (txtUsuario.Text == "")
                        {
                            MessageBox.Show("Complete el Usuario para poder registrarse", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUsuario.Focus();
                            usuario = "";
                            errores++;

                        }
                        if (txtContraseña.Text == "")
                        {
                            MessageBox.Show("Complete la Contraseña para poder registrarse", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtContraseña.Focus();
                            contraseña = "";
                            errores++;

                        }
                    }
                }
                
            }
            else{
                errores=0;
                objLogs.ValidarUsuario(usuario, contraseña);
                objLogs.RegistroLogInicioSesion();
                objBaseDatos.Busqueda(contraseña, usuario);
                txtContraseña.Text = contraseña;
                txtUsuario.Text = usuario;
            }


            
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
            this.Hide();
        }

        private void lblEstadoConexion_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
