using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IProfesional
{
    public interface IProfesionalQueryRepository
    {
        Task<List<Profesional>> ListarProfesionales();
        Task<Profesional> Buscarprofesional(int id);
        Task<Profesional> BuscarProfesionalNombre(string nombre);
    }
}
