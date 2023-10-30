using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace prySotoIE
{
    internal class clsUsuarios
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD; //indica que quiero traer de las tablas
        OleDbDataReader lectorBD;


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
                estadoConexion = "Conectado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                estadoConexion = "Error: " + ex.Message;


            }

        }


        //-------- Funciones REGISTRO USUARIOS

        int incorrecto = 0;
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

                        }
                        if (validausuario == false)
                        {
                            if (validacontra == false)
                            {
                                MessageBox.Show("Usuario No Registrados", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                frmUsuario.contraseña = "";
                                frmUsuario.usuario = "";
                               


                            }
                            else
                            {
                                MessageBox.Show("Usuario incorrecto", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                frmUsuario.usuario = "";
                                frmUsuario.contraseña = "";



                            }
                        }                    
                        incorrecto++;
                       
                    }
                    else
                    {
                        frmUsuario.contraseña = ""; 
                        frmUsuario.usuario = "";
                        MessageBox.Show("Datos Incorrectos", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        incorrecto = 0;                      

                    }


                }
            }
        }

        public void Grabar(string usuarioN, string contraseñaN)
        {
            string insertQuery = "INSERT INTO Usuarios (Usuario, Contraseña) VALUES (@Usuario, @Contraseña)";

            using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, conexionBD))
            {
                insertCommand.Parameters.AddWithValue("@Usuario", usuarioN);
                insertCommand.Parameters.AddWithValue("@Contraseña", contraseñaN);

                int rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Usuario: " + usuarioN + " registrado con éxito.");
                    frmUsuario.contraseña = "";
                    frmUsuario.usuario = "";
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el usuario: " + usuarioN + ".");
                    frmUsuario.contraseña = "";
                    frmUsuario.usuario = "";
                }
            }

            //comandoBD = new OleDbCommand();
            


        }
    }
}
