using System;
using System.Collections.Generic;

namespace FELFEL.Services.DTO
{
    public class InventoryBatchDTO
    {
        public int Stock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public BatchStateDTO BatchState { get; set; }

    }
}