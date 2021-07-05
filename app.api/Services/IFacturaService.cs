using app.api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    interface IFacturaService
    {
        IEnumerable<FacturaDTO> GetFacturas();

        FacturaDTO GetFacturaByID(int FacturaID);

        String InsertFactura(FacturaDTO Factura);

        String DeleteFactura(int FacturaID);

        String UpdateFactura(int id, FacturaDTO Factura);
    }
}
