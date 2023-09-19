namespace TestTuya.DTOs.RequestDTOs
{
    public class RequestInsertCustomerDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public long Telefono { get; set; }
        public string? Email { get; set; }
    }
}
