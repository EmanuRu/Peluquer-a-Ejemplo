using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuBuscarReservaID
{
    public record BuscarReservID(int id):IRequest<List<ReservaDTO>>;
}
