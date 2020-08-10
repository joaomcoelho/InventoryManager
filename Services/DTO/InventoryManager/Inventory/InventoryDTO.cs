using System;

namespace FELFEL.Services.DTO
{
    public class InventoryDTO
    {
        public BatchDTO Batch { get; set; }
        public ProductDTO Product { get; set; }
        public int Stock { get; set; }

    }
}