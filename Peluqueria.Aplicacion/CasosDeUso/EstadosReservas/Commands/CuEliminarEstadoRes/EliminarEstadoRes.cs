using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuEliminarEstadoRes
{
    public record EliminarEstadoRes(int id) : IRequest<bool>;
}
