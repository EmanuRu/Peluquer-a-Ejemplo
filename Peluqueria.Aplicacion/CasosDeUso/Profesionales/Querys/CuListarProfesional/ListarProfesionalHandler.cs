using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuListarProfesional
{
    //las distintas intefases se encuentran dentro de la
    //IRepository
    public class ListarProfesionalHandler : IRequestHandler<ListarProf, List<ProfesionalDTO>>//inplemento ListarProf de ListarProfesional.cs
    {
        private readonly IProfesionalQueryRepository _repository;
        private readonly IMapper _mapper;

        public ListarProfesionalHandler(IProfesionalQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de profesional y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para listar profesionales
        public async Task<List<ProfesionalDTO>> Handle(ListarProf request, CancellationToken cancellationToken)
        {
            try
            {
                var lista = await _repository.ListarProfesionales();//recivo los profesionales
                return _mapper.Map<List<ProfesionalDTO>>(lista);//mapeo el objeto List<Profesional> de la capa dominio en uno de 
            }                                                  //List<ProfesionalDTO> de la capa Aplicación
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
