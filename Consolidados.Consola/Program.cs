using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.Consola
{
    internal class Program
    {
        #region Menus
        static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Consolidados: Consola");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("1. Tablas Maestras");
            Console.WriteLine("2. Tablas Principales");
            Console.WriteLine("3. Operaciones");
            Console.WriteLine("4. Reportes");
            Console.WriteLine("");
            Console.WriteLine("0. Salir");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Elige una opcion: ");
        }
        static void MenuTablasPrincipales()
        {
            Console.Clear();
            Console.WriteLine("Consolidados: Consola");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("1. Estados");
            Console.WriteLine("2. Clasificación TipoDocumento");
            Console.WriteLine("3. Tipo de Documento");
            Console.WriteLine("4. Almacen");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Elige una opcion: ");
        }
        static void MenuEstados()
        {
            Console.Clear();
            Console.WriteLine("Consolidados: Consola");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("1. Agregar Estado");
            Console.WriteLine("2. Lista de Estados");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Elige una opcion: ");
        }
        #endregion

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            bool salir = false;

            while (!salir)
            {
                salir = false;

                try
                {
                    MenuPrincipal();
                    int op1 = Convert.ToInt32(Console.ReadLine());

                    switch (op1)
                    {
                        case 0:
                            salir = true;
                            Console.WriteLine("Hasta luego");
                            Console.ReadKey();
                            break;
                        case 1:
                            MenuTablasPrincipales();
                            int op2 = Convert.ToInt32(Console.ReadLine());

                            switch (op2)
                            {
                                case 1:
                                    MenuEstados();
                                    int op3 = Convert.ToInt32(Console.ReadLine());

                                    switch (op3)
                                    {
                                        case 1:
                                            break;
                                        case 2:
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Consolidados: Consola");
                                    Console.WriteLine("=====================");
                                    Console.WriteLine("");
                                    Console.WriteLine("1. Agregar Clasificación TipoDocumento");
                                    Console.WriteLine("2. Lista de Clasificación TipoDocumento");
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Consolidados: Consola");
                                    Console.WriteLine("=====================");
                                    Console.WriteLine("");
                                    Console.WriteLine("1. Agregar Tipo de Documento");
                                    Console.WriteLine("2. Lista de Tipo de Documento");
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Consolidados: Consola");
                                    Console.WriteLine("=====================");
                                    Console.WriteLine("");
                                    Console.WriteLine("1. Agregar Almacen");
                                    Console.WriteLine("2. Lista de Almacenes");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            Console.ReadLine();
        }

        
    }
}