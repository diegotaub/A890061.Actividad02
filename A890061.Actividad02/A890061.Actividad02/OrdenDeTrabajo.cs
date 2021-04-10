using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad02
{
    class OrdenDeTrabajo
    {

        public OrdenDeTrabajo(int Identificador)
        {
            NroDeOrden = Identificador;
        }

        public int NroDeOrden { get; set; }

        static public void AgregarACola(int nroOrden, Queue<OrdenDeTrabajo> cola)
        {
            OrdenDeTrabajo O = new OrdenDeTrabajo(nroOrden);
            cola.Enqueue(O);
        }
    }
}

