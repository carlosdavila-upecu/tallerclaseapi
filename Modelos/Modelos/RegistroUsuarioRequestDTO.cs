namespace Modelos
{
    public class RegistroUsuarioRequestDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public decimal Tarifa { get; set; }
        public string Contrasenia { get; set; }
    }
}
