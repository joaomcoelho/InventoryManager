using System;

namespace FELFEL.Services.DTO
{
    public class InventoryProductDetailDTO
    {
        public BatchDTO Batch { get; set; }
        public int Stock { get; set; }
    }
}