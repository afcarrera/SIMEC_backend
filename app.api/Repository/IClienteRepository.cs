using app.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();

        Cliente GetClienteByID(string ClienteID);

        IEnumerable<String> InsertCliente(Cliente Cliente);

        IEnumerable<String> DeleteCliente(string ClienteID);

        IEnumerable<String> UpdateCliente(string id, Cliente Cliente);

        void Save();

    }
}
