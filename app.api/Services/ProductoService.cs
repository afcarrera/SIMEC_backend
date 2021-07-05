using app.api.DbContexts;
using app.api.DTOs;
using app.api.Models;
using app.api.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IMapper _mapper;
        private readonly ProductoRepository _productoRepository;
        private readonly SIMECContext _dbContext;

        public ProductoService(IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = new SIMECContext();
            _productoRepository = new ProductoRepository(_dbContext);
        }
        public String DeleteProducto(int ProductoID)
        {
            return _productoRepository.DeleteProducto(ProductoID);
        }

        public ProductoDTO GetProductoByID(int ProductoID)
        {
            return _mapper.Map<ProductoDTO>(_productoRepository.GetProductoByID(ProductoID));
        }

        public IEnumerable<ProductoDTO> GetProductos()
        {
            return _mapper.Map<IEnumerable<ProductoDTO>>(_productoRepository.GetProductos());
        }

        public String InsertProducto(ProductoDTO producto)
        {
            return _productoRepository.InsertProducto(_mapper.Map<Producto>(producto));
        }

        public String UpdateProducto(int id,ProductoDTO producto)
        {
            return _productoRepository.UpdateProducto(id,_mapper.Map<Producto>(producto));
        }
    }
}
