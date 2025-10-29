using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto_final_FP_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            int opcion = 0;
            string[,] informacionDeClientes_0 = new string[1, 3]; //La primera fila es la categoría de la columna
            informacionDeClientes_0[0, 0] = "//--Nombre--//";
            informacionDeClientes_0[0, 1] = "//--Cedula--//";
            informacionDeClientes_0[0, 2] = "//--Telefono--//";

            string[,] informacionVehículos_0 = new string[1, 4]; //La primera fila es la categoría de la columna
            informacionVehículos_0[0, 0] = "//--Marca--//";
            informacionVehículos_0[0, 1] = "//--Modelo--//";
            informacionVehículos_0[0, 2] = "//--Placa--//";
            informacionVehículos_0[0, 3] = "//--Año--//";

            //string[,] informacionmantenimiento_0 = new string[1, 4]; //la primera fila es la categoría de la columna
            //informacionmantenimiento_0[0, 0] = "//--marca--//";
            //informacionmantenimiento_0[0, 1] = "//--modelo--//";
            //informacionmantenimiento_0[0, 2] = "//--placa--//";
            //informacionmantenimiento_0[0, 3] = "//--año--//";

            do
            {
                Console.WriteLine("Digita el numero de la opción para elegirla.");
                Console.WriteLine("1. Gestión de clientes.");
                Console.WriteLine("2. Gestión de vehículos.");
                Console.WriteLine("3. Gestión de servicios de mantenimiento.");
                Console.WriteLine("4. Salir del programa.");
                Console.WriteLine();
                Console.Write("Elige: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion < 1 || opcion > 4)
                {
                    do
                    {
                        Console.Write("Opción no válida. Por favor, elige una opción entre 1 y 4: ");
                        opcion = Convert.ToInt32(Console.ReadLine());
                    } while (opcion < 1 || opcion > 4);
                }

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        informacionDeClientes_0 = GestionDeClientes(informacionDeClientes_0);
                        Console.WriteLine("Saliste de la gestión de clientes");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Clear();
                        informacionVehículos_0 = GestionDeVehiculos(informacionVehículos_0, informacionDeClientes_0);
                        Console.WriteLine("Saliste de la gestión de vehículos");
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        //GestionDeServiciosDeMantenimiento(InformacionDeGestionDeVehículos, InformacionDeServicios);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ha finalizado el programa");
                        break;
                }

            } while (opcion != 4);
        }

        static string[,] GestionDeClientes(string[,] informacionDeClientes_1)
        {
            int desdeClientes = 1;
            int opcionClientes = 0;

            do
            {
                Console.WriteLine("Digita el numero de la opción para elegirla.");
                Console.WriteLine("1. Registrar un nuevo cliente.");
                Console.WriteLine("2. Ver lista de todos los clientes.");
                Console.WriteLine("3. Editar información de un cliente.");
                Console.WriteLine("4. Salir al menú principal.");
                Console.WriteLine();
                Console.Write("Elige: ");
                opcionClientes = int.Parse(Console.ReadLine());

                if (opcionClientes < 1 || opcionClientes > 4)
                {
                    do
                    {
                        Console.Write("Opción no válida. Por favor, elige una opción entre 1 y 4: ");
                        opcionClientes = Convert.ToInt32(Console.ReadLine());
                    } while (opcionClientes < 1 || opcionClientes > 4);
                }

                switch (opcionClientes)
                {
                    case 1:
                        if(informacionDeClientes_1.GetLength(0) > 16) //la primera fila no cuenta, por eso es 16
                        {
                            Console.WriteLine("Se ha llegado al a máxima cantidad de clientes, lo cual es 15.");
                        }
                        else
                        {
                            informacionDeClientes_1 = LogicaNuevaInfo(informacionDeClientes_1, informacionDeClientes_1);
                        }
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        MostrarMatriz(informacionDeClientes_1);
                        //GestionDeVehiculos();
                        break;

                    case 3:
                        Console.Clear();
                        informacionDeClientes_1 = LogicaEditarInfo(informacionDeClientes_1, informacionDeClientes_1, desdeClientes);
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (opcionClientes != 4);

            return informacionDeClientes_1;
        }

        static string[,] LogicaNuevaInfo(string[,] matrizOriginal, string[,] matrizDada)
        {
            matrizDada = new string[matrizOriginal.GetLength(0) + 1, matrizOriginal.GetLength(1)];

            for (int i = 0; i < matrizOriginal.GetLength(0); i++)
            {
                for (int j = 0; j < matrizOriginal.GetLength(1); j++)
                {
                    matrizDada[i, j] = matrizOriginal[i, j];
                }
            }

            for (int i = 0; i < matrizDada.GetLength(1); i++)
            {
                Console.Write($"Ingresa la nueva información en {matrizDada[0, i]}: ");
                matrizDada[matrizDada.GetLength(0) - 1, i] = Console.ReadLine();
            }
            return matrizDada;
        }

        static string[,] LogicaEditarInfo(string[,] matrizOriginal, string[,] matrizDada, int desdeDonde)
        {            
            int eleccionInfo = 0;
            int opcion = 0;
            Console.Clear();
            MostrarMatriz(matrizDada);
            Console.WriteLine();//separa las lineas en consola para que sean mas legible

            if(matrizDada.GetLength(0) > 1) //revisa en primer plano si hay informacion editable
            {
                if(desdeDonde == 1)
                {
                    Console.Write("Elige la fila de la informacion que deseas editar o borrar: ");
                    eleccionInfo = int.Parse(Console.ReadLine());
                    while (eleccionInfo > (matrizOriginal.GetLength(0) - 1) || eleccionInfo < 1) //Verifica si se puso un rango correcto
                    {
                        Console.WriteLine();
                        Console.Write($"Elige en un rango de 1 a {matrizOriginal.GetLength(0) - 1}");
                        eleccionInfo = int.Parse(Console.ReadLine());
                    }
                }
                else if (desdeDonde == 2)
                {
                    string comparadorDePlaca = "";
                    do
                    {
                        Console.Write("Elige la placa del carro. la informacion del carro la puedes editar o borrar: ");
                        comparadorDePlaca = Console.ReadLine();
                        for (int i = 0; i < matrizDada.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrizDada.GetLength(1); j++)
                            {
                                if(comparadorDePlaca == matrizDada[i, j] && i != 0)
                                {
                                    eleccionInfo = i;
                                }
                            }
                        }
                    } while (eleccionInfo == 0);
                }
                    Console.WriteLine();//separa las lineas en consola para que sean mas legibles

                Console.Write("Quieres borrar o editarla? elige | '1' para borrar | '2' para editar: ");
                opcion = int.Parse(Console.ReadLine());
                while (opcion < 1 || opcion > 2) //Verifica si se puso un rango correcto
                {
                    Console.WriteLine();
                    Console.Write($"Elige 1 o 2: ");
                    eleccionInfo = int.Parse(Console.ReadLine());
                }

                Console.WriteLine();//separa las lineas en consola para que sean mas legibles


                if (opcion == 1)
                {
                    matrizDada = new string[matrizDada.GetLength(0) - 1, matrizDada.GetLength(1)]; //estoy creando una matriz vacia con una fila menos de igual tamaño que la matriz dada
                    bool borroDetectado = false; //Una condicion para el for loop siguiente

                    for (int i = 0; i < matrizDada.GetLength(0); i++) //Acá asignara todos los valores orignales y borrará la fila elegida. Todo se mueve un espacio para arriba.
                    {
                        for (int j = 0; j < matrizDada.GetLength(1); j++)
                        {
                            if (i == eleccionInfo)//cuando se llega al a fila de borro.
                            {
                                borroDetectado = true;
                            }

                            if (i != eleccionInfo && borroDetectado == false) //asigna lso valores normalmente hasta la fila borrada, la cual salta a el otro if
                            {
                                matrizDada[i, j] = matrizOriginal[i, j];
                            }

                            if (borroDetectado == true)//Asigna al espacio borrado la fila que está adelante continuamente cuando se llega a la fila de borro.
                            {
                                matrizDada[i, j] = matrizOriginal[i + 1, j];
                            }
                        }
                    }
                }
                else if (opcion == 2 && desdeDonde == 1) 
                {
                    for (int j = 0; j < matrizDada.GetLength(1); j++)
                    {
                        Console.Write($"Cambia {matrizDada[0, j]}: ");
                        matrizDada[eleccionInfo,j] = Console.ReadLine();
                    }
                }
                else if (opcion == 2 && desdeDonde == 2)
                {
                    for (int j = 0; j < matrizDada.GetLength(1); j++)
                    {
                        if(j != 2)
                        {
                            Console.Write($"Cambia {matrizDada[0, j]}: ");
                            matrizDada[eleccionInfo, j] = Console.ReadLine();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay informacion para editar");
            }

            Console.Clear();
            return matrizDada;
        }

        static void MostrarMatriz(string[,] matrizElegida)
        {
            if(matrizElegida.GetLength(0) > 1)
            {
                for (int i = 0; i < matrizElegida.GetLength(0); i++)
                {
                    if (i != 0)
                    {
                        Console.Write(i + ". ");
                    }
                    for (int j = 0; j < matrizElegida.GetLength(1); j++)
                    {
                        if (i == 0)
                        {
                            Console.Write($"|      {matrizElegida[i, j]}      |");
                        }
                        else
                        {
                            Console.Write($"|       {matrizElegida[i, j]}         |");
                        }

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay nada registrado");
            }
        }

        static void MostrarMatrizAsignada(string[,] matrizElegida)
        {
            if(matrizElegida.GetLength(0) > 1)
            {
                for (int i = 0; i < matrizElegida.GetLength(0); i++)
                {
                    if (i != 0)
                    {
                        Console.Write(i + ". ");
                    }
                    for (int j = 0; j < matrizElegida.GetLength(1); j++)
                    {
                        if (i == 0)
                        {
                            Console.Write($"|      {matrizElegida[i, j]}      |");
                        }
                        else
                        {
                            Console.Write($"|       {matrizElegida[i, j]}         |");
                        }

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay nada registrado");
            }
        }

        static string[,] AsignarInfoExterior(string[,] infoPadre, string[,] infoHijo, string[,] infoAsignada, int desdeDonde)
        {
            string[,] infoAsignadaOriginal = infoAsignada;
            infoAsignada = new string[infoAsignada.GetLength(0) + 1, infoAsignada.GetLength(1)];
            int eleccionFila1 = 0;
            int eleccionFila2 = 0;

            if (infoPadre.GetLength(0) < 2 || infoPadre.GetLength(0) < 2)
            {
                if (desdeDonde == 2)
                {
                    MostrarMatriz(infoPadre);
                    Console.WriteLine();
                    Console.Write("Elige la fila del cliente al que le quieres asignar un vehículo: ");
                    eleccionFila1 = int.Parse(Console.ReadLine());

                    Console.Clear();

                    MostrarMatriz(infoHijo);
                    Console.WriteLine();
                    Console.Write("Elige el vehículo a asignar: ");
                    eleccionFila2 = int.Parse(Console.ReadLine());

                    for (int i = 0; i < infoAsignadaOriginal.GetLength(0); i++)
                    {
                        for (int j = 0; j < infoAsignadaOriginal.GetLength(1); j++)
                        {
                            infoAsignada[i, j] = infoAsignadaOriginal[i, j];
                        }
                    }

                    //infoAsignada
                }
            }
            else
            {
                Console.WriteLine("Hay registracion inexistente en uno de los tipos de informacion. Registra todo primero.");
                Console.WriteLine("");
            }
                return infoAsignada;
        }

        static string[,] GestionDeVehiculos(string[,] infoVehiculos, string[,] infoClientes)
        {
            int desdeVehículos = 2;
            int opcionVehiculos = 0;
            string[,] infoAsignadaVehiculosAClientes = new string[1, 4];

            do
            {
                Console.WriteLine("Digita el numero de la opción para elegirla.");
                Console.WriteLine("1. Registrar un nuevo vehículo.");
                Console.WriteLine("2. Ver lista de vehículos registrados.");
                Console.WriteLine("3. Editar información de un vehículo.");
                Console.WriteLine("4. Asignar vehículo a un cliente.");
                Console.WriteLine("5. Ver vehículos de un cliente específico.");
                Console.WriteLine("6. Salir de Gestión de vehículos.");
                Console.WriteLine();
                Console.Write("Elige: ");
                opcionVehiculos = int.Parse(Console.ReadLine());

                if (opcionVehiculos < 1 || opcionVehiculos > 6)
                {
                    do
                    {
                        Console.Write("Opción no válida. Por favor, elige una opción entre 1 y 6: ");
                        opcionVehiculos = Convert.ToInt32(Console.ReadLine());
                    } while (opcionVehiculos < 1 || opcionVehiculos > 6);
                }

                switch (opcionVehiculos)
                {
                    case 1:
                        infoVehiculos = LogicaNuevaInfo(infoVehiculos, infoVehiculos);
                        Console.Clear();
                        break;

                    case 2:
                        //mostrar lista de vehículos
                        Console.Clear();
                        MostrarMatriz(infoVehiculos);
                        Console.WriteLine();
                        break;

                    case 3:
                        MostrarMatriz(infoVehiculos);
                        infoVehiculos = LogicaEditarInfo(infoVehiculos, infoVehiculos, desdeVehículos);
                        Console.Clear();
                        break;

                    case 4:
                        break;

                    case 5:
                        //ver vehículos de un cliente específico
                        break;

                    case 6:
                        //salir
                        Console.Clear();
                        break;
                }

            } while (opcionVehiculos != 6);

            return infoVehiculos;
        }
    }
}

