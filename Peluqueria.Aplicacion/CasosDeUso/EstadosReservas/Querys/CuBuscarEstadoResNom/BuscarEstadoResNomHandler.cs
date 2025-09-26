using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuBuscarEstadoResNom
{
    //las distintas intefases se encuentran dentro de la carprta IRepository
    public class BuscarEstadoResNomHandler : IRequestHandler<BuscarEstadoResNom, EstadoReservaDTO>//inplemento BuscarEstadoResNom de BuscarEstadoResNom.cs
    {
        private readonly IEstadoReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarEstadoResNomHandler(IEstadoReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de estadoresrva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para buscar el estado por nombre
        public async Task<EstadoReservaDTO> Handle(BuscarEstadoResNom request, CancellationToken cancellationToken)
        {
            try
            {
                var est = await _repository.BuscarEstadoResNombre(request.nom);//envio el nombre del estado
                return _mapper.Map<EstadoReservaDTO>(est);//mapeo el objeto EstadoReserva de la capa dominio en uno de EstadoReservaDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
