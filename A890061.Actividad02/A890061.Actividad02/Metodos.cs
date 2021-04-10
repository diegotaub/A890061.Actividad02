using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad02
{
    static class Metodos
    {
        internal static int ValidarEntero(string ingreso)
        {
            int entero;
            while (!Int32.TryParse(ingreso, out entero))
            {
                Console.Write("Debe ingresar un número entero. Ingréselo nuevamente: \n");
                ingreso = Console.ReadLine();
                Console.WriteLine();
            }

            return entero;
        }
    }
}
