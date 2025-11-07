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

            string[,] informacionServicios_0 = new string[1, 3]; //la primera fila es la categoría de la columna
            informacionServicios_0[0, 0] = "//--Vehiculo--//";
            informacionServicios_0[0, 1] = "//--Tipo de servicio--//";
            informacionServicios_0[0, 2] = "//--Fecha--//";

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

                        string[,] infoClientesOriginal = new string[informacionDeClientes_0.GetLength(0), informacionDeClientes_0.GetLength(1)]; //esto es para actualizar la informacion de otras matrices
                        for (int i = 0; i < informacionDeClientes_0.GetLength(0); i++) //este tambien
                        {
                            for (int j = 0; j < informacionDeClientes_0.GetLength(1); j++)
                            {
                                infoClientesOriginal[i, j] = informacionDeClientes_0[i, j];
                            }
                        }

                        informacionDeClientes_0 = GestionDeClientes(informacionDeClientes_0, informacionVehículos_0);

                        if (informacionVehículos_0.GetLength(1) == 5) //Si ya hay asignaciones de vehiculo, hace lo siguiente:
                        {
                            informacionVehículos_0 = ActualizarVehiculos(informacionVehículos_0, informacionDeClientes_0, infoClientesOriginal);//Se actualizan los clientes asignados si se cambiaron.
                        }

                        Console.WriteLine("Saliste de la gestión de clientes");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Clear();

                        string[,] infoVehiculosOriginal = new string[informacionVehículos_0.GetLength(0), informacionVehículos_0.GetLength(1)];//Para actualizar informacion en otras matrices.
                        for (int i = 0; i < informacionVehículos_0.GetLength(0); i++) //este tambien
                        {
                            for (int j = 0; j < informacionVehículos_0.GetLength(1); j++)
                            {
                                infoVehiculosOriginal[i, j] = informacionVehículos_0[i, j];
                            }
                        }

                        informacionVehículos_0 = GestionDeVehiculos(informacionVehículos_0, informacionDeClientes_0);

                        if(informacionServicios_0.GetLength(0) > 1)
                        {
                            informacionServicios_0 = ActualizarInfoServicios(informacionServicios_0, informacionVehículos_0, infoVehiculosOriginal);
                        }

                        Console.WriteLine("Saliste de la gestión de vehículos");
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        informacionServicios_0 = GestionDeServiciosDeMantenimiento(informacionServicios_0, informacionVehículos_0, 3);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ha finalizado el programa");
                        break;
                }

            } while (opcion != 4);
        }

        static string[,] GestionDeClientes(string[,] informacionDeClientes_1, string[,] infoDeVehiculos)
        {
            int desdeClientes = 1;
            int opcionClientes = 0;
            bool yaCambioInfo = false;

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
                            informacionDeClientes_1 = LogicaNuevaInfo(informacionDeClientes_1, informacionDeClientes_1, desdeClientes);
                        }
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        MostrarMatriz(informacionDeClientes_1, desdeClientes);
                        //GestionDeVehiculos();
                        break;

                    case 3:
                        if(yaCambioInfo == false) //Como pueden haber varios cambios en la matriz que el programa no es capaz de identificar con las herramientas actuales, entonces, forzo que el usuario lo actualize manualmente.
                        {
                            Console.Clear();
                            informacionDeClientes_1 = LogicaEditarInfo(informacionDeClientes_1, informacionDeClientes_1, desdeClientes);
                        }
                        else if(yaCambioInfo == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Porfavor sal al menú principal para actualizar la informacion del cliente globalmente en el programa.");
                        }
                        
                        yaCambioInfo = true;
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
            bool yaSeEdito = false;

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
                        infoVehiculos = LogicaNuevaInfo(infoVehiculos, infoVehiculos, desdeVehículos);
                        Console.Clear();
                        break;

                    case 2:
                        //mostrar lista de vehículos
                        Console.Clear();
                        MostrarMatriz(infoVehiculos, desdeVehículos);
                        Console.WriteLine();
                        break;

                    case 3:
                        if(yaSeEdito == false)
                        {
                            Console.Clear();
                            MostrarMatriz(infoVehiculos, desdeVehículos);
                            infoVehiculos = LogicaEditarInfo(infoVehiculos, infoVehiculos, desdeVehículos);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ya se edito un vehículo. Para que se actualize la informacion de manera global. Debes salir primero al menu principal si deseas editar de nuevo.");
                        }
                        yaSeEdito = true;
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

        static string[,] GestionDeServiciosDeMantenimiento(string[,] infoServicios, string[,] infoVehiculos, int desdeDonde)
        {
            int opcionVehiculos = 0;

            do
            {
                Console.WriteLine("Digita el numero de la opción para elegirla.");
                Console.WriteLine("1. Registrar servicio de mantenimiento a un vehiculo.");
                Console.WriteLine("2. Ver historial de servicios de un vehiculo.");
                Console.WriteLine("3. Ver resumen de servicios de todos los vehículos.");
                Console.WriteLine("4. Salir al menú principal.");
                Console.WriteLine();
                Console.Write("Elige: ");
                opcionVehiculos = int.Parse(Console.ReadLine());

                if (opcionVehiculos < 1 || opcionVehiculos > 6)
                {
                    do
                    {
                        Console.WriteLine();
                        Console.Write("Opción no válida. Por favor, elige una opción entre 1 y 6: ");
                        opcionVehiculos = Convert.ToInt32(Console.ReadLine());
                    } while (opcionVehiculos < 1 || opcionVehiculos > 4);
                }

                switch (opcionVehiculos)
                {
                    case 1:
                        Console.Clear();
                        infoServicios = LogicaNuevaInfoServicios(infoServicios, infoVehiculos, 3);
                        break;

                    case 2:
                        Console.Clear();
                        MostrarServiciosDeUnVehiculo(infoServicios, infoVehiculos);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        MostrarMatriz(infoServicios, 3);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Saliste de gestion de servicios");
                        Console.WriteLine();
                        break;
                }

            } while (opcionVehiculos != 4);

            return infoServicios;
        }

        static string[,] LogicaNuevaInfo(string[,] matrizOriginal, string[,] matrizDada, int desdeDonde)
        {
            matrizDada = new string[matrizOriginal.GetLength(0) + 1, matrizOriginal.GetLength(1)];

            for (int i = 0; i < matrizOriginal.GetLength(0); i++)
            {
                for (int j = 0; j < matrizOriginal.GetLength(1); j++)
                {
                    matrizDada[i, j] = matrizOriginal[i, j];
                }
            }

            if(desdeDonde == 1)
            {
                for (int j = 0; j < matrizDada.GetLength(1); j++)
                {
                    Console.Write($"Ingresa la nueva información en {matrizDada[0, j]}: ");
                    matrizDada[matrizDada.GetLength(0) - 1, j] = Console.ReadLine();
                }
            }
            else if (desdeDonde == 2)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"Ingresa la nueva información en {matrizDada[0, j]}: ");
                    matrizDada[matrizDada.GetLength(0) - 1, j] = Console.ReadLine();
                }
            }
            return matrizDada;
        }

        static string[,] LogicaEditarInfo(string[,] matrizOriginal, string[,] matrizDada, int desdeDonde)
        {            
            int eleccionInfo = 0;
            int opcion = 0;

            if (matrizDada.GetLength(0) > 1) //revisa en primer plano si hay informacion editable
            {
                Console.Clear();
                MostrarMatriz(matrizDada, desdeDonde);

                if (desdeDonde == 1)
                {
                    Console.Write("Elige la fila de la informacion que deseas editar o borrar. Digita el numero de fila: ");
                    eleccionInfo = int.Parse(Console.ReadLine());
                    while (eleccionInfo > (matrizOriginal.GetLength(0) - 1) || eleccionInfo < 1) //Verifica si se puso un rango correcto
                    {
                        Console.WriteLine();
                        Console.Write($"Elige en un rango de 1 a {matrizOriginal.GetLength(0) - 1}: ");
                        eleccionInfo = int.Parse(Console.ReadLine());
                    }
                }
                else if (desdeDonde == 2)
                {
                    bool seEncontroPlaca = false;
                    string comparadorDePlaca;


                    //Aca esta todo lo de la eleccion de placa
                    while (eleccionInfo == 0)//Dentro del ciclo revis si la placa existe. Si no existe entonces vuelve a empezar.
                    {
                        Console.WriteLine();
                        Console.Write("Elige la placa del carro. la informacion del carro la puedes editar o borrar: ");
                        comparadorDePlaca = Console.ReadLine();
                        for (int i = 0; i < matrizDada.GetLength(0); i++)
                        {
                            if (comparadorDePlaca == matrizDada[i, 2])//Revisa si la placa existe (si se copio bien)
                            {
                                eleccionInfo = i;
                                seEncontroPlaca = true;
                            }
                        }

                        if (seEncontroPlaca == false)//si no se copio bien entonces pone este mensaje y no sale de ciclo.
                        {
                            Console.Write("Eliga una placa que exista porfavor. Revisa que copiaste todo bien.");
                        }
                    }
                }

                Console.WriteLine();

                Console.Write("Quieres borrar o editarla? elige | '1' para borrar | '2' para editar: ");
                opcion = int.Parse(Console.ReadLine());
                while (opcion < 1 || opcion > 2) //Verifica si se puso un rango correcto
                {
                    Console.WriteLine();
                    Console.Write($"Elige 1 o 2: ");
                    opcion = int.Parse(Console.ReadLine());
                }

                Console.WriteLine();

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
                    for (int j = 0; j < 4; j++)
                    {
                            Console.Write($"Cambia {matrizDada[0, j]}: ");
                            matrizDada[eleccionInfo, j] = Console.ReadLine();
                    }
                }

                Console.Clear();
            }
            else
            {
                Console.WriteLine("No hay informacion registrada para editar, registra algo primero");
            }

            return matrizDada;
        }

        static void MostrarMatriz(string[,] matrizElegida, int desdeDonde)
        {

            if (matrizElegida.GetLength(0) > 1 && desdeDonde == 1)
            {
                for (int i = 0; i < matrizElegida.GetLength(0); i++)
                {
                    if (i != 0)
                    {
                        Console.Write(i + ". ");
                    }
                    for (int j = 0; j < matrizElegida.GetLength(1); j++)
                    {
                        Console.Write($"|      {matrizElegida[i, j]}      |");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            else if (matrizElegida.GetLength(0) > 1 && desdeDonde == 2)
            {
                for (int i = 0; i < matrizElegida.GetLength(0); i++)
                {
                    if (i != 0)
                    {
                        Console.Write(i + ". ");
                    }

                    if (matrizElegida.GetLength(1) > 4)
                    {
                        for (int j = 0; j < matrizElegida.GetLength(1); j++)
                        {
                            if (j < 4)
                            {
                                Console.Write($"|      {matrizElegida[i, j]}      |");
                            }
                            else if (j == 4 && i > 0)
                            {
                                if (matrizElegida[i, 4] == null)
                                {
                                    Console.Write("||| No asignado");
                                }
                                else if (matrizElegida[i, 4] != null)
                                {
                                    Console.Write("||| Asignado");
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < matrizElegida.GetLength(1); j++)
                        {
                            Console.Write($"|      {matrizElegida[i, j]}      |");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            else if (matrizElegida.GetLength(0) > 1 && desdeDonde == 3)
            {
                for (int i = 0; i < matrizElegida.GetLength(0); i++)
                {
                    if (i != 0)
                    {
                        Console.Write(i + ". ");
                    }
                    for (int j = 0; j < matrizElegida.GetLength(1); j++)
                    {
                        Console.Write($"|      {matrizElegida[i, j]}      |");
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
            bool todosEspaciosLLenos = true;
            bool borrarConsola = true;

            if (InfoClientes.GetLength(0) > 1 && infoVehiculos.GetLength(0) > 1) //si hay registrados en primer plano
            {
                if (infoVehiculos.GetLength(1) == 4) //Al comienzo, extiende la matriz en secreto cuando se llama este codigo por primera vez
                {
                    infoVehiculos = new string[infoVehiculos.GetLength(0), infoVehiculos.GetLength(1)+1];
                    infoVehiculos = RellenarMatrizDeColumnaExtra(infoVehiculosOriginal, infoVehiculos);
                }

                for (int i = 0; i < infoVehiculos.GetLength(0); i++)//revisa si en primer plano hay almenos un espacio de asignacion
                {
                    if (infoVehiculos[i, 4] == null && i != 0)
                    {
                        todosEspaciosLLenos = false;
                    }
                }

                if(todosEspaciosLLenos == false)
                {
                    MostrarMatriz(InfoClientes, 1); //elegir el cliente
                    Console.WriteLine();
                    Console.Write("Digita el numero de fila del cliente que quieres asignarle un vehiculo: ");
                    eleccionFilaClientes = int.Parse(Console.ReadLine());
                    while (eleccionFilaClientes > InfoClientes.GetLength(0) - 1 || eleccionFilaClientes < 1)//revisa si la eleccion esta en el rango
                    {
                        Console.WriteLine();
                        Console.Write($"Eleccion invalida, porfavor elige un rango entre 1 y {InfoClientes.GetLength(0) - 1}: ");
                        eleccionFilaClientes = int.Parse(Console.ReadLine());
                    }

                    Console.Clear();

                    MostrarMatriz(infoVehiculos, 2); //eligir el vehiculo
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

                    if (infoVehiculos[eleccionFilaVehiculos, 4] != null)//revisa si el vehiculo elegido ya tiene un cliente asignado
                    {
                        while (infoVehiculos[eleccionFilaVehiculos, 4] != null)
                        {
                            Console.WriteLine();
                            Console.Write("Le intentas asignar a este cliente un vehiculo que ya tiene un cliente asignado. Elige otro vegiculo: ");
                            eleccionFilaVehiculos = int.Parse(Console.ReadLine());
                            while (eleccionFilaVehiculos < 1 || eleccionFilaVehiculos > infoVehiculos.GetLength(0) - 1)
                            {
                                Console.Write("Elige un rango valido porfavor: ");
                                eleccionFilaVehiculos = int.Parse(Console.ReadLine());
                            }
                        }
                    }

                    //Cuando ya se revise que al cliente no se le asigna el mismo vehículo. Se mete en el espacio en blanco de la matriz de la fila del vehiculo elegido en la última columna.           
                    infoVehiculos[eleccionFilaVehiculos, 4] = InfoClientes[eleccionFilaClientes, 1];
                }
                else if (todosEspaciosLLenos == true)
                {
                    Console.Clear();
                    Console.WriteLine("Ya todos los vehiculos estan asignados. Todavia puedes registrar nuevos vehiculos");
                    borrarConsola = false;
                }
            }
            else // si no hay nada registrado, hecha este mensaje y no pasa nada
            {
                Console.WriteLine("Hay registracion inexistente en uno de los tipos de informacion. Debe haber al menos un cliente y un vehiculo registrados.");
                Console.WriteLine();
                borrarConsola = false;
            }

            if(borrarConsola == true)
            {
                Console.Clear();
            }
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
            int eleccionFilaClientes = 0;
            bool existenCosas = true;

            //si falta informacion en primer plano. tira estos mensajes dependiendo de lo que falta
            if (infoDeVehiculos.GetLength(1) < 5) 
            {
                Console.WriteLine("Ningun cliente tiene vehiculo asignado");
                existenCosas = false;

                if (infoDeClientes.GetLength(0) < 2)
                {
                    Console.WriteLine("No hay ningun cliente registrado");
                    existenCosas = false;
                }

                if (infoDeVehiculos.GetLength(0) < 2)
                {
                    Console.WriteLine("No hay ningun vehiculo registrado");
                    existenCosas = false;
                }
            }

            if (existenCosas == true) //Si hay las suficentes cosas pa que funcionen bien las cosas en este modulo, realiza la muestra
            {
                bool clienteTieneVehiculos = false;

                MostrarMatriz(infoDeClientes, 1); //Aqui se elige el cliente del que se quiere ver sus vehiclos
                Console.Write("Digita el numero de fila del cliente del que quieres ver sus vehiculos: ");
                eleccionFilaClientes = int.Parse(Console.ReadLine());
                while(eleccionFilaClientes < 1 || eleccionFilaClientes > infoDeClientes.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Elige un rango valido porfavor: ");
                    eleccionFilaClientes = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < infoDeVehiculos.GetLength(0); i++)
                {
                    if(infoDeVehiculos[i,4] == infoDeClientes[eleccionFilaClientes,1])
                    {
                        clienteTieneVehiculos = true;
                    }
                }
                
                if(clienteTieneVehiculos == false)
                {
                    Console.WriteLine("El cliente no tiene vehículos registrados");
                    Console.WriteLine();
                    return;
                }

                Console.WriteLine($"El cliente {infoDeClientes[eleccionFilaClientes, 0]} | {infoDeClientes[eleccionFilaClientes, 1]} | {infoDeClientes[eleccionFilaClientes, 2]} tiene asignado los siguientes vehículos: ");

                Console.WriteLine();

                for (int j = 0; j < infoDeVehiculos.GetLength(1); j++) //Muestra los titulos de la matriz de vehiculos
                {
                    if (j < 4)
                    {
                        Console.Write(infoDeVehiculos[0, j]);//no le pongo espaciadores porque ya tiene
                    }
                }

                Console.WriteLine();

                for (int i = 0; i < infoDeVehiculos.GetLength(0); i++)//En la matriz de vehiculos que ya tiene una quitna columna secreta, cuando encuentre una fila con la cedula de cliente que coincide, imprime solamente las primeras 4 columnas
                {
                    if (infoDeClientes[eleccionFilaClientes, 1] == infoDeVehiculos[i, 4])
                    {

                        Console.WriteLine($"|   {infoDeVehiculos[i, 0]}   ||   {infoDeVehiculos[i, 1]}   ||   {infoDeVehiculos[i, 2]}   ||   {infoDeVehiculos[i, 3]}   |");
                    }
                }
            }

            Console.WriteLine();
        }

        static string[,] ActualizarVehiculos(string[,] infoDeVehiculos, string[,] infoDeClientes, string[,] infoClientesOriginal)
        {
            int posicionEncontrada = 0;
            bool actualizacionEncontrada = true;

            if (infoClientesOriginal.GetLength(0) == infoDeClientes.GetLength(0))//Si solamente se edito un cliente.
            {//A continuacion se hará un ciclo de ciclos. Se revisará cada cedula individualmente. En el ciclo secundario si se encuentra una cedula coincidente guarda las posiciones y sale del cliclo. Afuera cambia la cedula
                int posicionCedula = 1;
                do
                {
                    if(posicionCedula == infoClientesOriginal.GetLength(0)) //caso donde no se cambio nada, el ciclo seguria si n ofuera por esto
                    {
                        return infoDeVehiculos;
                    }

                    actualizacionEncontrada = true;
                    for (int i = 0; i < infoClientesOriginal.GetLength(0); i++) //adentro cambia en las cedulas actualizadas
                    {
                        if (infoClientesOriginal[posicionCedula, 1] == infoDeClientes[i, 1]) //En este for loop, si se encuentra al menos 1 cedula coincidente desde las cedulas originales entonces esa no fue la que se cambió. Si no se encuentra nada entonces se sale del ciclo y abre el ciclo padre.
                        {
                            actualizacionEncontrada = false;
                            i = infoClientesOriginal.GetLength(0)-1; //para que salga del ciclo
                        }
                    }
                    posicionEncontrada = posicionCedula;
                    posicionCedula++;
                } while (actualizacionEncontrada == false);

                for (int i = 0; i < infoDeVehiculos.GetLength(0); i++)//Finalmente se actualiza la cedula
                {
                    if(infoDeVehiculos[i, 4] == infoClientesOriginal[posicionEncontrada,1])//Se encuentra la cedula que antes existia en vehículos y se cambia por la nueva.
                    {
                        infoDeVehiculos[i, 4] = infoDeClientes[posicionEncontrada,1];
                    }
                }
            }
            else if(infoClientesOriginal.GetLength(0) > infoDeClientes.GetLength(0)) //Si se borró un cliente
            {//De la misma manera que el anterior, Cuando se encuentre la cedula que no coincide en el ciclo de ciclos guarda su posicion y se actualiza al final.
                int posicionCedula = 1;
                //afuera cambia en las cedulas originales
                do
                {
                    actualizacionEncontrada = true;
                    for (int i = 0; i < infoDeClientes.GetLength(0); i++) //adentro cambia en las cedulas actualizadas
                    {
                        if (infoClientesOriginal[posicionCedula, 1] == infoDeClientes[i, 1]) //En este for loop, si se encuentra al menos 1 cedula coincidente desde las cedulas originales entonces esa no fue la que se cambió. Si no se encuentra nada entonces se sale del ciclo y abre el ciclo padre.
                        {
                            actualizacionEncontrada = false;
                            i = infoClientesOriginal.GetLength(0)-1; // para que salga de ciclo.
                        }
                    }

                    posicionEncontrada = posicionCedula;
                    posicionCedula++;
                } while (actualizacionEncontrada == false);

                for (int i = 0; i < infoDeVehiculos.GetLength(0); i++) //Finalmente se actualiza la cedula
                {
                    if (infoDeVehiculos[i, 4] == infoClientesOriginal[posicionEncontrada, 1]) //Se encuentra la cedula que antes existia en vehículos y se cambia por nada porque ya no existe.
                    {
                        infoDeVehiculos[i, 4] = null;
                    }
                }
            }

            return infoDeVehiculos;
        }

        static string[,] LogicaNuevaInfoServicios(string[,] infoServicios, string[,] infoVehiculos, int desdeDonde)
        {
            int eleccionFilaVehiculos = 0;
            int contadorHasta5 = 0;

            if(infoVehiculos.GetLength(0) == 1)//si hay vehiculos en primer plano. Si no, saca este mensaje y se sale.
            {
                Console.Clear();
                Console.WriteLine("No hay ningun vehículo registrado. No puedes asignar servicios. Registra un vehículo primero");
                Console.WriteLine();
                return infoServicios;
            }

            string[,] infoDeServiciosOriginal = new string[infoServicios.GetLength(0), infoServicios.GetLength(1)];
            for (int i = 0; i < infoDeServiciosOriginal.GetLength(0); i++) //Se crea una copia original de la matriz
            {
                for (int j = 0; j < infoDeServiciosOriginal.GetLength(1); j++)
                {
                    infoDeServiciosOriginal[i, j] = infoServicios[i, j];
                }
            }

            infoServicios = new string[infoServicios.GetLength(0) + 1, infoServicios.GetLength(1)];
            for (int i = 0; i < infoDeServiciosOriginal.GetLength(0); i++) //Se extiende la matriz para la nueva informacion y se mete la informacion que antes existia.
            {
                for (int j = 0; j < infoDeServiciosOriginal.GetLength(1); j++)
                {
                    infoServicios[i, j] = infoDeServiciosOriginal[i, j];
                }
            }

            MostrarMatriz(infoVehiculos, 2);

            Console.Write("Elige el vehículo al que le vas a agregar un servicio digitando su fila: "); //previamente se muestra la matriz de los vehiculos para que se escoga el vehiculo con el indice de fila.
            eleccionFilaVehiculos = int.Parse(Console.ReadLine());
            while(eleccionFilaVehiculos > infoVehiculos.GetLength(0) - 1 || eleccionFilaVehiculos < 1)//Revisa si se eligio en un rango correcto
            {
                Console.WriteLine();
                Console.Write("Elige en un rango de 1 a " + (infoVehiculos.GetLength(0) - 1));
            }

            for (int i = 0; i < infoDeServiciosOriginal.GetLength(0); i++) //Acá voy a revisar si el vehiculo ya tiene 5 servicios asignados. Si los tiene entonces se devuelve a la gestion de servicios.
            {
                if (infoVehiculos[eleccionFilaVehiculos, 2] == infoDeServiciosOriginal[i,0])
                {
                    contadorHasta5++;
                    if (contadorHasta5 == 5)
                    {
                        Console.WriteLine("Este vehículo ya tiene 5 servicios. Ya no se le pueden asignar mas.");
                        return infoDeServiciosOriginal;
                    }
                }
            }

            infoServicios[infoServicios.GetLength(0) - 1, 0] = infoVehiculos[eleccionFilaVehiculos, 2];//Asigna la placa del carro a lo ultimo. Empieza en 1 para arriba pq la primera fila no cuenta solo son titulos.
            for (int j = 0; j < infoServicios.GetLength(1); j++) //Asigna las otras 2 cosas a lo ultimo
            {
                if(j != 0) //Pa que no se asigne la placa por accidente
                {
                    Console.WriteLine();
                    Console.Write($"Ingresa la nueva informacion en {infoServicios[0, j]}: ");
                    infoServicios[infoServicios.GetLength(0) - 1, j] = Console.ReadLine();
                }
            }

            Console.Clear();
            return infoServicios;
        }

        static void MostrarServiciosDeUnVehiculo(string[,] infoServicios, string[,] infoVehiculos)
        {
            int eleccionFilaVehiculos = 0;
            bool seEncontroServicio = false;

            if (infoVehiculos.GetLength(0) == 1)//si hay vehiculos registrado en primer plano
            {
                Console.WriteLine();
                Console.WriteLine("No hay ningun vehiculo registrado. Registra un vehiculo primero");
                return;
            }
            else if(infoServicios.GetLength(0) == 1)//si hay servicios registrados en primer plano
            {
                Console.WriteLine();
                Console.WriteLine("No hay ningun vehiculo servicio. Registra un servicio primero");
                return;
            }

            MostrarMatriz(infoVehiculos, 2);
            Console.WriteLine();
            Console.Write("Elige el vehículo del que quieres ver su historial de servicios digitando su numero de fila: ");
            eleccionFilaVehiculos = int.Parse(Console.ReadLine());

            for (int i = 0; i < infoServicios.GetLength(0); i++)
            {
                if (infoServicios[i,0] == infoVehiculos[eleccionFilaVehiculos, 2])
                {
                    seEncontroServicio = true;
                }
            }

            if(seEncontroServicio == false)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Este vehiculo no tiene servicios");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"El vehiculo {infoVehiculos[eleccionFilaVehiculos,0]} || {infoVehiculos[eleccionFilaVehiculos, 1]} || {infoVehiculos[eleccionFilaVehiculos, 2]} || {infoVehiculos[eleccionFilaVehiculos, 3]} || tiene los siguientes servicios.");//Imprime el carro elegido
            Console.WriteLine();

            Console.Write(infoServicios[0, 1]); //imrpime los 2 titulos de la matriz
            Console.Write(infoServicios[0, 2]);

            Console.WriteLine();

            for (int i = 0; i < infoServicios.GetLength(0); i++)
            {
                if (infoServicios[i,0] == infoVehiculos[eleccionFilaVehiculos, 2])
                {
                    Console.WriteLine($"{infoServicios[i,1]} || {infoServicios[i,2]}");
                }
            }

            Console.WriteLine();
        }

        static string[,] ActualizarInfoServicios(string[,] infoServicios, string[,] infoVehiculos, string[,] infoVehiculosOriginal)
        {
            int posicionEncontrada = 0;
            bool actualizacionEncontrada = true;
            int contadorDePlacaBorrada = 0;

            if (infoVehiculosOriginal.GetLength(0) == infoVehiculos.GetLength(0))//si solamente se edito un cliente.
            {//a continuacion se hará un ciclo de ciclos. se revisará cada placa individualmente. en el ciclo secundario si se encuentra una placa coincidente guarda las posiciones y sale del cliclo. afuera cambia la placa a la nueva
                int posicionPlaca = 0;

                do
                {
                    if (posicionPlaca == infoVehiculosOriginal.GetLength(0)) //caso donde no se cambio nada, el ciclo seguria si no fuera por esto
                    {
                        return infoServicios;
                    }

                    actualizacionEncontrada = true;
                    for (int i = 0; i < infoVehiculosOriginal.GetLength(0); i++) //adentro cambia en las placas actualizadas
                    {
                        if (infoVehiculosOriginal[posicionPlaca, 2] == infoVehiculos[i, 2]) //en este for loop, si se encuentra al menos 1 placa coincidente desde las cedulas originales entonces esa no fue la que se cambió. si no se encuentra nada entonces se sale del ciclo y abre el ciclo padre.
                        {
                            actualizacionEncontrada = false;
                            i = infoVehiculosOriginal.GetLength(0) - 1; //para que salga del ciclo
                        }
                    }

                    posicionEncontrada = posicionPlaca;
                    posicionPlaca++;
                } while (actualizacionEncontrada == false);

                for (int i = 0; i < infoServicios.GetLength(0); i++)//finalmente se actualiza la placa
                {
                    if (infoServicios[i, 0] == infoVehiculosOriginal[posicionEncontrada, 2])//se encuentra la placa que antes existia en vehículos y se cambia por la nueva.
                    {
                        infoServicios[i, 0] = infoVehiculos[posicionEncontrada, 2];
                    }
                }
            }
            else if (infoVehiculosOriginal.GetLength(0) > infoVehiculos.GetLength(0)) //si se borró un cliente
            {//de la misma manera que el anterior, cuando se encuentre la cedula que no coincide en el ciclo de ciclos guarda su posicion y se actualiza al final.
                int posicionPlaca = 1;
                do
                {
                    if (posicionPlaca == infoVehiculosOriginal.GetLength(0)) //caso donde no se cambio nada, el ciclo seguria si no fuera por esto
                    {
                        return infoServicios;
                    }

                    actualizacionEncontrada = true;
                    for (int i = 0; i < infoVehiculos.GetLength(0); i++) //adentro cambia en las placas actualizadas
                    {
                        if (infoVehiculosOriginal[posicionPlaca, 2] == infoVehiculos[i, 2]) //en este for loop, si se encuentra al menos 1 placa coincidente desde las cedulas originales entonces esa no fue la que se cambió. si no se encuentra nada entonces se sale del ciclo y abre el ciclo padre.
                        {
                            actualizacionEncontrada = false;
                            i = infoVehiculosOriginal.GetLength(0) - 1; //para que salga del ciclo
                        }
                    }

                    posicionEncontrada = posicionPlaca;
                    posicionPlaca++;
                } while (actualizacionEncontrada == false);

                for (int i = 0; i < infoServicios.GetLength(0); i++)//Encuentro la cantidad de veces que se esta la placa borrada
                {
                    if (infoServicios[i, 0] == infoVehiculosOriginal[posicionEncontrada, 2])
                    {
                        contadorDePlacaBorrada++;
                    }
                }

                string[,] infoDeServiciosOriginal = new string[infoServicios.GetLength(0), infoServicios.GetLength(1)];//Creo una copia de la matriz antes de cambiarla

                for (int i = 0; i < infoServicios.GetLength(0); i++)//Creo una copia de la matriz antes de cambiarla
                {
                    for (int j = 0; j < infoServicios.GetLength(1); j++)
                    {
                        infoDeServiciosOriginal[i,j] = infoServicios[i,j];
                    }
                }

                MostrarMatriz(infoDeServiciosOriginal, 3);

                infoServicios = new string[infoServicios.GetLength(0) - contadorDePlacaBorrada, infoServicios.GetLength(1)];//Le quito los espacios que tienen la placa vieja con -contadorDePlacaBorrada.

                for (int i = 0; i < infoServicios.GetLength(0); i++)//Cuando encuentre la placa que ya no existe, se la eskipea.
                {
                    if (infoDeServiciosOriginal[i,0] != infoVehiculosOriginal[posicionEncontrada, 2])//Las copias las realiza por fila. Si se llega a la fila donde esta la placa que no existe se la salta
                    {
                        Console.WriteLine("Entre al coso correcto");
                        Console.WriteLine(infoDeServiciosOriginal[i,0]);
                        infoServicios[i, 0] = infoDeServiciosOriginal[i, 0];
                        infoServicios[i, 1] = infoDeServiciosOriginal[i, 1];
                        infoServicios[i, 2] = infoDeServiciosOriginal[i, 2];
                    }
                }
            }

            string pene = Console.ReadLine();
            return infoServicios;
        }
    }
}

