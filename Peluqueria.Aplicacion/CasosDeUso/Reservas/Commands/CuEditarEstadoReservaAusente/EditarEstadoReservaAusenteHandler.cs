using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEditarEstadoReservaAusente
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EditarEstadoReservaAusenteHandler : IRequestHandler<EditarEstadoReserAusente,bool>//inplemento EditarEstadoReserAusente de EditarEstadoReservaAusete.cs
    {
        private readonly IReservaCommandRepository _repository;
        private readonly IMapper _mapper;

        public EditarEstadoReservaAusenteHandler(IReservaCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }
        //metodo para editar el estado de reserva a ausente (esta accion se realiza sola al entrar en Reserva.razor)
        public async Task<bool> Handle(EditarEstadoReserAusente request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _repository.EditarEstadoReservaAusemte(request.id);//envio el id
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
