using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using Peluqueria.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Servicio
{//metodos query del servicio
 //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ServicioQueryRepository : IServicioQueryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ServicioQueryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Dominio.Models.Servicio> BuscarServicio(int id)
        {
            try 
            {
                var serv = await _context.Servicios.Where(c=>c.IdServicio==id && c.Visible==true).FirstOrDefaultAsync();
                if(serv == null) 
                {
                    throw new Exception("No se encontro el Servicio con el id "+id);
                }
                return _mapper.Map<Dominio.Models.Servicio>(serv);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<Dominio.Models.Servicio> BuscarServicioNombre(string nombre)
        {
            try
            {
                var serv = await _context.Servicios.Where(c => c.Nombre.Contains(nombre)&&
                c.Visible==true).FirstOrDefaultAsync();
                if (serv == null)
                {
                    throw new Exception("No se encontro el Servicio con el nombre " + nombre);
                }
                return _mapper.Map<Dominio.Models.Servicio>(serv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<Dominio.Models.Servicio>> ListarServicios()
        {
            try
            {
                var serv = await _context.Servicios.Where(c=>c.Visible==true).ToListAsync();
                if (serv == null)
                {
                    throw new Exception("No se encontraron los Servicio");
                }
                return _mapper.Map<List<Dominio.Models.Servicio>>(serv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
