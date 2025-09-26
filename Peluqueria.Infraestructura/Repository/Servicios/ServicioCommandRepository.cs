using AutoMapper;
using Peluqueria.Aplicacion.Data.ModelsDTO;
using Peluqueria.Aplicacion.IRepository.IServicio;
using Peluqueria.Dominio.Models;
using Peluqueria.Infraestructura.Data;
using Peluqueria.Infraestructura.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peluqueria.Infraestructura.Repository.Servicios
{
    //metodos command del servicio
    //los metodos cuentan con nombres descriptivos de sus respectivas acciones
    public class ServicioCommandRepository : IServicioCommandRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ServicioCommandRepository(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> BorrarServicio(int id)
        {
            try
            {
                var serv = await _context.Servicios.FindAsync(id);
                if (serv == null)
                {
                    throw new Exception($"No se encontró un Servicio con id {id}");
                }
                serv.Visible= false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Dominio.Models.Servicio> CrearServicio(ServicioDTO serv)
        {
            try 
            {
                var ServicioDominio = _mapper.Map<Dominio.Models.Servicio>(serv);
                var ServicioEntity = _mapper.Map<ServicioEntity>(ServicioDominio);
                _context.Servicios.Add(ServicioEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<Dominio.Models.Servicio>(ServicioEntity);
            }
            catch (Exception ex) 
            { 
                throw new Exception( ex.Message+" INTERNAS: "+ex.InnerException); 
            }
        }

        public async Task<Dominio.Models.Servicio> EditarServicio(ServicioDTO serv)
        {
            try 
            {
                var ServicioDominio = _mapper.Map<Dominio.Models.Servicio>(serv);
                var ServicioEntity = _mapper.Map<ServicioEntity>(ServicioDominio);
                var modificar = await _context.Servicios.FindAsync(ServicioEntity.IdServicio);
                if (modificar == null)
                {
                    throw new Exception($"No se encontró un Servicio con id {ServicioEntity.IdServicio}");
                }
                modificar.Nombre= ServicioEntity.Nombre;
                modificar.Descripcion = ServicioEntity.Descripcion;
                modificar.DuracionMinutos = ServicioEntity.DuracionMinutos;
                await _context.SaveChangesAsync();
                return _mapper.Map<Dominio.Models.Servicio>(modificar);

            } 
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }
    }
}
