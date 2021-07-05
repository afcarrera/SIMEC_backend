using app.api.DbContexts;
using app.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly SIMECContext _dbContext;
        public ProductoRepository(SIMECContext dbContext)
        {
            _dbContext = dbContext;
        }
        public String DeleteProducto(int ProductoID)
        {
            var Producto = _dbContext.Productos.Find(ProductoID);
            if (Producto == null)
            {
                return "Error al eliminar.";
            }
            _dbContext.Productos.Remove(Producto);
            Save();
            return "Eliminación exitosa.";
        }

        public Producto GetProductoByID(int ProductoID)
        {
            return _dbContext.Productos.Find(ProductoID);
        }

        public IEnumerable<Producto> GetProductos()
        {
            return _dbContext.Productos.ToList();
        }

        public String InsertProducto(Producto Producto)
        {
            _dbContext.Add(Producto);
            try
            {
                Save();
            }
            catch (DbUpdateException)
            {
                if (ProductoExists(Producto.Idproducto))
                {
                    return "Error al insertar.";
                }
                else
                {
                    throw;
                }
            }
            return "Inserción exitosa.";
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public String UpdateProducto(int id,Producto Producto)
        {
            Producto.Idproducto = id;
            _dbContext.Update(Producto);
            _dbContext.Entry(Producto).State = EntityState.Modified;
            try
            {
                Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(Producto.Idproducto))
                {
                    return "Error al actualizar.";
                }
                else
                {
                    throw;
                }
            }
            return "Actualización exitosa.";
        }
        private bool ProductoExists(int ProductoID)
        {
            return _dbContext.Productos.Count(e => e.Idproducto == ProductoID) > 0;
        }
    }
}
