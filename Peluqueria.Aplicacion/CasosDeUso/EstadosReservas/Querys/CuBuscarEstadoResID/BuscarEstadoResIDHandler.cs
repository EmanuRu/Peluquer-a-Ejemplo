using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuBuscarEstadoResID
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarEstadoResIDHandler : IRequestHandler<BuscarEstadoResID, EstadoReservaDTO>//inplemento BuscarEstadoResID de BuscarEstadoResID.cs
    {
        private readonly IEstadoReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarEstadoResIDHandler(IEstadoReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de estadoresrva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metod para buscar el estado por id
        public async Task<EstadoReservaDTO> Handle(BuscarEstadoResID request, CancellationToken cancellationToken)
        {
            try
            {
                var est = await _repository.BuscarEstadoRes(request.id);//envio el id
                return _mapper.Map<EstadoReservaDTO>(est);//mapeo el objeto EstadoReserva de la capa dominio en uno de EstadoReservaDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
