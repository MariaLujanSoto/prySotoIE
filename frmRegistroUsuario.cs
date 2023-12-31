﻿using System;
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
        clsUsuarios objUsuarios;

        public frmRegistroUsuario()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(frmRegistroUsuario_KeyDown);
        }
        public static string usuarioN;
        public static string contraseñaN;
        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {

            objUsuarios = new clsUsuarios();
            objUsuarios.ConectarBD();


        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            usuarioN = txtUsuario.Text;
            contraseñaN = txtContraseña.Text;

            objUsuarios.ValidarUsuario(usuarioN, contraseñaN);


            if (txtUsuario.Text != "" && txtContraseña.Text != "")
            {
                if (objUsuarios.estadoConexion == "Usuario EXISTE")
                {
                    MessageBox.Show("Usuario Existente", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtContraseña.Text = "";
                    txtUsuario.Text = "";
                }
                else
                {
                    MessageBox.Show("Bienvenido", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    objUsuarios.Grabar(contraseñaN, usuarioN);
                    txtContraseña.Text = contraseñaN;
                    txtUsuario.Text = usuarioN;
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();

                }
           

            }
            if(txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                
                if(txtContraseña.Text == "" && txtUsuario.Text == "")
                {
                    MessageBox.Show("Complete los Datos para poder registrarse", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    usuarioN = "";
                    contraseñaN = "";
                }
                else
                {
                    if (txtUsuario.Text == "")
                    {
                        MessageBox.Show("Complete el Usuario para poder registrarse", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtUsuario.Focus();
                        usuarioN = "";

                    }
                    if (txtContraseña.Text == "")
                    {
                        MessageBox.Show("Complete la Contraseña para poder registrarse", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtContraseña.Focus();
                        contraseñaN = "";

                    }
                }
                
            }
          







        }

        private void frmRegistroUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        private void frmRegistroUsuario_KeyDown(object sender, KeyEventArgs e)
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
