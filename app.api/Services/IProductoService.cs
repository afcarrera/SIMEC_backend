using app.api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    interface IProductoService
    {
        IEnumerable<ProductoDTO> GetProductos();

        ProductoDTO GetProductoByID(int ProductoID);

        String InsertProducto(ProductoDTO Producto);

        String DeleteProducto(int ProductoID);

        String UpdateProducto(int id, ProductoDTO Producto);

    }
}
