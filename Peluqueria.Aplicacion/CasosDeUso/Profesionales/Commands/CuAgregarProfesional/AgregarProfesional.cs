using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuAgregarProfesional
{
    public record AgregarProf(ProfesionalDTO prof):IRequest<ProfesionalDTO>;
}
