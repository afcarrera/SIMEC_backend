using app.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Repository
{
    interface IDetalleFacturaRepository
    {
        IEnumerable<Detallefactura> GetDetallefacturas();

        Detallefactura GetDetallefacturaByID(int DetallefacturaID);

        String InsertDetallefactura(Detallefactura Detallefactura);

        String DeleteDetallefactura(int DetallefacturaID);

        String UpdateDetallefactura(int id, Detallefactura Detallefactura);

        void Save();
    }
}
