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

        public IEnumerable<Producto> FiltrarYORdenarProductos(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo) //Filtra productos con precio mayor al minimo especificado
                .OrderBy(p => p.Precio); //Ordena los productos de mayor a menor
        }
    }
}

