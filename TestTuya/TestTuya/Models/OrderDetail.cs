using System;
using System.Collections.Generic;

namespace TestTuya.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int IdProducto { get; set; }
        public string DescripcionProducto { get; set; } = null!;
        public decimal ValorUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
