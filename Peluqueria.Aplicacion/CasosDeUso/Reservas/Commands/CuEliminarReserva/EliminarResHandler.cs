using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEliminarReserva
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EliminarResHandler:IRequestHandler<EliminarReser,bool>//inplemento EliminarReser de EliminarRes.cs
    {
        private readonly IReservaCommandRepository _repository;
        private readonly IMapper _mapper;

        public EliminarResHandler(IReservaCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para eliminar la reserva
        public async Task<bool> Handle(EliminarReser request, CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _repository.BorrarReserva(request.id);//envio el id de la reserva
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
