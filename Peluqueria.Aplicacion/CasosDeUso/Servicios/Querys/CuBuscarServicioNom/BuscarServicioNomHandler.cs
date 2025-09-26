using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuBuscarServicioNom;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicio.Querys.CuBuscarServicioNom
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarServicioNomHandler : IRequestHandler<BuscarServNom, ServicioDTO>//inplemento BuscarServNom de BuscarServicioNom.cs
    {
        private readonly IServicioQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarServicioNomHandler(IServicioQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de servicio y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para buscar un servicio por su nombre
        public async Task<ServicioDTO> Handle(BuscarServNom request, CancellationToken cancellationToken)
        {
            try
            {
                var serv = await _repository.BuscarServicioNombre(request.nom);//envio el nombre
                return _mapper.Map<ServicioDTO>(serv); ;//mapeo el objeto Servicio de la capa dominio en uno de ServicioDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
