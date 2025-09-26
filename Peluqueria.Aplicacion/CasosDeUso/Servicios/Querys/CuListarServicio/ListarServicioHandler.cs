using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuListarServicios;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicio.Querys.CuListarServicios
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class ListarServicioHandler : IRequestHandler<ListarServicio, List<ServicioDTO>>//inplemento ListarServicio de ListarServicios.cs
    {
        private readonly IServicioQueryRepository _repository;
        private readonly IMapper _mapper;

        public ListarServicioHandler(IServicioQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de servicio y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para listar servicio
        public async Task<List<ServicioDTO>> Handle(ListarServicio request, CancellationToken cancellationToken)
        {
            try 
            {
                var lista = await _repository.ListarServicios();//recivo los servicios
                return _mapper.Map<List<ServicioDTO>>(lista);//mapeo el objeto List<Servicio> de la capa dominio en uno de List<ServicioDTO> de la capa Aplicación
            } 
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
