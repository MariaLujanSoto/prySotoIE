using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;

namespace prySotoIE
{
    
    internal class clsLogs
    {

        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS;

        public string estadoConexion;


        public clsLogs()
        {
            try
            {
                string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BDUsuarios.accdb";

                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();

                objDS = new DataSet();

                estadoConexion = "Conectado";
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }

        public void RegistroLogInicioSesion()
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio exitoso";

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }

        }

        public void ValidarUsuario(string nombreUser, string passUser)
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
                        if (lectorBD[1].ToString() == nombreUser && lectorBD[2].ToString() == passUser)
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
    //permitir l vista solo si estan registrados como administradores en el campo categoria


}
