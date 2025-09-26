using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEditarEstadoReservaAusente
{
    public record EditarEstadoReserAusente(int id):IRequest<bool>;
}
