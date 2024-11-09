using GestionInventario;
using System;

namespace GestionInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("¡Hola! ¡Sea bienvenido al sistema de gestión de inventario!");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Por favor, seleccione una de nuestras opciones:");
                Console.WriteLine("  1- Agregar productos al inventario.");
                Console.WriteLine("  2- Filtrar y mostrar productos por precio mínimo.");
                Console.WriteLine("  3- Actualizar el precio de un producto registrado.");
                Console.WriteLine("  4- Eliminar un producto del inventario.");
                Console.WriteLine("  5- Contar y agrupar productos por rango de precio.");
                Console.WriteLine("  6- Generar un reporte del inventario");
                Console.WriteLine("  7- Salir del sistema.");
                Console.WriteLine();

                Console.Write("\nPor favor, ingrese la opcion de su preferencia: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("\n¿Cuantos productos desea ingresar al inventario? ");
                        if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                        {
                            for (int i = 0; i < cantidad; i++)
                            {
                                Console.WriteLine($"\nProducto {i + 1} : ");

                                Console.Write("Nombre: ");
                                string nombre = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(nombre))
                                {
                                    Console.Write("¡Hey! ¡ERROR! El nombre no puede estar vacío. Por favor, ingrese el nombre: ");
                                    nombre = Console.ReadLine();
                                }

                                Console.Write("Precio: ");
                                decimal precio;
                                while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                                {
                                    Console.Write("¡Hey! ¡ERROR! Precio invalido. Por favor, ingrese un precio positivo: ");
                                }

                                Producto producto = new Producto(nombre, precio);
                                inventario.AgregarProducto(producto);
                            }
                        }
                        else
                        {
                            Console.WriteLine("¡Hey! ¡ERROR! Cantidad invalida. Por favor, ingrese un numero entero positivo.");
                        }
                        break;

                    case "2":
                        Console.Write("\n¡Hey! Ingrese el precio minimo para filtrar los productos: ");
                        decimal precioMinimo;
                        while (!decimal.TryParse(Console.ReadLine(), out precioMinimo) || precioMinimo < 0)
                        {
                            Console.Write("¡HEY! ¡ERROR! Precio minimo invalido. Por favor, ingrese un valor positivo: ");
                        }

                        var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

                        Console.WriteLine("\nProductos filtrados y ordenados:");
                        foreach (var producto in productosFiltrados)
                        {
                            producto.MostrarInformacion();
                        }
                        break;

                    case "3":
                        string opcionActualizar;
                        do
                        {
                            Console.Write("\n¿Desea actualizar el precio de un producto? (s/n): ");
                            opcionActualizar = Console.ReadLine().ToLower();
                            if (opcionActualizar == "s")
                            {
                                Console.Write("Ingrese el nombre del producto a actualizar: ");
                                string nombreActualizar = Console.ReadLine();
                                Console.Write("Ingrese el nuevo precio: ");
                                decimal nuevoPrecio;
                                while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
                                {
                                    Console.Write("¡HEY! ¡ERROR! Precio invalido. Por favor, ingrese un precio positivo: ");
                                }
                                inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                            }
                        } while (opcionActualizar == "s");
                        break;

                    case "4":
                        string opcionEliminar;
                        do
                        {
                            Console.Write("\n¿Desea eliminar un producto? (s/n): ");
                            opcionEliminar = Console.ReadLine().ToLower();
                            if (opcionEliminar == "s")
                            {
                                Console.Write("Ingrese el nombre del producto a eliminar: ");
                                string nombreEliminar = Console.ReadLine();
                                inventario.EliminarProducto(nombreEliminar);
                            }
                        } while (opcionEliminar == "s");
                        break;

                    case "5":
                        Console.WriteLine("\nConteo y agrupación de productos por rango de precio:");
                        inventario.ContarYAgruparProductos();
                        break;

                    case "6":
                        Console.WriteLine("\nGenerando reporte del inventario:");
                        inventario.GenerarReporte();
                        break;

                    case "7":
                        continuar = false;
                        Console.WriteLine("Gracias por usar el sistema de gestión de inventario. ¡Chao!");
                        Console.WriteLine("El sistema se ha cerrado");
                        break;

                    default:
                        Console.WriteLine("¡HEY! ¡ERROR! Opción invalida. Por favor, seleccione una opción valida.");
                        break;
                }
            }
        }
    }
}
