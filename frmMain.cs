using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Security.Cryptography;

namespace prySotoIE
{

    public partial class frmMain : Form
    {
        private frmCargarProveedor cargarProveedor;
        public frmMain()
        {
            InitializeComponent();
            PopulateTreeView();
            cargarProveedor = new frmCargarProveedor(); // Crear una nueva instancia


        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmCargarProveedor cargarProveedor = new frmCargarProveedor(); // Crear una nueva instancia

        }
        private void PopulateTreeView()
        {
            TreeNode rootNode;
            // ver como sacar el path de donde esta la carpeta y colocarla aca

            DirectoryInfo info = new DirectoryInfo("../../Resources/Proveedores");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
          private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        void treeView1_NodeMouseDoubleClick(object sender,
    TreeNodeMouseClickEventArgs e)
        {
          
        }


        string leerLinea;
        string[] separarDatos;
        bool datosCargados;
        private void uikl_AfterSelect(object sender, TreeViewEventArgs e)
        {
            

        }
        bool grillaCargada = false;

        public void CargarDatosDesdeCSV()

        {
            {
                StreamReader sr = new StreamReader("../../Resources/Proveedores/Aseguradoras.csv");

                leerLinea = sr.ReadLine();
                separarDatos = leerLinea.Split(';');
                datosCargados = false;

                for (int indice = 0; indice < separarDatos.Length; indice++)
                {
                    grilla.Columns.Add(separarDatos[indice], separarDatos[indice]);
                }

                while (sr.EndOfStream == false)
                {
                    leerLinea = sr.ReadLine();
                    separarDatos = leerLinea.Split(';');
                    grilla.Rows.Add(separarDatos);

                }

                sr.Close();
            }
           
            
            
        }
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


 

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {

        }

        private void cargarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void btInicio_Click(object sender, EventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = true;
            btnEliminar.Visible = true;
            btnCargar.Visible = true;
            btnEditar.Visible= true;
            grilla.Visible = true;
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            splitContainer1.Visible = false;
            btnEliminar.Visible = false;
            btnCargar.Visible = false;
            btnEditar.Visible = false;
            grilla.Visible = false;

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      

        public void treeView1_NodeMouseDoubleClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {

            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

         



        }

        string Entidad;

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grilla.SelectedRows.Count > 0)
            {
                int rowIndex = grilla.SelectedRows[0].Index;
                string valorAEliminar = grilla.Rows[rowIndex].Cells[0].Value.ToString();

                // Obtiene la ruta del archivo CSV dentro de "Resources/Proveedores"
                string rutaArchivoCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources", "Proveedores", "Aseguradoras.csv");

                // Lee el contenido del archivo CSV en una lista
                List<string> lineas = File.ReadAllLines(rutaArchivoCSV).ToList();

                // Encuentra y elimina la línea que contiene el valor a eliminar
                lineas.RemoveAll(linea => linea.Contains(valorAEliminar));

                // Sobrescribe el archivo CSV con los datos actualizados
                File.WriteAllLines(rutaArchivoCSV, lineas);

                // Finalmente, elimina la fila de la grilla
                grilla.Rows.RemoveAt(rowIndex);
            }
        }

        public static int pos = 0;

        public void grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }


        public void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }



        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!datosCargados  && listView1.SelectedItems[0].Text == "Aseguradoras.csv")
            {
                CargarDatosDesdeCSV();
                datosCargados = true;
            }
            else
            {
               
                    MessageBox.Show("No hay datos disponibles para cargar");
                
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmCargarProveedor frmCargarProveedor = new frmCargarProveedor();
            frmCargarProveedor.Show();
            this.Hide();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void grilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pos = grilla.CurrentRow.Index;

            cargarProveedor.txtNumeroProveedor.Text = grilla[0,pos].Value.ToString();
            cargarProveedor.txtEntidad.Text = grilla[1, pos].Value.ToString();
            cargarProveedor.txtApertura.Text = grilla[2, pos].Value.ToString();
            cargarProveedor.txtNExp.Text = grilla[3, pos].Value.ToString();
            cargarProveedor.txtJurisdiccion.Text = grilla[4, pos].Value.ToString();
            cargarProveedor.txtDireccion.Text = grilla[5, pos].Value.ToString();
            cargarProveedor.txtLiquidadorResp.Text = grilla[6, pos].Value.ToString();

            cargarProveedor.Show();

        }
    }
}


