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
        clsUsuarios objBaseDatosU;
        clsLogs objLogs;

        clsUsuarios objUsuarios;
        public frmUsuario()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmUsuario_KeyDown);
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            objBaseDatosU = new clsUsuarios();
            objBaseDatosU.ConectarBD();
            lblEstadoConexion.Text = objBaseDatosU.estadoConexion;
            objLogs = new clsLogs();

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        private DateTime tiempoDesbloqueo;
        private const int tiempoBloqueo = 5000;
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
                 
                    //hacer condicion para que desactive el boton
                    tiempoDesbloqueo = DateTime.Now.AddMilliseconds(tiempoBloqueo);

                    // Iniciar un temporizador para desbloquear el botón después de cierto tiempo
                    btnIngresar.Enabled = false;
                    Timer timer = new Timer(); //defino al qrido
                    timer.Interval = tiempoBloqueo;
                    timer.Tick += (s, args) =>
                    {
                        btnIngresar.Enabled = true;
                        timer.Stop(); // corto el tempo
                    };
                    timer.Start();
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
                
                objBaseDatosU.ValidarUsuario(usuario, contraseña);
                if (objBaseDatosU.banderaTimer)
                {
                    //hacer condicion para que desactive el boton
                    tiempoDesbloqueo = DateTime.Now.AddMilliseconds(tiempoBloqueo);

                    // Iniciar un temporizador para desbloquear el botón después de cierto tiempo
                    btnIngresar.Enabled = false;
                    Timer timer = new Timer(); //defino al qrido
                    timer.Interval = tiempoBloqueo;
                    timer.Tick += (s, args) =>
                    {
                        btnIngresar.Enabled = true;
                        timer.Stop(); // corto el tempo
                    };
                    timer.Start();
                    
                }
                objLogs.RegistroLogInicioSesion();
                objBaseDatosU.Busqueda(contraseña, usuario);
                txtContraseña.Text = contraseña;
                txtUsuario.Text = usuario;
                errores = 0;
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
        private void frmUsuario_KeyDown(object sender, KeyEventArgs e)
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
