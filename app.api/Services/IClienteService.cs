using app.api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    interface IClienteService
    {
        IEnumerable<ClienteDTO> GetClientes();

        ClienteDTO GetClienteByID(string ClienteID);

        IEnumerable<String> InsertCliente(ClienteDTO Cliente);

        IEnumerable<String> DeleteCliente(string ClienteID);

        IEnumerable<String> UpdateCliente(string id, ClienteDTO Cliente);
    }
}
