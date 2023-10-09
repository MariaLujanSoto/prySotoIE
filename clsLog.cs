using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace prySotoIE
{
    internal class clsLog
    {
        OleDbConnection aperturaBD;
       //Abrir Acc
       public void AbrirBD()
        {

            try
            {
                aperturaBD = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = ../../ Resources/Proveedores/BDUsuarios.accdb");
                aperturaBD.Open();
            }
            catch(Exception ex)
            {
                //mserror
            }
            
        }
        //leer BD

        //Validar datos

    }
}
