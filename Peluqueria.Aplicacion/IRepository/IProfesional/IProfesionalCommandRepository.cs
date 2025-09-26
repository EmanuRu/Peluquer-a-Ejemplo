using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IProfesional
{
    public interface IProfesionalCommandRepository
    {
        Task<Profesional> CrearProfesional(ProfesionalDTO cli);
        Task<bool> BorrarProfesional(int id);
        Task<Profesional> EditarProfesional(ProfesionalDTO cli);
    }
}
