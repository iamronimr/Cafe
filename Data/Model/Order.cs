

namespace Cafe.Data.Model
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OrderName { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsPayed { get; set; }
        public List<AddIns> AddIns { get; set; }
    }
}
