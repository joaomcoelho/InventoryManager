using System;

namespace FELFEL.Data
{
    public class InventoryHistory
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int? SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public int Stock { get; set; }
        public string Reason { get; set; }
        public DateTime CreationDate { get; set; }
        
        public Inventory Inventory { get; set; }
        public Supplier Supplier { get; set; }
        public Customer Customer { get; set; }

    }
}