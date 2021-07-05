using app.api.DbContexts;
using app.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SIMECContext _dbContext;

        public ClienteRepository(SIMECContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<String> DeleteCliente(string ClienteID)
        {
            IEnumerable<String> respuesta = Enumerable.Empty<String>();
            var cliente = _dbContext.Clientes.Find(ClienteID);
            if (cliente == null)
            {
                 
                respuesta = respuesta.Concat(new[] { "Error al borrar, no existe cliente con ese ID." });
                return respuesta;
            }
            _dbContext.Clientes.Remove(cliente);
            try
            {
                Save();
            }
            catch
            {

            }
             
            respuesta = respuesta.Concat(new[] { "Eliminación de cliente exitosa." });
            return respuesta;

        }

        public Cliente GetClienteByID(string ClienteID)
        {
            return _dbContext.Clientes.Find(ClienteID);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _dbContext.Clientes.ToList();
        }

        public IEnumerable<String> InsertCliente(Cliente Cliente)
        {
            IEnumerable<String> respuesta = Enumerable.Empty<String>();
            _dbContext.Add(Cliente);
            try
            {
                Save();
            }
            catch (DbUpdateException)
            {
                if (CLienteExists(Cliente.Idcliente))
                {
                    respuesta = respuesta.Concat(new[] { "Error al insertar, ya existe cliente con ese ID." });
                    return respuesta;
                }
                else
                {
                    throw;
                }
            }
            respuesta = respuesta.Concat(new[] { "Inserción de cliente exitosa." });
            return respuesta;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
            
        }

        public IEnumerable<String> UpdateCliente(string id,Cliente Cliente)
        {
            Cliente.Idcliente = id;
            IEnumerable<String> respuesta = Enumerable.Empty<String>();
            _dbContext.Update(Cliente);
            _dbContext.Entry(Cliente).State = EntityState.Modified;
            try
            {
                Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLienteExists(Cliente.Idcliente))
                {
                    respuesta = respuesta.Concat(new[] { "Error al actualizar cliente, no exite cliente con ese ID." });
                    return respuesta;
                }
                else
                {
                    throw;
                }
            }
            catch (DbUpdateException)
            {
                if (CLienteExists(Cliente.Idcliente))
                {
                    respuesta = respuesta.Concat(new[] { "Error al actualizar, ya existe cliente con ese ID." });
                    return respuesta;
                }
                else
                {
                    throw;
                }
            }
            respuesta = respuesta.Concat(new[] { "Actualización de cliente exitosa." });
            return respuesta;
        }

        private bool CLienteExists(String ClienteID)
        {
            return _dbContext.Clientes.Count(e => e.Idcliente == ClienteID) > 0;
        }
    }
}
