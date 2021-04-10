using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Operador> ListaDeOperadores = new List<Operador>();
            Queue<OrdenDeTrabajo> ColaDeOrdenes = new Queue<OrdenDeTrabajo>();

            string respuesta;
            int repetido = 0;
            string[] posiblesRespuestas =
            {
                "A",
                "B",
                "C",
                "D"
            };
            while (true)
            {
                string continuar = "S";
                Console.WriteLine("Ingrese la opción deseada: \n");
                Console.WriteLine("A - Ingresar un operador");
                Console.WriteLine("B - Ingresar una orden de trabajo");
                Console.WriteLine("C - Asignar una orden a un operador");
                Console.WriteLine("D - Terminar y generar reporte");
                respuesta = Console.ReadLine();
                Console.WriteLine();

                while (!posiblesRespuestas.Contains(respuesta.ToUpper()))
                {
                    Console.Write("La respuesta no es una de las admitidas. Ingrésela de nuevo: ");
                    respuesta = Console.ReadLine();
                }

                while (respuesta.ToUpper() == "A" && continuar.ToUpper() == "S")
                {
                    Console.Write("Ingrese el número de operador o 'X' para ir para atrás: ");
                    string ingreso = Console.ReadLine();
                    Console.WriteLine();
                    if (ingreso.ToUpper() == "X")
                    {
                        break;
                    }
                    else
                    {
                        int nroValidado = Metodos.ValidarEntero(ingreso);
                        if (ListaDeOperadores.Count == 0)
                        {
                            Operador.AgregarALista(nroValidado, ListaDeOperadores);
                            Console.Write("¿Desea ingresar otro operador? (S/N): ");
                            continuar = Console.ReadLine();
                            Console.WriteLine();
                            while (continuar.ToUpper() != "S" && continuar.ToUpper() != "N")
                            {
                                Console.Write("Debe ingresar 'S' ó 'N': ");
                                continuar = Console.ReadLine();
                            }
                        }
                        else
                        {
                            foreach (Operador operador in ListaDeOperadores)
                            {
                                if ((nroValidado) == operador.NroDeOperador)
                                {
                                    Console.WriteLine("Ya existe un operador con ese número.\n");
                                    repetido = 1;
                                    break;
                                }
                                repetido = 0;

                            }
                            if (repetido == 0)
                            {
                                Operador.AgregarALista(nroValidado, ListaDeOperadores);
                                Console.Write("¿Desea ingresar otro operador? (S/N): ");
                                continuar = Console.ReadLine();
                                Console.WriteLine();
                                while (continuar.ToUpper() != "S" && continuar.ToUpper() != "N")
                                {
                                    Console.Write("Debe ingresar 'S' ó 'N': ");
                                    continuar = Console.ReadLine();
                                }

                            }

                        }

                    }

                }

                while (respuesta.ToUpper() == "B" && continuar.ToUpper() == "S")
                {
                    Console.Write("Ingrese el número de orden o 'X' para ir para atrás: ");
                    string ingreso = Console.ReadLine();
                    Console.WriteLine();
                    if (ingreso.ToUpper() == "X")
                    {
                        break;
                    }
                    else
                    {
                        int nroValidado = Metodos.ValidarEntero(ingreso);
                        if (ColaDeOrdenes.Count == 0)
                        {
                            OrdenDeTrabajo.AgregarACola(nroValidado, ColaDeOrdenes);
                            Console.Write("¿Desea ingresar otra orden? (S/N): ");
                            continuar = Console.ReadLine();
                            Console.WriteLine();
                            while (continuar.ToUpper() != "S" && continuar.ToUpper() != "N")
                            {
                                Console.Write("Debe ingresar 'S' ó 'N': ");
                                continuar = Console.ReadLine();
                            }
                        }
                        else
                        {
                            foreach (OrdenDeTrabajo orden in ColaDeOrdenes)
                            {
                                if ((nroValidado) == orden.NroDeOrden)
                                {
                                    Console.WriteLine("Ya existe una orden con ese número.\n");
                                    repetido = 1;
                                    break;
                                }
                                repetido = 0;

                            }
                            if (repetido == 0)
                            {
                                OrdenDeTrabajo.AgregarACola(nroValidado, ColaDeOrdenes);
                                Console.Write("¿Desea ingresar otra orden? (S/N): ");
                                continuar = Console.ReadLine();
                                Console.WriteLine();
                                while (continuar.ToUpper() != "S" && continuar.ToUpper() != "N")
                                {
                                    Console.Write("Debe ingresar 'S' ó 'N': ");
                                    continuar = Console.ReadLine();
                                }

                            }

                        }

                    }


                }

                while (respuesta.ToUpper() == "C" && continuar.ToUpper() == "S")
                {
                    if (ColaDeOrdenes.Count == 0)
                    {
                        Console.WriteLine("No hay órdenes en la cola. Para asignar una, debe ingresarla primero.\n");
                        break;
                    }
                    Console.Write("Ingrese el número de operador o 'X' para ir para atrás: ");
                    string ingreso = Console.ReadLine();
                    Console.WriteLine();
                    if (ingreso.ToUpper() == "X")
                    {
                        break;
                    }

                    Operador O = new Operador();
                    int nroValidado = Metodos.ValidarEntero(ingreso);
                    int encontrado = 0;

                    foreach (Operador operador in ListaDeOperadores)
                    {
                        if (operador.NroDeOperador == nroValidado)
                        {
                            O = operador;
                            encontrado++;
                            break;
                        }
                    }

                    if (encontrado == 0)
                    {
                        Console.WriteLine("No existe un operador con ese número identificador.\n");
                        break;
                    }

                    Operador.AsignarOrden(O, ColaDeOrdenes);

                    Console.Write("¿Desea asignar otra orden? (S/N): ");
                    continuar = Console.ReadLine();
                    Console.WriteLine();
                    while (continuar.ToUpper() != "S" && continuar.ToUpper() != "N")
                    {
                        Console.Write("Debe ingresar 'S' ó 'N': ");
                        continuar = Console.ReadLine();
                    }

                }

                if (respuesta.ToUpper() == "D")
                {
                    Console.WriteLine("Órdenes cumplidas por operador:\n");
                    foreach (Operador operador in ListaDeOperadores)
                    {
                        Console.WriteLine($"Operador n°{operador.NroDeOperador}: {operador.OrdenesTerminadas}");
                    }

                    Console.WriteLine("");

                    Console.WriteLine("Órdenes pendientes de asignar:\n");
                    foreach (OrdenDeTrabajo orden in ColaDeOrdenes)
                    {
                        Console.WriteLine($"Orden n°{orden.NroDeOrden}");
                    }

                    break;
                }
            }

            Console.ReadKey();
        }
    }

}