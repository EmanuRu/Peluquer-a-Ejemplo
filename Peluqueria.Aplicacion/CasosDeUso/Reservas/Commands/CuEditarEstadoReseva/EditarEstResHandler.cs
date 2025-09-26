using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEditarEstadoReseva
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EditarEstResHandler : IRequestHandler<EditarEstResrv, ReservaDTO>//inplemento EditarEstResrv de EditarEstRes.cs
    {

        private readonly IReservaCommandRepository _repository;
        private readonly IMapper _mapper;

        public EditarEstResHandler(IReservaCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }
        //metodo para editar el estado de la reserva
        public async Task<ReservaDTO> Handle(EditarEstResrv request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _repository.EditarEstadoReserva(request.idReserva,request.idEst);//envio el id del estado y el objeto Res del tipo ReservaDTO
                return _mapper.Map<ReservaDTO>(res);//mapeo el objeto Reserva de la capa dominio en uno de ReservaDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
