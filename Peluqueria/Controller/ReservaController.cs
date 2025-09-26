using MediatR;
using Microsoft.AspNetCore.Mvc;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuAgregarReserva;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuBuscarReservaID;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuBuscarReservaProfesional;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuListarReservas;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEditarReserva;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEliminarReserva;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Querys.CuReservaTomada;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEditarEstadoReseva;
using Peluqueria.Aplicacion.CasosDeUso.Reservas.Commands.CuEditarEstadoReservaAusente;

namespace Peluqueria.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {//Controller para la distintas operaciones de reserva y editarReserva

        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
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
                var listaRes = await _mediator.Send(new ListarReserv());
                if (listaRes.Count <= 0)
                {
                    return NotFound();
                }
                else { return Ok(listaRes); }
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
                var res = await _mediator.Send(new BuscarReservID(id));
                if (res == null)
                {
                    return NotFound();
                }
                else { return Ok(res); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpGet("prof")]
        public async Task<IActionResult> BuscarProf(int id)
        {
            try
            {
                var res = await _mediator.Send(new BuscarReservProf(id));
                if (res == null)
                {
                    return NotFound();
                }
                else { return Ok(res); }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPost("nuevo")]
        public async Task<IActionResult> AgregarReservas([FromBody] ReservaDTO Reservas)

        {

            try
            {
                var res = await _mediator.Send(new AgregarReser(Reservas));
                if (res == false)
                {
                    return NotFound("No se pudo agregar la Reserva");
                }
                else
                {
                    return Ok("Se creo el Reserva " + Reservas.IdReserva);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EdtarReserva([FromBody] ReservaDTO Reserva)
        {
            try
            {
                var res = await _mediator.Send(new EditarReser(Reserva));
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut("estado")]
        public async Task<IActionResult> EdtarEstado(int idReserva, int idEst)
        {
            try
            {
                
                var res = await _mediator.Send(new EditarEstResrv(idReserva, idEst));
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut("ausente")]
        public async Task<IActionResult> EdtarEstadoAusente(int id)
        {
            try
            {
                var res = await _mediator.Send(new EditarEstadoReserAusente(id));
                if (!res)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReserva(int id)
        {
            try
            {
                var res = await _mediator.Send(new EliminarReser(id));
                if (!res)
                {
                    return NotFound("No se pudo eliminar la Reserva");
                }
                else
                {
                    return Ok("se elimino la Reserva con exito");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPost("repetida")]
        public async Task<IActionResult> ReservaRepetida([FromBody] ReservaDTO Reserva)
        {
            try
            {
                var res = await _mediator.Send(new reservRepetida(Reserva));
                if (res)
                {
                    return Ok("El profesional ya cuenta con reservas");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }
    }
}
