using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IServicio
{
    public interface IServicioCommandRepository
    {
        Task<Dominio.Models.Servicio> CrearServicio(ServicioDTO serv);
        Task<bool> BorrarServicio(int id);
        Task<Dominio.Models.Servicio> EditarServicio(ServicioDTO serv);
    }
}
