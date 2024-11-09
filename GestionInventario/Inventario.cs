using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }


        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto '{nombre}' ha sido actualizado a {nuevoPrecio:C}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto '{nombre}' eliminado del inventario.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void ContarYAgruparProductos()
        {
            var grupos = productos.GroupBy(p =>
            {
                if (p.Precio < 100) return "Menores a 100";
                if (p.Precio <= 500) return "Entre 100 y 500";
                return "Mayores a 500";
            });

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"\n{grupo.Key}: {grupo.Count()} productos");
            }
        }

        public IEnumerable<Producto> FiltrarYORdenarProductos(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo) //Filtra productos con precio mayor al minimo especificado
                .OrderBy(p => p.Precio); //Ordena los productos de mayor a menor
        }


        public void GenerarReporte()
        {
            if (productos.Any())
            {
                int totalProductos = productos.Count;
                decimal precioPromedio = productos.Average(p => p.Precio);
                var productoMasCaro = productos.OrderByDescending(p => p.Precio).First();
                var productoMasBarato = productos.OrderBy(p => p.Precio).First();

                Console.WriteLine("\n--- Reporte de Inventario ---");
                Console.WriteLine($"Total de productos: {totalProductos}");
                Console.WriteLine($"Precio promedio: {precioPromedio:C}");
                Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre} - Precio: {productoMasCaro.Precio:C}");
                Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre} - Precio: {productoMasBarato.Precio:C}");
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario para generar un reporte.");
            }
        }
    }
}

