using System;

namespace FELFEL.Services.DTO
{
    public class InventoryStateProductDetailDTO
    {
        public int BatchId { get; set; }
        public ProductDTO Product { get; set; }
        public int Stock { get; set; }

    }
}