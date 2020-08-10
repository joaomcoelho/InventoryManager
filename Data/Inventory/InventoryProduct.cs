using System;
using System.Collections.Generic;

namespace FELFEL.Data
{
    public class InventoryProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<Inventory> InventoryList { get; set; }
    }
}