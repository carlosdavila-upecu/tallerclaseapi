using AccessoData;
using AccessoData.Contexto;
using AutoMapper;
using Modelos;
using Negocio.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorio
{
    public class LlamadaRepositorio : ILlamadaRepositorio
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public LlamadaRepositorio(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RegistroLlamadaDTO> RegistrarLlamada(RegistroLlamadaDTO llamadaDTO)
        {
            var llamada = _mapper.Map<RegistroLlamada>(llamadaDTO);
            var nuevoLlamada = _db.RegistroLlamadas.Add(llamada);
            await _db.SaveChangesAsync();
            return _mapper.Map<RegistroLlamadaDTO>(nuevoLlamada.Entity);
        }

        public async Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas()
        {
            return _mapper.Map<IEnumerable<RegistroLlamadaDTO>>(_db.RegistroLlamadas);
        }

        public async Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas(string idUsuario)
        {
            var listaLlamadas = _db.RegistroLlamadas.Where(llamada => llamada.UserId == idUsuario);
            return _mapper.Map<IEnumerable<RegistroLlamadaDTO>>(listaLlamadas);
        }
    }
}
