using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuEditarProfesional
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class EditarProfesionalHandler:IRequestHandler<Editarprof,ProfesionalDTO>//inplemento Editarprof de EditarProfesional.cs
    {
        private readonly IProfesionalCommandRepository _repository;
        private readonly IMapper _mapper;

        public EditarProfesionalHandler(IProfesionalCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de profesional y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para editar el profesional
        public async Task<ProfesionalDTO> Handle(Editarprof request, CancellationToken cancellationToken)
        {
            try
            {
                var profesional = await _repository.EditarProfesional(request.prof);//envio el objeto prof del tipo ProfesionalDTO
                return _mapper.Map<ProfesionalDTO>(profesional);//mapeo el objeto Profesional de la capa dominio en uno de ProfesionalDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
