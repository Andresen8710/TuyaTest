namespace TestTuya.DTOs.RequestDTOs
{
    public class RequestInsertOrderDTO
    {
        public int customerId { get; set; }
        public decimal ValorOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<Details> DetalleOrden { get; set; }

    }

    public class Details
    {
        public int orderId { get; set; }
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
