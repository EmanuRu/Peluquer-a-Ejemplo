using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Reservas
{//metodos query del reserva
 //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ReservasQueryRepository : IReservaQueryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReservasQueryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Reserva>> BuscarReservaID(int id)
        {
            try
            {
                var res = await _context.Reservas.Where(r => r.Visible == true && r.IdReserva == id).Select(r => new ReservaDTO
                {
                    IdReserva = r.IdReserva,
                    FechaReserva = r.FechaReserva,
                    HoraReserva = r.HoraReserva,
                    IdCliente = r.IdCliente,
                    IdProfesional = r.IdProfesional,
                    IdServicio = r.IdServicio,
                    IdEstado = r.IdEstado,
                    reservaClienteDTO = new ClienteDTO
                    {
                        Nombre = r.IdClienteNavigation.Nombre,
                        Apellido = r.IdClienteNavigation.Apellido
                    },
                    reservaServicioDTO = new ServicioDTO
                    {
                        Nombre = r.IdServicioNavigation.Nombre,
                        DuracionMinutos = r.IdServicioNavigation.DuracionMinutos
                    },
                    reservaProfecionalDTO = new ProfesionalDTO
                    {
                        Nombre = r.IdProfesionalNavigation.Nombre,
                        Apellido = r.IdProfesionalNavigation.Apellido
                    },
                    reservaEstadoReservaDTO = new EstadoReservaDTO
                    {
                        NombreEstado = r.IdEstadoNavigation.NombreEstado
                    }
                }).ToListAsync();

                if (res == null)
                {
                    throw new Exception("No se encontraron reservas con el id " + id);
                }
                return _mapper.Map<List<Reserva>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Reserva>> BuscarReservaProf(int id)//busca reservas de un profesional en especifico
        {
            try
            {
                var res = await _context.Reservas.Where(r => r.Visible == true && r.IdProfesional == id)
                    .Select(r => new ReservaDTO
                    {
                        IdReserva = r.IdReserva,
                        FechaReserva = r.FechaReserva,
                        HoraReserva = r.HoraReserva,
                        IdCliente = r.IdCliente,
                        IdProfesional = r.IdProfesional,
                        IdServicio = r.IdServicio,
                        IdEstado = r.IdEstado,
                        reservaClienteDTO = new ClienteDTO
                        {
                            Nombre = r.IdClienteNavigation.Nombre,
                            Apellido = r.IdClienteNavigation.Apellido
                        },
                        reservaServicioDTO = new ServicioDTO
                        {
                            Nombre = r.IdServicioNavigation.Nombre,
                            DuracionMinutos = r.IdServicioNavigation.DuracionMinutos
                        },
                        reservaProfecionalDTO = new ProfesionalDTO
                        {
                            Nombre = r.IdProfesionalNavigation.Nombre,
                            Apellido = r.IdProfesionalNavigation.Apellido
                        },
                        reservaEstadoReservaDTO = new EstadoReservaDTO
                        {
                            NombreEstado = r.IdEstadoNavigation.NombreEstado
                        }
                    }).ToListAsync();

                if (res == null)
                {
                    throw new Exception("No se encontraron las reservas realizados por el profesional con el id " + id);
                }
                return _mapper.Map<List<Reserva>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Reserva>> ListarReservas()
        {
            try
            {
                var res = await _context.Reservas
                    .Where(r => r.Visible == true)
                    .Select(r => new ReservaDTO
                    {
                        IdReserva = r.IdReserva,
                        FechaReserva = r.FechaReserva,
                        HoraReserva = r.HoraReserva,
                        IdCliente = r.IdCliente,
                        IdProfesional = r.IdProfesional,
                        IdServicio = r.IdServicio,
                        IdEstado = r.IdEstado,
                        reservaClienteDTO = new ClienteDTO
                        {
                            Nombre = r.IdClienteNavigation.Nombre,
                            Apellido = r.IdClienteNavigation.Apellido
                        },
                        reservaServicioDTO = new ServicioDTO
                        {
                            Nombre = r.IdServicioNavigation.Nombre,
                            DuracionMinutos = r.IdServicioNavigation.DuracionMinutos
                        },
                        reservaProfecionalDTO = new ProfesionalDTO
                        {
                            Nombre = r.IdProfesionalNavigation.Nombre,
                            Apellido = r.IdProfesionalNavigation.Apellido
                        },
                        reservaEstadoReservaDTO = new EstadoReservaDTO
                        {
                            NombreEstado = r.IdEstadoNavigation.NombreEstado
                        }
                    })
                    .ToListAsync();

                if (res == null)
                {
                    throw new Exception("No se encontraron las reservas");
                }
                return _mapper.Map<List<Reserva>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<bool> ReservaRepetida(ReservaDTO nuevaReserva)//corrobora que no se repita una reserva
        {

            var servicio = await _context.Servicios
            .FirstOrDefaultAsync(s => s.IdServicio == nuevaReserva.IdServicio);//se busca el servicio de la reserva

            if (servicio == null)
                throw new Exception("El servicio no existe.");

            var horaInicio = nuevaReserva.HoraReserva;
            var horaFin = horaInicio.Add(TimeSpan.FromMinutes(servicio.DuracionMinutos));//se guarda las horas de la reserva


            var reservas = await _context.Reservas
                .Include(r => r.IdServicioNavigation)
                .Where(r => r.IdProfesional == nuevaReserva.IdProfesional
                         && r.FechaReserva == nuevaReserva.FechaReserva)
                .ToListAsync();//se busca un profesional que trabaje en la fecha de nuevareseva


            //se verifica si en las reserva del profesional en esa fecha nuevareserva se encuentra en el horario
            //de una reserva ya existente de confirmarse se envia un true 
            var existeSolapamiento = reservas.Any(r =>
            {
                var reservaFin = r.HoraReserva.Add(TimeSpan.FromMinutes(r.IdServicioNavigation.DuracionMinutos));
                return (horaInicio >= r.HoraReserva && horaInicio < reservaFin)
                    || (horaFin > r.HoraReserva && horaFin <= reservaFin)
                    || (r.HoraReserva >= horaInicio && r.HoraReserva < horaFin);
            });

            if (nuevaReserva.IdReserva != 0)// si el id es distinto a 0 significa que se esta editando una reserva 
            {
                bool reservaRepetida = reservas.Any(r => r.IdReserva == nuevaReserva.IdReserva);

                if (existeSolapamiento && reservaRepetida)
                {
                    return false;
                }
            }
            return existeSolapamiento;



        }
    }
}
