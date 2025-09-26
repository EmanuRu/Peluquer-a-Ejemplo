using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuAgregarEstadoRes;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuBuscarEstadoResID;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuBuscarEstadoResNom;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Querys.CuListarEstadoRes;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuEditarEstadoRes;
using Peluqueria.Aplicacion.CasosDeUso.EstadosReservas.Commands.CuEliminarEstadoRes;
using Peluqueria.Aplicacion.Data.ModelsDTO;

namespace Peluqueria.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoReservaController : ControllerBase
    {//Controller para la distintas operaciones del EstadoReserva
        private readonly IMediator _mediator;

        public EstadoReservaController(IMediator mediator)
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
                var listaERes = await _mediator.Send(new ListarEstadoRes());
                if (listaERes.Count <= 0)
                {
                    return NotFound();
                }
                else { return Ok(listaERes); }
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
                var ERes = await _mediator.Send(new BuscarEstadoResID(id));
                if (ERes == null)
                {
                    return NotFound();
                }
                else { return Ok(ERes); }
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
                var ERes = await _mediator.Send(new BuscarEstadoResNom(nombre));
                if (ERes == null)
                {
                    return NotFound();
                }
                else { return Ok(ERes); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEstadoReservas([FromBody] EstadoReservaDTO EstadoReservas)

        {

            try
            {
                var ERes = await _mediator.Send(new AgregarERes(EstadoReservas));
                if (ERes == null)
                {
                    return NotFound("No se pudo agregar el EstadoReserva");
                }
                else
                {
                    return CreatedAtAction(nameof(BuscarID), new { id = ERes.IdEstado }, ERes);
                    //return Ok("Se creo el EstadoReserva " + EstadoReservas.NombreEstado);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EdtarEstadoReserva([FromBody] EstadoReservaDTO EstadoReserva)
        {
            try
            {
                var ERes = await _mediator.Send(new EditarEstadoRes(EstadoReserva));
                if (ERes == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ERes);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEstadoReserva(int id)
        {
            try
            {
                var ERes = await _mediator.Send(new EliminarEstadoRes(id));
                if (!ERes)
                {
                    return NotFound("No se pudo eliminar el Estado de reserva");
                }
                else
                {
                    return Ok("se elimino el Estado de reserva con exito");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }
    }
}
