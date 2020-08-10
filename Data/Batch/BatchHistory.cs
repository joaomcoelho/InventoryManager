using System;

namespace FELFEL.Data
{
    public class BatchHistory
    {
        public int BatchId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Stock { get; set; }
        public string Reason { get; set; }
        public DateTime CreationDate { get; set; }

    }
}