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

                objDS = new DataSet();

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = inicio;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }

        }
        string inicio= "";
        public void ValidarUsuario(string usuario, string contraseña)
        {
            try
            {
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuarios";

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        if (lectorBD[1].ToString() == usuario && lectorBD[2].ToString() == contraseña)
                        {
                            inicio = "Inicio Exitoso";
                        }
                        else
                        {
                            inicio = "Inicio Fallido";

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
