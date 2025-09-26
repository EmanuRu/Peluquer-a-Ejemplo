using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IEstadoReserva
{
    public interface IEstadoReservaQueryRepository
    {
        Task<List<EstadoReserva>> ListarEstadoRes();
        Task<EstadoReserva> BuscarEstadoRes(int id);
        Task<EstadoReserva> BuscarEstadoResNombre(string nombre);
    }
}
