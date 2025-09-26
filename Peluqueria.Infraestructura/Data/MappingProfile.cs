using AutoMapper;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Data
{//mapedo entre las clases de Dominio y las clase de infraestructura
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        { 
            CreateMap<ClienteEntity,Cliente>().ForMember(dm=>dm.clienteReserva, mp=>mp.MapFrom(src=>src.Reservas)).ReverseMap();

            CreateMap<EstadoReservaEntity, EstadoReserva>().ForMember(dm => dm.reservas, mp => mp.MapFrom(src => src.Reservas)).ReverseMap();

            CreateMap<ProfesionalEntity, Profesional>().ForMember(dm => dm.reservasProfesional, mp => mp.MapFrom(src => src.Reservas)).ReverseMap();

            CreateMap<ReservaEntity, Reserva>()
                .ForMember(dm => dm.reservaCliente, mp => mp.MapFrom(src => src.IdClienteNavigation))
                .ForMember(dm => dm.reservaProfecional, mp => mp.MapFrom(src => src.IdProfesionalNavigation))
                .ForMember(dm => dm.reservaEstadoReserva, mp => mp.MapFrom(src => src.IdEstadoNavigation))
                .ForMember(dm => dm.reservaServicio, mp => mp.MapFrom(src => src.IdServicioNavigation))
                .ReverseMap();


            CreateMap<ServicioEntity, Servicio>().ForMember(dm => dm.servicioReservas, mp => mp.MapFrom(src => src.Reservas)).ReverseMap();
        }
    }
}
