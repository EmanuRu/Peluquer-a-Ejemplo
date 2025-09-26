using MediatR;
using Microsoft.AspNetCore.Mvc;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Commands.CuAgregarCliente;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuBuscarClienteID;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuBuscarClienteNom;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuListarClientes;
using Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEditarCliente;
using Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEliminarCliente;
using Peluqueria.Aplicacion.Data.ModelsDTO;

namespace Peluqueria.Controller
{ //Controller para la distintas operaciones del cliente
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //los distintos metodos cuentan con nombres representativos de su propia accion
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                //todos los metodos dentro de _mediator.Send se encuentran dentro de Peluqueria.Aplicacion allí esta la carpeta CasosDeUso 
                //dentro estan distintas carpeta pertenecientes a cada uno de los componentes razor dentro de Pages, en ellas,
                //separadas por carpeta de Commands y Querys, se encuentra los distintos casos de uso que son llamados por estos metodos
                var listaCli = await _mediator.Send(new ListarCliente());
                if (listaCli.Count <= 0)
                {
                    return NotFound();
                }
                else { return Ok(listaCli); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> BuscarID(int id)
        {
            try
            {
                var Cli = await _mediator.Send(new BuscarCliID(id));
                if (Cli==null)
                {
                    return NotFound();
                }
                else { return Ok(Cli); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpGet("nombre")]
        public async Task<IActionResult> BuscarNom(string nombre)
        {
            try
            {
                var Cli = await _mediator.Send(new BuscarCliNom(nombre));
                if (Cli == null)
                {
                    return NotFound();
                }
                else { return Ok(Cli); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarClientes([FromBody] ClienteDTO clientes)

        {

            try
            {
                var cli = await _mediator.Send(new AgregarCli(clientes));
                if (cli ==null)
                {
                    return NotFound("No se pudo agregar el cliente");
                }
                else
                {
                    var c = CreatedAtAction(nameof(BuscarID), new { id = cli.IdCliente }, cli);

                    var clienteDevuelto = c.Value as ClienteDTO;
                    return c;
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EdtarCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                var cli = await _mediator.Send(new EditarCli(cliente));
                if (cli == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(cli);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            try
            {
                var cli = await _mediator.Send(new EliminarCli(id));
                if (!cli)
                {
                    return NotFound("No se pudo eliminar el cliente");
                }
                else
                {
                    return Ok("se elimino el cliente con exito");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }
    }
}
