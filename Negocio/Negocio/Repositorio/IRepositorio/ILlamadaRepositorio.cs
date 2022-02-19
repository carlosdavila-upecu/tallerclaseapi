using Modelos;

namespace Negocio.Repositorio.IRepositorio
{
    public interface ILlamadaRepositorio
    {
        Task<RegistroLlamadaDTO> RegistrarLlamada(RegistroLlamadaDTO llamadaDTO);
        Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas();
        Task<IEnumerable<RegistroLlamadaDTO>> VerRegistroLlamadas(string idUsuario);
    }
}
