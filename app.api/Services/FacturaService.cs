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
    public class FacturaService : IFacturaService
    {
        private readonly IMapper _mapper;
        private readonly FacturaRepository _facturaRepository;
        private readonly SIMECContext _dbContext;

        public FacturaService(IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = new SIMECContext();
            _facturaRepository = new FacturaRepository(_dbContext);
        }
        public String DeleteFactura(int FacturaID)
        {
            return _facturaRepository.DeleteFactura(FacturaID);
        }

        public FacturaDTO GetFacturaByID(int FacturaID)
        {
            return _mapper.Map<FacturaDTO>(_facturaRepository.GetFacturaByID(FacturaID));          
        }

        public IEnumerable<FacturaDTO> GetFacturas()
        {
            return _mapper.Map<IEnumerable<FacturaDTO>>(_facturaRepository.GetFacturas());
        }

        public String InsertFactura(FacturaDTO Factura)
        {
            return _facturaRepository.InsertFactura(_mapper.Map<Factura>(Factura));
        }

        public String UpdateFactura(int id,FacturaDTO Factura)
        {
            return _facturaRepository.UpdateFactura(id,_mapper.Map<Factura>(Factura));
        }
    }
}
