using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuAgregarReserva
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class AgregarResHandler:IRequestHandler<AgregarReser,bool>//inplemento AgregarReser de AgregarRes.cs
    {
        private readonly IReservaCommandRepository _repository;
        private readonly IMapper _mapper;

        public AgregarResHandler(IReservaCommandRepository repository, IMapper mapper)
        {//en el constructor llamo a la interfaz de los comandos de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para agregar una reserva
        public async Task<bool> Handle(AgregarReser request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _repository.CrearReserva(request.r);//evio el objeto r del tipo ReservaDTO
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
