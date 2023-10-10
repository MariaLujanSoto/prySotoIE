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
        OleDbConnection aperturaBD;
        OleDbConnection objCNN = new OleDbConnection();
        OleDbCommand objcmd = new OleDbCommand();
        OleDbCommand objcmt = new OleDbCommand();
        OleDbDataReader objDR;

        //Abrir Acc
        public void AbrirBD()
        {

            try
            {
                string strcnn = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BDUsuarios.accdb";
                objCNN.ConnectionString = strcnn;
                objCNN.Open();
                objcmd.Connection = objCNN;
                objcmd.CommandType = CommandType.TableDirect;
                objcmd.CommandText = "Usuarios";
                objcmt.CommandText = "Contraseña";
                objDR = objcmd.ExecuteReader();
                objDR = objcmt.ExecuteReader(); ////


                if (objDR.HasRows)
                {
                    string datos = "";
                    while (objDR.Read())
                    {
                        datos += objDR.GetInt32(0).ToString() + ", " + objDR.GetString(1) + "\r\n";

                    }

                    MessageBox.Show(datos, "Tabla de Usuarios ");
                }

                objCNN.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
            //leer BD

            //Validar datos

        }
    }
}
