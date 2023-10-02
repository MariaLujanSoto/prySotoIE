using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prySotoIE
{
    internal class clsArchivo
    {
        public void Grabar(string datos)
        {
            StreamWriter AD = new StreamWriter("../../Resources/Proveedores/Aseguradoras.csv", true);
            AD.WriteLine(datos);
            AD.Close();


        }
    }
}
