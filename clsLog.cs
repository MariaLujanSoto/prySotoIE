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
    internal class clsLog
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD; //indica que quiero traer de las tablas
        OleDbDataReader lectorBD;

        //OleDbConnection objCNN = new OleDbConnection();
        //OleDbCommand objcmd = new OleDbCommand();
        //OleDbCommand objcmt = new OleDbCommand();
        //OleDbDataReader objDR;



        //Abrir Acc
        //public void AbrirBD()
        //{

        //    try
        //    {
        //        string strcnn = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BDUsuarios.accdb";
        //        objCNN.ConnectionString = strcnn;
        //        objCNN.Open();
        //        objcmd.Connection = objCNN;
        //        objcmd.CommandType = CommandType.TableDirect;
        //        objcmd.CommandText = "Usuarios";
        //        objcmt.CommandText = "Contraseña";
        //        objDR = objcmd.ExecuteReader();
        //        objDR = objcmt.ExecuteReader(); ////


        //        if (objDR.HasRows)
        //        {
        //            string datos = "";
        //            while (objDR.Read())
        //            {
        //                datos += objDR.GetInt32(0).ToString() + ", " + objDR.GetString(1) + "\r\n";

        //            }

        //            MessageBox.Show(datos, "Tabla de Usuarios ");
        //        }

        //        objCNN.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }


        //leer BD

        //Validar datos

        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BDUsuarios.accdb";
        public string estadoConexion = "";

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
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;  //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandText = "Usuarios"; //Que tabla traigo

            lectorBD = comandoBD.ExecuteReader();

        }


    }
}
