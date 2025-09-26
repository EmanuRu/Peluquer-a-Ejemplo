using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Clientes.Commands.CuEditarCliente;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuEliminarProfesional
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EliminarProfesionalHandler:IRequestHandler<EliminarProf,bool>//inplemento EliminarProf de EliminarProfesional.cs
    {
        private readonly IProfesionalCommandRepository _repository;

        public EliminarProfesionalHandler(IProfesionalCommandRepository repository)
        {
            //en el constructor llamo a la interfaz de Mapper
            _repository = repository;

        }

        //metodo para borrar el profesional
        public async Task<bool> Handle(EliminarProf request, CancellationToken cancellationToken)
        {
            try
            {
                var respuesta = await _repository.BorrarProfesional(request.id);//envio el id del profesional
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
