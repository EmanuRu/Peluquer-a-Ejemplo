using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using Peluqueria.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.EstadoReserva
{//metodos query del estadoreserva
//los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class EstadoReservaQueryRepository:IEstadoReservaQueryRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EstadoReservaQueryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Dominio.Models.EstadoReserva> BuscarEstadoRes(int id)
        {
            try
            {
                var ERes = await _context.EstadoReservas.Where(e => e.IdEstado == id && e.Visible == true).FirstOrDefaultAsync();
                if (ERes == null)
                {
                    throw new Exception("No se encontro el Estado de reserva con el id " + id);
                }
                return _mapper.Map<Dominio.Models.EstadoReserva>(ERes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Dominio.Models.EstadoReserva> BuscarEstadoResNombre(string nombre)
        {
            try
            {
                var ERes = await _context.EstadoReservas.Where(e => e.NombreEstado.Contains(nombre) &&
                e.Visible == true).FirstOrDefaultAsync();
                if (ERes == null)
                {
                    throw new Exception("No se encontro el Estado de reserva con el nombre " + nombre);
                }
                return _mapper.Map<Dominio.Models.EstadoReserva>(ERes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Dominio.Models.EstadoReserva>> ListarEstadoRes()
        {
            try
            {
                var ERes = await _context.EstadoReservas.Where(e => e.Visible == true).ToListAsync();
                if (ERes == null)
                {
                    throw new Exception("No se encontraron los Estados de reservas");
                }
                return _mapper.Map<List<Dominio.Models.EstadoReserva>>(ERes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
