using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuBuscarClienteID;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuBuscarProfesionalNom
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarProfesionalNomHandler : IRequestHandler<BuscarProfNom, ProfesionalDTO>//inplemento BuscarProfNom de BuscarProfesionalNom.cs
    {
        private readonly IProfesionalQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarProfesionalNomHandler(IProfesionalQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de profesional y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para buscar el profesional por nombre
        public async Task<ProfesionalDTO> Handle(BuscarProfNom request, CancellationToken cancellationToken)
        {
            try
            {
                var prof = await _repository.BuscarProfesionalNombre(request.nom);//envio el nombre
                return _mapper.Map<ProfesionalDTO>(prof);//mapeo el objeto Profesional de la capa dominio en uno de ProfesionalDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
