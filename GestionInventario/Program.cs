
using GestionInventario;
using System;

namespace GestionInventario
{

    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("¡Bienvenido al sistema de gestión de inventario!");
            Console.WriteLine();

            Console.Write("¿Cuántos productos desea ingresar? ");
            if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Console.WriteLine($"\nProducto {i + 1} : ");
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.Write("El nombre no puede estar vacío. Ingrese el nombre: ");
                        nombre = Console.ReadLine();
                    }

                    Console.Write("Precio: ");
                    decimal precio;
                    while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.Write("Precio inválido. Ingrese un precio positivo: ");
                    }

                    Producto producto = new Producto(nombre, precio);
                    inventario.AgregarProducto(producto);
                }

                Console.Write("\nIngrese el precio mínimo para filtrar los productos: ");
                decimal precioMinimo;
                while (!decimal.TryParse(Console.ReadLine(), out precioMinimo) || precioMinimo < 0)
                {
                    Console.Write("Precio mínimo inválido. Ingrese un valor positivo: ");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida. El programa se cerrará.");
            }
        }
    }
}