using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IReserva
{
    public interface IReservaCommandRepository
    {
        Task<bool> CrearReserva(ReservaDTO res);
        Task<bool> BorrarReserva(int id);
        Task<Reserva> EditarReserva(ReservaDTO res);
        Task<Reserva> EditarEstadoReserva(int idReserva, int idEstado);
        Task<bool> EditarEstadoReservaAusemte(int id);
    }
}
