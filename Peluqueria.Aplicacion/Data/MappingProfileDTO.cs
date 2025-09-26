using AutoMapper;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.Data
{//mapedo entre las clases DTO de Aplicación y las clases de Dominio
    public class MappingProfileDTO:Profile
    {
        public MappingProfileDTO() 
        { 
            CreateMap<Cliente,ClienteDTO>().ForMember(dm=>dm.clienteReservaDTO, mp=>mp.MapFrom(src=>src.clienteReserva)).ReverseMap();

            CreateMap<EstadoReserva,EstadoReservaDTO>().ForMember(dm => dm.EstadoReservasDTO, mp => mp.MapFrom(src => src.reservas)).ReverseMap();

            CreateMap<Profesional,ProfesionalDTO>().ForMember(dm => dm.reservasProfesionalDTO, mp => mp.MapFrom(src => src.reservasProfesional)).ReverseMap();

            CreateMap<Reserva,ReservaDTO>().ForMember(dm => dm.reservaClienteDTO, mp => mp.MapFrom(src => src.reservaCliente))
                .ForMember(dm => dm.reservaEstadoReservaDTO, mp => mp.MapFrom(src => src.reservaEstadoReserva))
                .ForMember(dm => dm.reservaProfecionalDTO, mp => mp.MapFrom(src => src.reservaProfecional))
                .ForMember(dm => dm.reservaServicioDTO, mp => mp.MapFrom(src => src.reservaServicio)).ReverseMap();

            CreateMap<Servicio,ServicioDTO>().ForMember(dm => dm.servicioReservasDTO, mp => mp.MapFrom(src => src.servicioReservas)).ReverseMap();
        }
    }
}
