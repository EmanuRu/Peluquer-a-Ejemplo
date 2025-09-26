using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEditarServicio
{
    public record EditarServ(ServicioDTO serv):IRequest<ServicioDTO>;
}
