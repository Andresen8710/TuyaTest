using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestTuya.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime FechaOrden { get; set; }
        public int CustomerId { get; set; }
        public decimal ValorOrden { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
