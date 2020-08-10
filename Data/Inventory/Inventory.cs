using System;
using System.Collections.Generic;

namespace FELFEL.Data
{
    public class Inventory
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }

        public Batch Batch { get; set; }
        public Product Product { get; set; }
    }
}