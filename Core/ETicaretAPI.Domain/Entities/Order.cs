using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public Guid CustomerId {  get; set; }
        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
