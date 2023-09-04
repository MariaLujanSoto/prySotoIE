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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAbrirCarpetas_Click(object sender, EventArgs e)
        {
            frmNavegar frmNavegar = new frmNavegar();
            frmNavegar.Show();
            this.Hide();
        }
    }
}
