using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuBuscarClienteID;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuBuscarClienteNom
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarClienteNomHandler : IRequestHandler<BuscarCliNom, ClienteDTO>//inplemento BuscarCliNom de BuscarClienteNom.cs
    {
        private readonly IClienteQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarClienteNomHandler(IClienteQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de cliente y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para busca el cliente por el nombre
        public async Task<ClienteDTO> Handle(BuscarCliNom request, CancellationToken cancellationToken)
        {
            try
            {
                var cli = await _repository.BuscarClienteNombre(request.nom);//enivio el nombre del cliente
                return _mapper.Map<ClienteDTO>(cli);//mapeo el objeto Cliente de la capa dominio en uno de CLienteDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
