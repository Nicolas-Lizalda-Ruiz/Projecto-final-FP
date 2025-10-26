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

        static string[,] GestionDeVehiculos(string[,] infoVehiculos, string[,] infoClientes)
        {
            int opcionVehiculos = 0;

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
                        if (infoVehiculos.GetLength(0) - 1 >= 20)
                        {
                            Console.WriteLine("No se pueden registrar más vehículos (límite de 20).");
                        }
                        else
                        {
                            if (infoVehiculos.GetLength(1) == 4)
                            {
                                infoVehiculos = LogicaNuevaInfo(infoVehiculos, infoVehiculos);
                            }
                            else if (infoVehiculos.GetLength(1) == 5)
                            {
                                int filas = infoVehiculos.GetLength(0);
                                int columnas = infoVehiculos.GetLength(1);
                                string[,] nuevaMatriz = new string[filas + 1, columnas];
                                //copiar datos existentes
                                for (int i = 0; i < filas; i++)
                                    for (int j = 0; j < columnas; j++)
                                        nuevaMatriz[i, j] = infoVehiculos[i, j];
                                //pedir datos para las primeras 4 columnas
                                for (int j = 0; j < 4; j++)
                                {
                                    Console.Write($"Ingresa la nueva información en {nuevaMatriz[0, j]}: ");
                                    nuevaMatriz[filas, j] = Console.ReadLine();
                                }
                                //columna de cédula de cliente 
                                nuevaMatriz[filas, 4] = "";
                                infoVehiculos = nuevaMatriz;
                            }
                        }
                        Console.Clear();
                        break;

                    case 2:
                        //mostrar lista de vehículos
                        Console.Clear();
                        MostrarMatriz(infoVehiculos);
                        break;

                    case 3:
                        //editar vehículo por placa
                        Console.Clear();
                        if (infoVehiculos.GetLength(0) > 1)
                        {
                            Console.Write("Ingrese la placa del vehículo a editar: ");
                            string placaBuscar = Console.ReadLine();
                            int fila = -1;
                            for (int i = 1; i < infoVehiculos.GetLength(0); i++)
                            {
                                if (infoVehiculos[i, 2] == placaBuscar)
                                {
                                    fila = i;
                                    break;
                                }
                            }
                            if (fila == -1)
                            {
                                Console.WriteLine("Vehículo no encontrado.");
                            }
                            else
                            {
                                Console.Write($"Marca actual ({infoVehiculos[fila, 0]}), nueva marca: ");
                                string nuevaMarca = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevaMarca))
                                    infoVehiculos[fila, 0] = nuevaMarca;

                                Console.Write($"Modelo actual ({infoVehiculos[fila, 1]}), nuevo modelo: ");
                                string nuevoModelo = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoModelo))
                                    infoVehiculos[fila, 1] = nuevoModelo;

                                Console.Write($"Año actual ({infoVehiculos[fila, 3]}), nuevo año: ");
                                string nuevoAnio = Console.ReadLine();
                                if (!string.IsNullOrEmpty(nuevoAnio))
                                    infoVehiculos[fila, 3] = nuevoAnio;

                                Console.WriteLine("Información actualizada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay vehículos registrados para editar.");
                        }
                        break;

                    case 4:
                        //asignar vehículo a cliente
                        Console.Clear();
                        //si no existe columna para cliente la agrega
                        if (infoVehiculos.GetLength(1) == 4)
                        {
                            int filas = infoVehiculos.GetLength(0);
                            string[,] nuevaMatriz2 = new string[filas, 5];

                            for (int i = 0; i < filas; i++)
                                for (int j = 0; j < 4; j++)
                                    nuevaMatriz2[i, j] = infoVehiculos[i, j];
                            nuevaMatriz2[0, 4] = "//--CedulaCliente--//";
                            for (int i = 1; i < filas; i++)
                                nuevaMatriz2[i, 4] = "";
                            infoVehiculos = nuevaMatriz2;
                        }
                        if (infoVehiculos.GetLength(0) > 1)
                        {
                            Console.Write("Ingrese la placa del vehículo a asignar: ");
                            string placaAsignar = Console.ReadLine();
                            int filaVeh = -1;
                            for (int i = 1; i < infoVehiculos.GetLength(0); i++)
                            {
                                if (infoVehiculos[i, 2] == placaAsignar)
                                {
                                    filaVeh = i;
                                    break;
                                }
                            }
                            if (filaVeh == -1)
                            {
                                Console.WriteLine("Vehículo no encontrado.");
                            }
                            else
                            {
                                Console.Write("Ingrese la cédula del cliente: ");
                                string cedulaCliente = Console.ReadLine();
                                int filaCliente = -1;
                                for (int i = 1; i < infoClientes.GetLength(0); i++)
                                {
                                    if (infoClientes[i, 1] == cedulaCliente)
                                    {
                                        filaCliente = i;
                                        break;
                                    }
                                }
                                if (filaCliente == -1)
                                {
                                    Console.WriteLine("Cliente no encontrado.");
                                }
                                else
                                {
                                    infoVehiculos[filaVeh, 4] = infoClientes[filaCliente, 1];
                                    Console.WriteLine("Vehículo asignado exitosamente.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay vehículos registrados.");
                        }
                        break;

                    case 5:
                        //ver vehículos de un cliente específico
                        Console.Clear();
                        Console.Write("Ingrese la cédula del cliente: ");
                        string cedulaBuscar = Console.ReadLine();
                        int filaCli = -1;
                        for (int i = 1; i < infoClientes.GetLength(0); i++)
                        {
                            if (infoClientes[i, 1] == cedulaBuscar)
                            {
                                filaCli = i;
                                break;
                            }
                        }
                        if (filaCli == -1)
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        else
                        {
                            bool tieneVehiculos = false;
                            for (int i = 1; i < infoVehiculos.GetLength(0); i++)
                            {
                                if (infoVehiculos.GetLength(1) == 5 && infoVehiculos[i, 4] == cedulaBuscar)
                                {
                                    if (!tieneVehiculos)
                                    {
                                        Console.WriteLine("Vehículos del cliente:");
                                    }
                                    tieneVehiculos = true;
                                    Console.WriteLine($"Marca: {infoVehiculos[i, 0]}, Modelo: {infoVehiculos[i, 1]}, Placa: {infoVehiculos[i, 2]}, Año: {infoVehiculos[i, 3]}");
                                }
                            }
                            if (!tieneVehiculos)
                            {
                                Console.WriteLine("No se encontraron vehículos para este cliente.");
                            }
                        }
                        break;

                    default:
                        //salir
                        Console.Clear();
                        break;
                }

            } while (opcionVehiculos != 6);

            return infoVehiculos;
        }
    }
}

