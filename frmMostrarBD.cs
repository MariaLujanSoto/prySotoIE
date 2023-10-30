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
    public partial class frmMostrarBD : Form
    {
        clsLogs objBaseDatos;

        public frmMostrarBD()
        {
            InitializeComponent();
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
    }
}