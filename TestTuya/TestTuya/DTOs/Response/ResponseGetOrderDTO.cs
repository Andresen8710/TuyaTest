namespace TestTuya.DTOs.Response
{
    public class ResponseGetOrderDTO
    {
        public int Id { get; set; }
        public DateTime FechaOrden { get; set; }
        public int CustomerId { get; set; }
        public decimal ValorOrden { get; set; }
    }
}
