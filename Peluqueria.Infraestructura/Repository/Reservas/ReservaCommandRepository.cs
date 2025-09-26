using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data;
using Peluqueria.Infraestructura.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Reservas
{
    //metodos command del reservas
    //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ReservaCommandRepository : IReservaCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReservaCommandRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> BorrarReserva(int id)
        {
            try
            {
                var res = await _context.Reservas.FindAsync(id);
                if (res == null)
                {
                    throw new Exception($"No se encontró una reserva con id {id}");
                }
                res.Visible = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CrearReserva(ReservaDTO res)
        {
            try
            {
                var reservaDominio = _mapper.Map<Reserva>(res);
                var reservaEntity = _mapper.Map<ReservaEntity>(reservaDominio);
                _context.Reservas.Add(reservaEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " INTERNAS: " + ex.InnerException);
            }
        }

        public async Task<Reserva> EditarEstadoReserva(int idReserva, int idEstado)
        {
            try
            {
                var modificar = await _context.Reservas.FindAsync(idReserva);
                if (modificar == null)
                {
                    throw new Exception($"No se encontró un reserva con id {idReserva}");
                }
                modificar.IdEstado = idEstado;
                await _context.SaveChangesAsync();
                return _mapper.Map<Reserva>(modificar);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditarEstadoReservaAusemte(int id)
        {
            try
            {
                var lista = await _context.Reservas.Where(r => r.IdEstado == 1 && r.FechaReserva < DateTime.Now && r.Visible == true).ToListAsync();
                foreach (var item in lista) 
                {
                    item.IdEstado = id;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Reserva> EditarReserva(ReservaDTO res)
        {
            try
            {
                var reservaDominio = _mapper.Map<Reserva>(res);
                var reservaEntity = _mapper.Map<ReservaEntity>(reservaDominio);
                var modificar = await _context.Reservas.FindAsync(reservaEntity.IdReserva);
                if (modificar == null)
                {
                    throw new Exception($"No se encontró un reserva con id {reservaEntity.IdReserva}");
                }
                modificar.IdServicio = reservaEntity.IdServicio;
                modificar.FechaReserva = reservaEntity.FechaReserva;
                modificar.HoraReserva = reservaEntity.HoraReserva;
                modificar.IdCliente = reservaEntity.IdCliente;
                modificar.IdProfesional= reservaEntity.IdProfesional;
                await _context.SaveChangesAsync();
                return _mapper.Map<Reserva>(modificar);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
