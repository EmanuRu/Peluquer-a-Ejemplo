using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IEstadoReserva
{
    public interface IEstadoReservaCommandRepository
    {
        Task<EstadoReserva> CrearEstadoReser(EstadoReservaDTO ERes);
        Task<bool> BorrarEstadoReser(int id);
        Task<EstadoReserva> EditarEstadoReser(EstadoReservaDTO ERes);
    }
}
