using app.api.DTOs;
using app.api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService clienteService;

        public ClienteController(IMapper mapper)
        {
            clienteService = new ClienteService(mapper);
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<ClienteDTO> Get()
        {
            return clienteService.GetClientes();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ClienteDTO Get(string id)
        {
            return clienteService.GetClienteByID(id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IEnumerable<String> Post([FromBody] ClienteDTO cliente)
        {
            return clienteService.InsertCliente(cliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IEnumerable<String> Put(string id, [FromBody] ClienteDTO cliente)
        {
            return clienteService.UpdateCliente(id,cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IEnumerable<String> Delete(string id)
        {
            return clienteService.DeleteCliente(id);
        }
    }
}
