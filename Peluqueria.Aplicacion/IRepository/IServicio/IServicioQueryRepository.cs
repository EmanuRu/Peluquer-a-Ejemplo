using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IServicio
{
    public interface IServicioQueryRepository
    {
        Task<List<Servicio>> ListarServicios();
        Task<Servicio> BuscarServicio(int id);
        Task<Servicio> BuscarServicioNombre(string nombre);
    }
}
