using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEliminarServicio
{
    public record EliminarServ(int id):IRequest<bool>;
}
