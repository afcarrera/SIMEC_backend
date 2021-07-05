using app.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    interface IFacturaRepository
    {
        IEnumerable<Factura> GetFacturas();

        Factura GetFacturaByID(int FacturaID);

        String InsertFactura(Factura Factura);

        String DeleteFactura(int FacturaID);

        String UpdateFactura(int id, Factura Factura);

        void Save();
    }
}
