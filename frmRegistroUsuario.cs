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
    public partial class frmRegistroUsuario : Form
    {
        clsLog objBaseDatos;

        public frmRegistroUsuario()
        {
            InitializeComponent();
        }
        public static string usuarioN;
        public static string contraseñaN;
        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {
            
            objBaseDatos = new clsLog();
            objBaseDatos.ConectarBD();


        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuarioN = txtUsuario.Text;
            contraseñaN = txtContraseña.Text;

            if (txtUsuario.Text != "" && txtContraseña.Text != "")
            {
                objBaseDatos.Grabar(contraseñaN, usuarioN);
                txtContraseña.Text = contraseñaN;
                txtUsuario.Text = usuarioN;
            }
            if(txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                
                if(txtContraseña.Text == "" && txtUsuario.Text == "")
                {
                    MessageBox.Show("Complete los Datos para poder registrarse");
                   
                }
                else
                {
                    if (txtUsuario.Text == "")
                    {
                        MessageBox.Show("Complete el Usuario para poder registrarse");
                        txtUsuario.Focus();
                    }
                    if (txtContraseña.Text == "")
                    {
                        MessageBox.Show("Complete la Contraseña para poder registrarse");
                        txtContraseña.Focus();
                    }
                }
                
            }
          







        }
    }



}
