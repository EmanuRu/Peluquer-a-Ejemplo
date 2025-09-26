using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuBuscarReservaID
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarResIDHandler:IRequestHandler<BuscarReservID,List<ReservaDTO>>//inplemento BuscarReservID de BuscarResID.cs
    {
        private readonly IReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarResIDHandler(IReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para buscar las reservas por id
        public async Task<List<ReservaDTO>> Handle(BuscarReservID request, CancellationToken cancellationToken)
        {
            try
            {
                var lista = await _repository.BuscarReservaID(request.id);//evio el id
                return _mapper.Map<List<ReservaDTO>>(lista);//mapeo el objeto List<Reserva> de la capa dominio en uno de List<ReservaDTO> de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
