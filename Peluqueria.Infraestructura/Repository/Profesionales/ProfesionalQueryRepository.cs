using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Profesionales
{//metodos query del estadoreserva
 //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ProfesionalQueryRepository : IProfesionalQueryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProfesionalQueryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Profesional> Buscarprofesional(int id)
        {
            try
            {
                var prof = await _context.Profesionals.Where(p => p.IdProfesional == id && p.Visible == true).FirstOrDefaultAsync();
                if (prof == null)
                {
                    throw new Exception("No se encontro el profesional con el id " + id);
                }
                return _mapper.Map<Profesional>(prof);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message+" error interno: "+ex.InnerException);

            }
        }

        public async Task<Profesional> BuscarProfesionalNombre(string nombre)
        {
            try
            {
                var prof = await _context.Profesionals.Where(p => (p.Nombre.Contains(nombre) || p.Apellido.Contains(nombre)) &&
                p.Visible == true).FirstOrDefaultAsync();
                if (prof == null)
                {
                    throw new Exception("No se encontro el profesional con el nombre " + nombre);
                }
                return _mapper.Map<Profesional>(prof);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " error interno: " + ex.InnerException);

            }
        }

        public async Task<List<Profesional>> ListarProfesionales()
        {
            try
            {
                var prof = await _context.Profesionals.Where(p => p.Visible == true).ToListAsync();
                if (prof == null)
                {
                    throw new Exception("No se encontraron a los profesionales");
                }
                return _mapper.Map<List<Profesional>>(prof);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " error interno: " + ex.InnerException);

            }
        }
    }
}
