using AutoMapper;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IProfesional;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data;
using Peluqueria.Infraestructura.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Profesionales
{
    //metodos command del profesional
    //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ProfesionalCommandRepository : IProfesionalCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProfesionalCommandRepository(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> BorrarProfesional(int id)
        {
            try
            {
                var prof = await _context.Profesionals.FindAsync(id);
                if (prof == null)
                {
                    throw new Exception($"No se encontró un profesional con id {id}");
                }
                prof.Visible = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<Profesional> CrearProfesional(ProfesionalDTO prof)
        {
            try
            {
                var profesionalDominio = _mapper.Map<Profesional>(prof);
                var profesionalEntity = _mapper.Map<ProfesionalEntity>(profesionalDominio);
                _context.Profesionals.Add(profesionalEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<Profesional>(profesionalEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " INTERNAS: " + ex.InnerException);
            }
        }

        public async Task<Profesional> EditarProfesional(ProfesionalDTO prof)
        {
            try
            {
                var profesionalDominio = _mapper.Map<Profesional>(prof);
                var profesionalEntity = _mapper.Map<ProfesionalEntity>(profesionalDominio);
                var modificar = await _context.Profesionals.FindAsync(profesionalEntity.IdProfesional);
                if (modificar == null)
                {
                    throw new Exception($"No se encontró un profesional con id {profesionalEntity.IdProfesional}");
                }
                modificar.Nombre = profesionalEntity.Nombre;
                modificar.Apellido = profesionalEntity.Apellido;
                modificar.Especialidad = profesionalEntity.Especialidad;
                modificar.Telefono= profesionalEntity.Telefono; 
                await _context.SaveChangesAsync();
                return _mapper.Map<Profesional>(modificar);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
