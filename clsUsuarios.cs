using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Security.Policy;

namespace prySotoIE
{
    internal class clsUsuarios
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD; 
        OleDbDataReader lectorBD;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS;
       

        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BDUsuarios.accdb";
        public string estadoConexion = "";

        public string datosTabla = "";
        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        //-------- Funciones REGISTRO USUARIOS

        private DateTime tiempoDesbloqueo;
        private const int tiempoBloqueo = 5000;
        public bool banderaTimer = false;
        public int incorrecto = 0;
        public void Busqueda(string contraseña, string usuario)
        {

            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;  //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandText = "Usuarios"; //Que tabla traigo

            lectorBD = comandoBD.ExecuteReader();


            if (lectorBD.HasRows) //si tiene filas
            {
                bool find = false;
                bool validausuario = false;
                bool validacontra = false;
                
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {

                    if (lectorBD[2].ToString() == contraseña )
                    {
                        validacontra = true;
                    }
                    if (lectorBD[1].ToString() == usuario )
                    {
                        validausuario = true;
                    }

                    if (lectorBD[2].ToString() == contraseña && lectorBD[1].ToString() == usuario)
                    {
                        frmMain frmMain = new frmMain();
                        frmMain.Show();
                        frmUsuario.hide = true;
                        find = true;
                    }


                }
                if (find == false)
                {
                    if(incorrecto<2){
                        if (validausuario && validacontra == false)
                        {
                            MessageBox.Show("Contraseña incorrecta", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            frmUsuario.contraseña = "";
                            incorrecto++;
                        }
                        if (validausuario == false)
                        {
                            if (validacontra == false)
                            {
                                MessageBox.Show("Usuario No Registrado", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                frmUsuario.contraseña = "";
                                frmUsuario.usuario = "";
                                incorrecto++;


                            }
                            else
                            {
                                MessageBox.Show("Usuario incorrecto", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                frmUsuario.usuario = "";
                                frmUsuario.contraseña = "";
                                incorrecto++;


                            }
                        }                    
                    }
                    else
                    {
                        frmUsuario.contraseña = ""; 
                        frmUsuario.usuario = "";
                        banderaTimer = true;
                        MessageBox.Show("Datos Incorrectos", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ////hacer condicion para que desactive el boton
                        //tiempoDesbloqueo = DateTime.Now.AddMilliseconds(tiempoBloqueo);

                        //// Iniciar un temporizador para desbloquear el botón después de cierto tiempo
                        //btnIngresar.Enabled = false;
                        //Timer timer = new Timer(); //defino al qrido
                        //timer.Interval = tiempoBloqueo;
                        //timer.Tick += (s, args) =>
                        //{
                        //    btnIngresar.Enabled = true;
                        //    timer.Stop(); // corto el tempo
                        //};
                        //timer.Start(); incorrecto = 0;
                       

                    }


                }
            }
        }

        public void Grabar(string usuarioN, string contraseñaN)
        {
     
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuarios";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                    objDS = new DataSet();

                adaptadorBD.Fill(objDS, "Usuarios");

                DataTable objTabla = objDS.Tables["Usuarios"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Usuario"] = usuarioN;
         
                nuevoRegistro["Contraseña"] = contraseñaN;
                nuevoRegistro["Categoria"] = "Usuario";

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Usuarios");

            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        
    }

        public void ValidarUsuario(string usuarioN, string contraseñaN)
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuario";

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        if (lectorBD[1].ToString() == usuarioN && lectorBD[2].ToString() == contraseñaN)
                        {
                            estadoConexion = "Usuario EXISTE";
                        }
                    }
                }

            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }


    }
}
