using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuAgregarEstadoRes
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class AgregarEstadoResHandler : IRequestHandler<AgregarERes, EstadoReservaDTO>//inplemento AgregarERes de AgregarEstadoRes.cs
    {
        private readonly IEstadoReservaCommandRepository _repository;
        private readonly IMapper _mapper;

        public AgregarEstadoResHandler(IEstadoReservaCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de estadoreserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para agregar un estado de reserva
        public async Task<EstadoReservaDTO> Handle(AgregarERes request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _repository.CrearEstadoReser(request.est);//envio el bojeto est del tipo EstadoReservaDTO
                return _mapper.Map<EstadoReservaDTO>(resultado);//mapeo el objeto EstadoReseva de la capa dominio en uno de EstadoReservaDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
