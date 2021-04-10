using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad02
{
    class Operador
    {
        public Operador()
        {

        }
        public Operador(int Identificador)
        {
            NroDeOperador = Identificador;
        }

        public int NroDeOperador { get; set; }

        public int OrdenesTerminadas { get; set; }

        public OrdenDeTrabajo OrdenAsignada { get; set; }

        static public void AgregarALista(int nroOperador, List<Operador> lista)
        {
            Operador O = new Operador(nroOperador);
            lista.Add(O);

        }

        static public void AsignarOrden(Operador operador, Queue<OrdenDeTrabajo> colaOrdenes)
        {

            if (operador.OrdenAsignada == null)
            {
                operador.OrdenAsignada = colaOrdenes.Dequeue();
            }
            else
            {
                operador.OrdenAsignada = colaOrdenes.Dequeue();
                operador.OrdenesTerminadas++;
            }


        }
    }
}

