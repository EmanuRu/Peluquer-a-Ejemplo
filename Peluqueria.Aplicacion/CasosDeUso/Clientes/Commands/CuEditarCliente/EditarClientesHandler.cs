using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEditarCliente
{
    public class EditarClienteHandler:IRequestHandler<EditarCli,ClienteDTO>//inplemento EditarCli de EditarCliente.cs
    {
        //las distintas intefases se encuentran dentro de la carpeta IRepository
        private readonly IClienteCommandRepository _repository;
        private readonly IMapper _mapper;

        public EditarClienteHandler(IClienteCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de cliente y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para editar el cliente
        public async Task<ClienteDTO> Handle(EditarCli request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _repository.EditarCliente(request.cli);//le envio el objeto cli del tipo ClienteDTO
                return _mapper.Map<ClienteDTO>(cliente);//mapeo el objeto Cliente de la capa dominio en uno de CLienteDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
