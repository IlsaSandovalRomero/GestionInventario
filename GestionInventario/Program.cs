
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

            int cantidad;
            while (true)
            {
                Console.Write("¿Cuántos productos desea ingresar? ");
                if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
                {
                    break; 
                }
                Console.WriteLine("Cantidad inválida. Por favor, ingrese un número entero positivo.");
            }

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

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }

            Console.Write("\n¿Desea actualizar el precio de un producto? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Ingrese el nombre del producto a actualizar: ");
                string nombreActualizar = Console.ReadLine();
                Console.Write("Ingrese el nuevo precio: ");
                decimal nuevoPrecio;
                while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
                {
                    Console.Write("Precio inválido. Ingrese un precio positivo: ");
                }
                inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
            }

            Console.Write("\n¿Desea eliminar un producto? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Ingrese el nombre del producto a eliminar: ");
                string nombreEliminar = Console.ReadLine();
                inventario.EliminarProducto(nombreEliminar);
            }

            Console.WriteLine("\nConteo y agrupación de productos por rango de precio:");
            inventario.ContarYAgruparProductos();

            Console.WriteLine("\nGenerando reporte del inventario:");
            inventario.GenerarReporte();
        }
    }
}