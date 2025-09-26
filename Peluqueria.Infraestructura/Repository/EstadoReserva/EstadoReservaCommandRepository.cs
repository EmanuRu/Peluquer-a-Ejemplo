using AutoMapper;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using Peluqueria.Infraestructura.Data;
using Peluqueria.Infraestructura.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.EstadoReserva
{
    //metodos command del EstadoReserva
    //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class EstadoReservaCommandRepository: IEstadoReservaCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EstadoReservaCommandRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> BorrarEstadoReser(int id)
        {
            try
            {
                var ERes = await _context.EstadoReservas.FindAsync(id);
                if (ERes == null)
                {
                    throw new Exception($"No se encontró un estado de Reserva con id {id}");
                }
                ERes.Visible = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Dominio.Models.EstadoReserva> CrearEstadoReser(EstadoReservaDTO ERes)
        {
            try
            {
                var EstadoReservaDominio = _mapper.Map<Dominio.Models.EstadoReserva>(ERes);
                var EstadoReservaEntity = _mapper.Map<EstadoReservaEntity>(EstadoReservaDominio);
                _context.EstadoReservas.Add(EstadoReservaEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<Dominio.Models.EstadoReserva>(EstadoReservaEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " INTERNAS: " + ex.InnerException);
            }
        }

        public async Task<Dominio.Models.EstadoReserva> EditarEstadoReser(EstadoReservaDTO ERes)
        {
            try
            {
                var EstadoReservaDominio = _mapper.Map<Dominio.Models.EstadoReserva>(ERes);
                var EstadoReservaEntity = _mapper.Map<EstadoReservaEntity>(EstadoReservaDominio);
                var modificar = await _context.EstadoReservas.FindAsync(EstadoReservaEntity.IdEstado);
                if (modificar == null)
                {
                    throw new Exception($"No se encontró un EstadoReserva con id {EstadoReservaEntity.IdEstado}");
                }
                modificar.NombreEstado = EstadoReservaEntity.NombreEstado;
                await _context.SaveChangesAsync();
                return _mapper.Map<Dominio.Models.EstadoReserva>(modificar);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
