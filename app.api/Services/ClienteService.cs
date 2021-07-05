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
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly ClienteRepository _clienteRepository;
        private readonly SIMECContext _dbContext;

        public ClienteService(IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = new SIMECContext();
            _clienteRepository = new ClienteRepository(_dbContext);
        }
        public IEnumerable<String> DeleteCliente(string ClienteID)
        {
            return _clienteRepository.DeleteCliente(ClienteID);
        }

        public ClienteDTO GetClienteByID(string ClienteID)
        {
            return _mapper.Map<ClienteDTO>(_clienteRepository.GetClienteByID(ClienteID));
        }

        public IEnumerable<ClienteDTO> GetClientes()
        {
            return _mapper.Map<IEnumerable<ClienteDTO>>(_clienteRepository.GetClientes());
        }

        public IEnumerable<String> InsertCliente(ClienteDTO Cliente)
        {
            return _clienteRepository.InsertCliente(_mapper.Map<Cliente>(Cliente));
        }

        public IEnumerable<String> UpdateCliente(string id,ClienteDTO Cliente)
        {
            return _clienteRepository.UpdateCliente(id,_mapper.Map<Cliente>(Cliente));
        }
    }
}
