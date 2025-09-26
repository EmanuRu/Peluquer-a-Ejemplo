using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuListarReservas
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class ListarResHandler:IRequestHandler<ListarReserv,List<ReservaDTO>>//inplemento ListarReserv de ListarRes.cs
    {
        private readonly IReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public ListarResHandler(IReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para listar las reservas
        public async Task<List<ReservaDTO>> Handle(ListarReserv request, CancellationToken cancellationToken)
        {
            try
            {
                var lista = await _repository.ListarReservas();//recivo las reserva
                return _mapper.Map<List<ReservaDTO>>(lista);//mapeo el objeto List<Reserva> de la capa dominio en uno de List<ReservaDTO> de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
