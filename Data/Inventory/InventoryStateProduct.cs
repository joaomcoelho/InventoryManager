using System;
using System.Collections.Generic;

namespace FELFEL.Data
{
    public class InventoryStateProduct
    {
        public int StateId { get; set; }
        public string StateDescription { get; set; }
        public List<Inventory> InventoryList { get; set; }
    }
}