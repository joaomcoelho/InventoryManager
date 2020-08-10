using System;

namespace FELFEL.Services.DTO
{
    public class InventoryAddDTO
    {
        public int BatchId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public int? SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Reason { get; set; }

    }
}