using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuAgregarServicio
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class AgregarServicioHandler:IRequestHandler<AgregarServ,ServicioDTO>//inplemento AgregarServ de AgregarServicio.cs
    {
        private readonly IServicioCommandRepository _repository;
        private readonly IMapper _mapper;

        public AgregarServicioHandler(IServicioCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de servicio y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para agregar un servicio
        public async Task<ServicioDTO> Handle(AgregarServ request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _repository.CrearServicio(request.serv);//le envio el objeto serv del tipo ServicioDTO
                return _mapper.Map<ServicioDTO>(resultado);//mapeo el objeto Servico de la capa dominio en uno de ServicioDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
