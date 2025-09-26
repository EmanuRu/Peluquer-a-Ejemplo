using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IClientes;
using Peluqueria.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Cliente
{    //metodos query del cliente
    //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ClienteQueryRepository : IClienteQueryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClienteQueryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Dominio.Models.Cliente> BuscarCliente(int id)
        {
            try 
            {
                var cli = await _context.Clientes.Where(c=>c.IdCliente==id && c.Visible==true).FirstOrDefaultAsync();
                if(cli == null) 
                {
                    throw new Exception("No se encontro el cliente con el id "+id);
                }
                return _mapper.Map<Dominio.Models.Cliente>(cli);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Dominio.Models.Cliente> BuscarClienteNombre(string nombre)
        {
            try
            {
                var cli = await _context.Clientes.Where(c => (c.Nombre.Contains(nombre)||c.Apellido.Contains(nombre))&&
                c.Visible==true).FirstOrDefaultAsync();
                if (cli == null)
                {
                    throw new Exception("No se encontro el cliente con el nombre " + nombre);
                }
                return _mapper.Map<Dominio.Models.Cliente>(cli);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Dominio.Models.Cliente>> ListarClientes()
        {
            try
            {
                var cli = await _context.Clientes.Where(c=>c.Visible==true).ToListAsync();
                if (cli == null)
                {
                    throw new Exception("No se encontraron los cliente");
                }
                return _mapper.Map<List<Dominio.Models.Cliente>>(cli);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
