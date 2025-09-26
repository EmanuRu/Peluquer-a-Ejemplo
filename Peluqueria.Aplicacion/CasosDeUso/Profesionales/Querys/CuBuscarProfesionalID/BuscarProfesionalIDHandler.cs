using AutoMapper;
using MediatR;
using Peluqueria.Aplicacion.CasosDeUso.Cliente.Querys.CuListarClientes;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Aplicacion.CasosDeUso.Profesionales.Querys.CuBuscarProfesionalID
{
    //las distintas intefases se encuentran dentro de la carpeta IRepository
    public class BuscarProfesionalIDHandler : IRequestHandler<BuscarProfID, ProfesionalDTO>//inplemento BuscarProfID de BuscarProfesionalID.cs
    {
        private readonly IProfesionalQueryRepository _repository;
        private readonly IMapper _mapper;

        public BuscarProfesionalIDHandler(IProfesionalQueryRepository repository, IMapper mapper)
        {
            //en el constructor llamo a la interfaz de las consultas de profesional y a la interfaz de Mapper
            _repository = repository;
            _mapper = mapper;
        }

        //metodo para buscar el profesional por id
        public async Task<ProfesionalDTO> Handle(BuscarProfID request, CancellationToken cancellationToken)
        {
            try
            {
                var cli = await _repository.Buscarprofesional(request.id);//envio el id
                return _mapper.Map<ProfesionalDTO>(cli);//mapeo el objeto Profesional de la capa dominio en uno de ProfesionalDTO de la capa Aplicación
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
