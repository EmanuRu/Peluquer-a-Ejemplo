using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEditarCliente;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEliminarCliente
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EliminarClienteHandler:IRequestHandler<EliminarCli,bool>//inplemento EliminarCli de EliminarCliente.cs
    {
        private readonly IClienteCommandRepository _repository;

        public EliminarClienteHandler(IClienteCommandRepository repository)
        {
            //en el constructor llamo a la interfaz de los comandos de cliente
            _repository = repository;

        }

        //metodo para eliminar el cliente
        public async Task<bool> Handle(EliminarCli request, CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _repository.BorrarCliente(request.id);//envio el id del cliente a eliminar
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
