using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuBuscarServicioID
{
    public record BuscarServID(int id):IRequest<ServicioDTO>;
}
