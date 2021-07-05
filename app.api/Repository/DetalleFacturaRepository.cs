using app.api.DbContexts;
using app.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly SIMECContext _dbContext;
        public DetalleFacturaRepository(SIMECContext dbContext)
        {
            _dbContext = dbContext;
        }
        public String DeleteDetallefactura(int DetallefacturaID)
        {
            var Detallefactura = _dbContext.Detallefacturas.Find(DetallefacturaID);
            if (Detallefactura == null)
            {
                return "Error al eliminar.";
            }
            _dbContext.Detallefacturas.Remove(Detallefactura);
            Save();
            return "Eliminación exitosa.";
        }

        public Detallefactura GetDetallefacturaByID(int DetallefacturaID)
        {
            return _dbContext.Detallefacturas.Find(DetallefacturaID);
        }

        public IEnumerable<Detallefactura> GetDetallefacturas()
        {
            return _dbContext.Detallefacturas.ToList();
        }

        public String InsertDetallefactura(Detallefactura Detallefactura)
        {
            _dbContext.Add(Detallefactura);
            try
            {
                Save();
            }
            catch (DbUpdateException)
            {
                if (DetallefacturaExists(Detallefactura.Iddetalle))
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

        public String UpdateDetallefactura(int id,Detallefactura Detallefactura)
        {
            Detallefactura.Iddetalle = id;
            _dbContext.Update(Detallefactura);
            _dbContext.Entry(Detallefactura).State = EntityState.Modified;
            try
            {
                Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallefacturaExists(Detallefactura.Iddetalle))
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
        private bool DetallefacturaExists(int DetallefacturaID)
        {
            return _dbContext.Detallefacturas.Count(e => e.Iddetalle == DetallefacturaID) > 0;
        }
    }
}
