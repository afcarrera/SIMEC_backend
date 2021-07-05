using app.api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Services
{
    public interface IDetalleFacturaService
    {
        IEnumerable<DetallefacturaDTO> GetDetallefacturas();

        DetallefacturaDTO GetDetallefacturaByID(int DetallefacturaID);

        String InsertDetallefactura(DetallefacturaDTO Detallefactura);

        String DeleteDetallefactura(int DetallefacturaID);

        String UpdateDetallefactura(int id, DetallefacturaDTO Detallefactura);
    }
}
