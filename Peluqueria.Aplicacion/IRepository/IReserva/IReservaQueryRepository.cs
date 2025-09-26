using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IReserva
{
    public interface IReservaQueryRepository
    {
        Task<List<Reserva>> ListarReservas();
        Task<List<Reserva>> BuscarReservaID(int id);
        Task<List<Reserva>> BuscarReservaProf(int id);
        Task<bool> ReservaRepetida(ReservaDTO res);
    }
}
