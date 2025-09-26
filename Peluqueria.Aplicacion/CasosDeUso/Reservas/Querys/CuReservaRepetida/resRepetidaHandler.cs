using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuReservaTomada;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuReservaRepetida
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class resRepetidaHandler:IRequestHandler<reservRepetida,bool>//inplemento reservRepetida de resRepetida.cs
    {
        private readonly IReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public resRepetidaHandler(IReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para corroborar si una reserva esta repetidoa
        public async Task<bool> Handle(reservRepetida request, CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _repository.ReservaRepetida(request.r);//envio el objeto r del tipo reservaDTO
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
