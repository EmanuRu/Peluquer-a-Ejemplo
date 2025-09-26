using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuBuscarReservaProfesional
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarResProfHandler:IRequestHandler<BuscarReservProf,List<ReservaDTO>>//inplemento BuscarReservProf de BuscarResProf.cs
    {
        private readonly IReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarResProfHandler(IReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de reserva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para buscar las reserva por id del profesional
        public async Task<List<ReservaDTO>> Handle(BuscarReservProf request, CancellationToken cancellationToken)
        {
            try
            {
                var lista = await _repository.BuscarReservaProf(request.id);//evio el id del profesional
                return _mapper.Map<List<ReservaDTO>>(lista);//mapeo el objeto List<Reserva> de la capa dominio en uno de List<ReservaDTO> de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
