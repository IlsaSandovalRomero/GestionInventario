
using GestionInventario;
using System;

namespace GestionInventario
{

    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenido al sistema de gestion de inventario");
            Console.WriteLine();

            Console.WriteLine("¿Cuantos productos desea ingresar?");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {1 + i} : ");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);

            }

            Console.WriteLine($"\nIngrese el precio minimo para filtrar los productos:  ");
            decimal precioMinimo = decimal.Parse(Console.ReadLine());

            var productosFiltrados = inventario.FiltrarYORdenarProductos(precioMinimo);

            Console.WriteLine($"\nProductos filtrados y ordenados: ");
            foreach (var producto in productosFiltrados)
            {
                Console.Write($"Nombre del producto: {producto.Nombre}, Precio: {producto.Precio}   ");
            }

        }
    }
}