using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Commands.CuAgregarProfesional
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class AgregarProfesionalHandler:IRequestHandler<AgregarProf,ProfesionalDTO>//inplemento AgregarProfi de AgregarProfesional.cs
    {
        private readonly IProfesionalCommandRepository _repository;
        private readonly IMapper _mapper;

        public AgregarProfesionalHandler(IProfesionalCommandRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de los comandos de profesional y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para agregar profesional
        public async Task<ProfesionalDTO> Handle(AgregarProf request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _repository.CrearProfesional(request.prof);//envio el objeto prof del tipo ProfesionalDTO
                return _mapper.Map<ProfesionalDTO>(resultado);//mapeo el objeto Profesional de la capa dominio en uno de ProfesionalDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
