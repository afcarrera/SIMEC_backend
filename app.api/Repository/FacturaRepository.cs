using app.api.DbContexts;
using app.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly SIMECContext _dbContext;
        public FacturaRepository(SIMECContext dbContext)
        {
            _dbContext = dbContext;
        }
        public String DeleteFactura(int FacturaID)
        {
            var factura = _dbContext.Facturas.Find(FacturaID);
            if (factura == null)
            {
                return "Error al eliminar.";
            }
            _dbContext.Facturas.Remove(factura);
            Save();
            return "Eliminación exitosa.";
        }

        public IEnumerable<Factura> GetFacturas()
        {
            return _dbContext.Facturas.ToList();
        }

        public Factura GetFacturaByID(int FacturaID)
        {
            return _dbContext.Facturas.Find(FacturaID);
        }

        public String InsertFactura(Factura Factura)
        {
            _dbContext.Add(Factura);
            try
            {
                Save();
            }
            catch (DbUpdateException)
            {
                if (FacturaExists(Factura.Idfactura))
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

        public String UpdateFactura(int id,Factura Factura)
        {
            Factura.Idfactura = id;
            _dbContext.Update(Factura);
            _dbContext.Entry(Factura).State = EntityState.Modified;
            try
            {
                Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(Factura.Idfactura))
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

        private bool FacturaExists(int FacturaID)
        {
            return _dbContext.Facturas.Count(e => e.Idfactura == FacturaID) > 0;
        }
    }
}
