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
                        //GestionDeVehiculos(informacionDECLIentes, informacionDeGestionDeVehículos);
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
            int opcionClientes = 0;
            int CantidadDeClientes = informacionDeClientes_1.GetLength(1);
            string[,] infoClientesOriginal = informacionDeClientes_1;



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
                        informacionDeClientes_1 = LogicaNuevaInfo(infoClientesOriginal, informacionDeClientes_1);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        MostrarMatriz(informacionDeClientes_1);
                        //GestionDeVehiculos();
                        break;

                    case 3:
                        Console.Clear();
                        //GestionDeServiciosDeMantenimiento();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (opcionClientes != 4);

            return informacionDeClientes_1;
        }

        static string[] LogicaDeRegistracion(string[] nuevoCliente)
        {
            return nuevoCliente;
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

        static string[,] LogicaBorrarInfo(string[,] matrizOriginal, string[,] matrizDada)
        {
            int opcion = 0;
            MostrarMatriz(matrizOriginal);

            Console.WriteLine();
            Console.Write("Elige la informacion que deseas editar o borrar: ");
            opcion = int.Parse(Console.ReadLine());
            return null;
        }

        static void MostrarMatriz(string[,] matrizElegida)
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
    }
}

