using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuEditarEstadoRes
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    internal class EditarEstadoResHandler:IRequestHandler<EditarEstadoRes,EstadoReservaDTO>//inplemento EditarEstadoRes de EditarEstadoRes.cs
    {
        private readonly IEstadoReservaCommandRepository _repository;
        private readonly IMapper _mapper;

        public EditarEstadoResHandler(IEstadoReservaCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de estadoreserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para editar el estado de reserva
        public async Task<EstadoReservaDTO> Handle(EditarEstadoRes request, CancellationToken cancellationToken)
        {
            try
            {
                var estado = await _repository.EditarEstadoReser(request.est);//envio el bojeto est del tipo EstadoReservaDTO
                return _mapper.Map<EstadoReservaDTO>(estado);//mapeo el objeto EstadoReseva de la capa dominio en uno de EstadoReservaDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
