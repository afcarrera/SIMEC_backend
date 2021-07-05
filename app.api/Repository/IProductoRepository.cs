using app.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    interface IProductoRepository
    {
        IEnumerable<Producto> GetProductos();

        Producto GetProductoByID(int ProductoID);

        String InsertProducto(Producto Producto);

        String DeleteProducto(int ProductoID);

        String UpdateProducto(int id, Producto Producto);

        void Save();
    }
}
