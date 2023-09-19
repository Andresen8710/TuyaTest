using System;
using System.Collections.Generic;

namespace TestTuya.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public long Telefono { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
