using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEditarServicio
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EditarServicioHandler:IRequestHandler<EditarServ,ServicioDTO>//inplemento EditarServ de EditarServicio.cs
    {
        private readonly IServicioCommandRepository _repository;
        private readonly IMapper _mapper;

        public EditarServicioHandler(IServicioCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de servicio y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para editar el servicio
        public async Task<ServicioDTO> Handle(EditarServ request, CancellationToken cancellationToken)
        {
            try
            {
                var Servicio = await _repository.EditarServicio(request.serv);//le envio el objeto serv del tipo ServicioDTO
                return _mapper.Map<ServicioDTO>(Servicio);//mapeo el objeto Servico de la capa dominio en uno de ServicioDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
