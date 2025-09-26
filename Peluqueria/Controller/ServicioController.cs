using MediatR;
using Microsoft.AspNetCore.Mvc;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuAgregarServicio;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuBuscarServicioID;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuBuscarServicioNom;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Querys.CuListarServicios;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEditarServicio;
using Peluqueria.Aplicacion.CasosDeUso.Servicios.Commands.CuEliminarServicio;
using Peluqueria.Aplicacion.Data.ModelsDTO;

namespace Peluqueria.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {//Controller para la distintas operaciones de Servicio

        private readonly IMediator _mediator;

        public ServicioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //los distintos metodos cuentan con nombres representativos de su propia accion
        [HttpGet]
        //todos los metodos dentro de _mediator.Send se encuentran dentro de Peluqueria.Aplicacion allí esta la carpeta CasosDeUso 
        //dentro estan distintas carpeta pertenecientes a cada uno de los componentes razor dentro de Pages, en ellas,
        //separadas por carpeta de Commands y Querys, se encuentra los distintos casos de uso que son llamados por estos metodos
        public async Task<IActionResult> Listar()
        {
            try
            {
                var listaServ = await _mediator.Send(new ListarServicio());
                if (listaServ.Count <= 0)
                {
                    return NotFound();
                }
                else { return Ok(listaServ); }
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
                var Serv = await _mediator.Send(new BuscarServID(id));
                if (Serv == null)
                {
                    return NotFound();
                }
                else { return Ok(Serv); }
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
                var Serv = await _mediator.Send(new BuscarServNom(nombre));
                if (Serv == null)
                {
                    return NotFound();
                }
                else { return Ok(Serv); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarServicios([FromBody] ServicioDTO Servicios)

        {

            try
            {
                var Serv = await _mediator.Send(new AgregarServ(Servicios));
                if (Serv == null)
                {
                    return NotFound("No se pudo agregar el Servicio");
                }
                else
                {
                    return CreatedAtAction(nameof(BuscarID), new { id = Serv.IdServicio }, Serv);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EdtarServicio([FromBody] ServicioDTO Servicio)
        {
            try
            {
                var Serv = await _mediator.Send(new EditarServ(Servicio));
                if (Serv == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Serv);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarServicio(int id)
        {
            try
            {
                var Serv = await _mediator.Send(new EliminarServ(id));
                if (!Serv)
                {
                    return NotFound("No se pudo eliminar el Servicio");
                }
                else
                {
                    return Ok("se elimino el Servicio con exito");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }
    }
}
