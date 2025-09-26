using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuBuscarClienteNom
{
    public record BuscarCliNom(string nom):IRequest<ClienteDTO>;
}
