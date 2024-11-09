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

        public IEnumerable<Producto> FiltrarYORdenarProductos(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo) //Filtra productos con precio mayor al minimo especificado
                .OrderBy(p => p.Precio); //Ordena los productos de mayor a menor
        }
    }
}

