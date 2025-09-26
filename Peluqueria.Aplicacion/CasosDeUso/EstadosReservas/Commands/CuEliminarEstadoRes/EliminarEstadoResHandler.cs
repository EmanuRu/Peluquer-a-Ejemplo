using MediatR;
using Peluqueria.Aplicacion.IRepository.IEstadoReserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuEliminarEstadoRes
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EliminarEstadoResHandler:IRequestHandler<EliminarEstadoRes,bool>//inplemento EliminarEstadoRes de EliminarEstadoRes.cs
    {
        private readonly IEstadoReservaCommandRepository _repository;

        public EliminarEstadoResHandler(IEstadoReservaCommandRepository repository)
        {
            //en el constructor llamo a la interfaz de Mapper
            _repository = repository;

        }

        //metodo par eliminar el estado de reserva
        public async Task<bool> Handle(EliminarEstadoRes request, CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _repository.BorrarEstadoReser(request.id);//envio el id del estado a borrar
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
