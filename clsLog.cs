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

        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BDUsurios.accdb";

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
                MessageBox.Show( ex.Message);

            }

        }
        public void Busqueda(int contraseña)
        {

            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;  //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandText = "BDUsuarios"; //Que tabla traigo

            lectorBD = comandoBD.ExecuteReader(); //abre la tabla y muestra por renglon

           int incorrecto = 0;

            if (lectorBD.HasRows) //SI TIENE FILAS
            {
                bool Find = false;
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {
                    if (int.Parse(lectorBD[2].ToString()) == contraseña)
                    {
                        frmMain frmMain = new frmMain();
                        frmMain.Show();

                        Find = true;
                        break;
                    }

                }
                if (Find == false)
                {

                    MessageBox.Show("NO Existente", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }


    }
}
