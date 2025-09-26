using MediatR;
using Microsoft.AspNetCore.Mvc;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuAgregarProfesional;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuEditarProfesional;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuEliminarProfesional;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuBuscarProfesionalID;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuBuscarProfesionalNom;
using Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuListarProfesional;
using Peluqueria.Aplicacion.Data.ModelsDTO;

namespace Peluqueria.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionalController : ControllerBase
    {//Controller para la distintas operaciones del profesional
        private readonly IMediator _mediator;

        public ProfesionalController(IMediator mediator)
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
                var listaProf = await _mediator.Send(new ListarProf());
                if (listaProf.Count <= 0)
                {
                    return NotFound();
                }
                else { return Ok(listaProf); }
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
                var Cli = await _mediator.Send(new BuscarProfID(id));
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

        [HttpGet("nombre")]
        public async Task<IActionResult> BuscarNom(string nombre)
        {
            try
            {
                var Cli = await _mediator.Send(new BuscarProfNom(nombre));
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
        public async Task<IActionResult> AgregarProfesional([FromBody] ProfesionalDTO profesional)

        {

            try
            {
                var prof = await _mediator.Send(new AgregarProf(profesional));
                if (prof == null)
                {
                    return NotFound("No se pudo agregar el profesional");
                }
                else
                {
                    return CreatedAtAction(nameof(BuscarID), new { id = prof.IdProfesional }, prof);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EdtarProfesional([FromBody] ProfesionalDTO Profesional)
        {
            try
            {
                var prof = await _mediator.Send(new Editarprof(Profesional));
                if (prof == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(prof);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProfesional(int id)
        {
            try
            {
                var prof = await _mediator.Send(new EliminarProf(id));
                if (!prof)
                {
                    return NotFound("No se pudo eliminar el profesional");
                }
                else
                {
                    return Ok("se elimino el profesional con exito");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Ocurrió un error inesperado: {ex.Message}" });
            }
        }
    }
}
