﻿
namespace Cafe.Data.Model
{
    public class Payments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid OrderId { get; set; }
    }
}
