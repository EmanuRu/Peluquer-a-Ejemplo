using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IClientes
{
    public interface IClienteCommandRepository
    {
        Task<Cliente> CrearCliente(ClienteDTO cli);
        Task<bool> BorrarCliente(int id);
        Task<Dominio.Models.Cliente> EditarCliente(ClienteDTO cli);
    }
}
