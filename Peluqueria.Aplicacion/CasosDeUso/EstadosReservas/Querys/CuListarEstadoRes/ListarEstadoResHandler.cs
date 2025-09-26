using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuListarEstadoRes
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class ListarEstadoResHandler : IRequestHandler<ListarEstadoRes, List<EstadoReservaDTO>>//inplemento ListarEstadoRes de ListarEstadoRes.cs
    {
        private readonly IEstadoReservaQueryRepository _repository;
        private readonly IMapper _mapper;

        public ListarEstadoResHandler(IEstadoReservaQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de estadoresrva y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para listar los estados
        public async Task<List<EstadoReservaDTO>> Handle(ListarEstadoRes request, CancellationToken cancellationToken)
        {
            try
            {
                var lista = await _repository.ListarEstadoRes();//recivo la lista 
                return _mapper.Map<List<EstadoReservaDTO>>(lista);//mapeo el objeto List<EstadoReserva> de la capa dominio en uno de 
            }                                                     //List<EstadoReservaDTO> de la capa Aplicación
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
