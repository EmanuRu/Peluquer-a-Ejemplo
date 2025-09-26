using Peluqueria.Aplicacion.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.IRepository.IClientes
{
    public interface IClienteQueryRepository
    {
        Task<List<Dominio.Models.Cliente>> ListarClientes();
        Task<Dominio.Models.Cliente> BuscarCliente(int id);
        Task<Dominio.Models.Cliente> BuscarClienteNombre(string nombre);
    }
}
