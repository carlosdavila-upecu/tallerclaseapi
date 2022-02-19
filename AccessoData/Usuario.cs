using Microsoft.AspNetCore.Identity;

namespace AccessoData
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public decimal Tarifa { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
