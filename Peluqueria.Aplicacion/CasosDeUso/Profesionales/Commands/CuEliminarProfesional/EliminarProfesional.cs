using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuEliminarProfesional
{
    public record EliminarProf(int id):IRequest<bool>;
}
