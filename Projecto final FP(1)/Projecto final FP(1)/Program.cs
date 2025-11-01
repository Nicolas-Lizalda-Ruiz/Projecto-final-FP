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
                        Console.Clear();
                        if (informacionDeClientes_1.GetLength(0) > 16) //la primera fila no cuenta, por eso es 16
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
                        MostrarMatriz(informacionDeClientes_1, desdeClientes);
                        //GestionDeVehiculos();
                        break;

                    case 3:
                        Console.Clear();
                        informacionDeClientes_1 = LogicaEditarInfo(informacionDeClientes_1, informacionDeClientes_1, desdeClientes);
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (opcionClientes != 4);

            return informacionDeClientes_1;
        }

        static string[,] GestionDeVehiculos(string[,] infoVehiculos, string[,] infoClientes)
        {
            int desdeVehículos = 2;
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
                        Console.Clear();
                        infoVehiculos = LogicaNuevaInfo(infoVehiculos, infoVehiculos);
                        Console.Clear();
                        break;

                    case 2:
                        //mostrar lista de vehículos
                        Console.Clear();
                        MostrarMatriz(infoVehiculos, desdeVehículos);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        MostrarMatriz(infoVehiculos, desdeVehículos);
                        infoVehiculos = LogicaEditarInfo(infoVehiculos, infoVehiculos, desdeVehículos);
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        infoVehiculos = AsignarInfoVehículos(infoClientes, infoVehiculos, desdeVehículos);
                        break;


                    case 5: //incompleto
                        Console.Clear();
                        MostrarVehiculosDeUnClienteEspecifico(infoVehiculos,infoClientes);
                        break;

                    case 6:
                        //salir
                        Console.Clear();
                        break;
                }

            } while (opcionVehiculos != 6);

            return infoVehiculos;
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
            MostrarMatriz(matrizDada, desdeDonde);
            Console.WriteLine();//separa las lineas en consola para que sean mas legible

            if(matrizDada.GetLength(0) > 1) //revisa en primer plano si hay informacion editable
            {
                if(desdeDonde == 1)
                {
                    Console.Write("Elige la fila de la informacion que deseas editar o borrar. Digita el numero de fila: ");
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
                    opcion = int.Parse(Console.ReadLine());
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
                Console.WriteLine("No hay informacion registrada para editar, registra algo primero");
            }

            Console.Clear();
            return matrizDada;
        }

        static void MostrarMatriz(string[,] matrizElegida, int desdeDonde)
        {

            if(matrizElegida.GetLength(0) > 1 && desdeDonde != 2)
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
                Console.WriteLine();
            }
            else if(matrizElegida.GetLength(0) > 1 && desdeDonde == 2)
            {
                for (int i = 0; i < matrizElegida.GetLength(0); i++)
                {
                    if (i != 0)
                    {
                        Console.Write(i + ". ");
                    }

                    if(matrizElegida.GetLength(1) > 4)
                    {
                        for (int j = 0; j < 4; j++)
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
                    }
                    else
                    {
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
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No hay nada registrado o asignado");
                Console.WriteLine();
            }
        }

        static string[,] AsignarInfoVehículos(string[,] InfoClientes, string[,] infoVehiculos, int desdeDonde)
        {
            string[,] infoVehiculosOriginal = infoVehiculos;
            int eleccionFilaClientes = 0;
            int eleccionFilaVehiculos = 0;
            bool yaAsignado = false;

            if (InfoClientes.GetLength(0) > 2 && infoVehiculos.GetLength(0) > 2) //si hay registrados en primer plano
            {
                if (infoVehiculos.GetLength(1) == 4) //Al comienzo, extiende la matriz en secreto cuando se llama este codigo por primera vez
                {
                    infoVehiculos = new string[infoVehiculos.GetLength(0), infoVehiculos.GetLength(1)+1];
                    for (int i = 0; i < infoVehiculos.GetLength(0); i++)
                    {
                        infoVehiculos = RellenarMatrizDeColumnaExtra(infoVehiculosOriginal, infoVehiculos);
                    }
                }

                MostrarMatriz(InfoClientes, desdeDonde); //elegir el cliente
                Console.WriteLine();
                Console.Write("Digita el numero de fila del cliente que quieres asignarle un vehiculo: ");
                eleccionFilaClientes = int.Parse(Console.ReadLine());
                while(eleccionFilaClientes > InfoClientes.GetLength(0) - 1 || eleccionFilaClientes < 1)//revisa si la eleccion esta en el rango
                {
                    Console.WriteLine();
                    Console.Write($"Eleccion invalida, porfavor elige un rango entre 1 y {InfoClientes.GetLength(0)-1}: ");
                    eleccionFilaClientes = int.Parse(Console.ReadLine());
                }

                Console.Clear();

                MostrarMatriz(infoVehiculos, desdeDonde); //eligir el vehiculo
                Console.WriteLine();
                Console.WriteLine($"Estas asignando un vehiculo al cliente: {InfoClientes[eleccionFilaClientes, 0]} | {InfoClientes[eleccionFilaClientes, 1]} | {InfoClientes[eleccionFilaClientes, 2]}");
                Console.Write("Digita el numero de fila del vehiculo que quieres asignar: ");
                eleccionFilaVehiculos = int.Parse(Console.ReadLine());
                while (eleccionFilaVehiculos > infoVehiculos.GetLength(0) - 1 || eleccionFilaVehiculos < 1)//revisa si la eleccion esta en el rango
                {
                    Console.WriteLine();
                    Console.Write($"Eleccion invalida, porfavor elige un rango entre 1 y {infoVehiculos.GetLength(0) - 1}: ");
                    eleccionFilaVehiculos = int.Parse(Console.ReadLine());
                }

                for (int j = 0; j < infoVehiculos.GetLength(1); j++) //revisa antes si al cliente se le intenta asignar el mismo vehiculo
                {
                    if (infoVehiculos[eleccionFilaVehiculos, j] == InfoClientes[eleccionFilaClientes, 1])
                    {
                        while (infoVehiculos[eleccionFilaVehiculos, j] == InfoClientes[eleccionFilaClientes, 1])
                        {
                            Console.WriteLine();
                            Console.Write("Le intentas asignar el mismo vehiculo a un cliente que ya lo tiene. Elige otro vehiculo digitando su numero de fila: ");
                            eleccionFilaVehiculos = int.Parse(Console.ReadLine());
                        }
                    }
                }

                if (infoVehiculos[eleccionFilaVehiculos, infoVehiculos.GetLength(1) - 1] != null) //si ya existe un cliente en la ultima columna, crea otra
                {
                    infoVehiculos = new string[infoVehiculos.GetLength(0), infoVehiculos.GetLength(1) + 1];
                    infoVehiculos = RellenarMatrizDeColumnaExtra(infoVehiculosOriginal, infoVehiculos);

                    infoVehiculos[eleccionFilaVehiculos, infoVehiculos.GetLength(1) - 1] = InfoClientes[eleccionFilaClientes, 1];

                    yaAsignado = true;
                }

                if (yaAsignado == false)//Este cuenta hasta que se encuentre con un espacio nulo, si no se extiendio la matriz en el for loop anterior (por eso esta yaAsignado == true que se revisa acá). Cuando encuentre un espacio vacio en la fila. asigna la cedula ahí.
                {
                    for (int j = 0; j < infoVehiculos.GetLength(1); j++)//Cuando ya se revise que al cliente no se le asigna el mismo vehículo. Se mete en un diferente espacio en blanco otro cliente            
                    {
                        if (infoVehiculos[eleccionFilaVehiculos, j] == null)
                        {
                            infoVehiculos[eleccionFilaVehiculos, j] = InfoClientes[eleccionFilaClientes, 1];
                            j = infoVehiculos.GetLength(1) - 1; //Lleva el numero de ciclo al maximo para que no siga llenado los otros espacios vacios


                        }
                    }
                }
            }
            else // si no hay nada registrado, hecha este mensaje y no pasa nada
            {
                Console.WriteLine("Hay registracion inexistente en uno de los tipos de informacion. Debe haber al menos un cliente y un vehiculo registrados.");
                Console.WriteLine();
            }

            Console.Clear();
            return infoVehiculos;
        }

        static string[,] RellenarMatrizDeColumnaExtra(string[,] matrizOriginal, string[,] matrizDada)
        {
            for (int i = 0; i < matrizDada.GetLength(0); i++)
            {
                for (int j = 0; j < matrizDada.GetLength(1); j++)
                {
                    if(j < matrizDada.GetLength(1) - 1)
                    {
                        matrizDada[i, j] = matrizOriginal[i, j];
                    }
                }
            }
            return matrizDada;
        }

        static void MostrarVehiculosDeUnClienteEspecifico(string[,] infoDeVehiculos, string[,] infoDeClientes) //incompleto
        {
            string[,] matrizAMostrar = new string[0, 0];
            int eleccionFilaClientes = 0;

            MostrarMatriz(infoDeClientes, 1); //Aqui se elige el cliente del que se quiere ver sus vehiclos
            Console.WriteLine("Digita el numero de fila del cliente del que quieres ver sus vehiculos: ");
            eleccionFilaClientes = int.Parse(Console.ReadLine());

            Console.WriteLine($"El cliente {infoDeClientes[eleccionFilaClientes, 0]} | {infoDeClientes[eleccionFilaClientes, 1]} | {infoDeClientes[eleccionFilaClientes, 2]} tiene asignado los siguientes vehículos: ");

            if(infoDeVehiculos.GetLength(1) < 5) //si no hay asignacion en primer plano. tira este mensaje
            {
                Console.WriteLine("Ningun cliente tiene vehiculo asignado");
            }
            else if (infoDeClientes.GetLength(0) < 2)
            {
                Console.WriteLine("No hay ningun cliente registrado");
            }
            else if(infoDeVehiculos.GetLength(0) < 2)
            {
                Console.WriteLine("Ningun vehiculo registrado");
            }
            else
            {
                for (int i = 0; i < infoDeVehiculos.GetLength(1); i++) //Muestra los titulos de la matriz de vehiculos
                {
                    if (i > 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"//------{infoDeVehiculos[0, i]}------//");
                    }
                }

                for (int i = 0; i < infoDeVehiculos.GetLength(0); i++) //cuando encuentre una fila con la cedula de cliente que coincidente, imprime solamente las primeras 4 columnas
                {
                    for (int j = 0; j < infoDeVehiculos.GetLength(1); j++)
                    {
                        if (infoDeVehiculos[i, j] == infoDeClientes[eleccionFilaClientes, 2])
                        {

                            Console.WriteLine($"|   {infoDeVehiculos[i, 0]}   ||   {infoDeVehiculos[i, 1]}   ||   {infoDeVehiculos[i, 2]}   ||   {infoDeVehiculos[i, 3]}   |");
                        }
                    }
                }
            }
        }
    }
}

