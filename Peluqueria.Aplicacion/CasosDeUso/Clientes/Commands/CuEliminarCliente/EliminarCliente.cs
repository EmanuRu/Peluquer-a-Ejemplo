using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEliminarCliente
{
    public record EliminarCli(int id):IRequest<bool>;
}
