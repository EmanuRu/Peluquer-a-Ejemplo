using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuListarClientes
{
    public class ListarClienteHandler : IRequestHandler<ListarCliente, List<ClienteDTO>>//inplemento ListarCliente de ListarClientes.cs
    {
        //las distintas intefases se encuentran dentro de la carpeta IRepository
        private readonly IClienteQueryRepository _repository;
        private readonly IMapper _mapper;

        public ListarClienteHandler(IClienteQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de cliente y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para listar clientes
        public async Task<List<ClienteDTO>> Handle(ListarCliente request, CancellationToken cancellationToken)
        {
            try 
            {
                var lista = await _repository.ListarClientes();//recivo los clientes
                return _mapper.Map<List<ClienteDTO>>(lista);//mapeo el objeto List<Cliente> de la capa dominio en uno de List<CLienteDTO> de la capa Aplicación
            } 
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}
