using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Cliente.Commands.CuAgregarCliente
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class AgregarClienteHandler:IRequestHandler<AgregarCli,ClienteDTO> //inplemento agregarCli de AgregarCliente.cs
    {
        private readonly IClienteCommandRepository _repository;
        private readonly IMapper _mapper;

        public AgregarClienteHandler(IClienteCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de cliente y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para agregar cliente
        public async Task<ClienteDTO> Handle(AgregarCli request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _repository.CrearCliente(request.cli);//le envio el objeto cli del tipo ClienteDTO
                return _mapper.Map<ClienteDTO>(cliente);//mapeo el objeto Cliente de la capa dominio en uno de CLienteDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
