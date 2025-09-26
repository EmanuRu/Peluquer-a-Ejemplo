using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEditarServicio;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEliminarServicio
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EliminarServicioHandler:IRequestHandler<EliminarServ,bool>//inplemento EliminarServ de EliminarServicio.cs
    {
        private readonly IServicioCommandRepository _repository;

        public EliminarServicioHandler(IServicioCommandRepository repository)
        {
            //en el constructor llamo a la interfaz de Mapper
            _repository = repository;

        }

        //metodo para eliminar el servicio
        public async Task<bool> Handle(EliminarServ request, CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _repository.BorrarServicio(request.id);//envio el id del servicio
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
