using System;

namespace FELFEL.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public int OrderStateId { get; set; }
        public DateTime CreationDate { get; set; }

        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
        public OrderState OrderState { get; set; }

    }
}