using System;
using System.Collections.Generic;

namespace FELFEL.Data
{
    public class InventoryBatch
    {
        public DateTime ExpirationDate { get; set; }
        public int Stock { get; set; }
        public BatchState BatchState { get; set; }
    }
}