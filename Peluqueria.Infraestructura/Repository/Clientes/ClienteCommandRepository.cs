using AutoMapper;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data;
using Peluqueria.Infraestructura.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Clientes
{
    //metodos command del cliente
    //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ClienteCommandRepository : IClienteCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClienteCommandRepository(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> BorrarCliente(int id)
        {
            try
            {
                var cli = await _context.Clientes.FindAsync(id);
                if (cli == null)
                {
                    throw new Exception($"No se encontró un cliente con id {id}");
                }
                cli.Visible= false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Dominio.Models.Cliente> CrearCliente(ClienteDTO cli)
        {
            try 
            {
                var clienteDominio = _mapper.Map<Dominio.Models.Cliente>(cli);
                var clienteEntity = _mapper.Map<ClienteEntity>(clienteDominio);
                _context.Clientes.Add(clienteEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<Dominio.Models.Cliente>(clienteEntity);
            }
            catch (Exception ex) 
            { 
                throw new Exception( ex.Message+" INTERNAS: "+ex.InnerException); 
            }
        }

        public async Task<Dominio.Models.Cliente> EditarCliente(ClienteDTO cli)
        {
            try 
            {
                var clienteDominio = _mapper.Map<Dominio.Models.Cliente>(cli);
                var clienteEntity = _mapper.Map<ClienteEntity>(clienteDominio);
                var modificar = await _context.Clientes.FindAsync(clienteEntity.IdCliente);
                if (modificar == null)
                {
                    throw new Exception($"No se encontró un cliente con id {clienteEntity.IdCliente}");
                }
                modificar.Nombre= clienteEntity.Nombre;
                modificar.Apellido= clienteEntity.Apellido;
                modificar.FechaRegistro= clienteEntity.FechaRegistro;
                await _context.SaveChangesAsync();
                return _mapper.Map<Dominio.Models.Cliente>(modificar);

            } 
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }
    }
}
