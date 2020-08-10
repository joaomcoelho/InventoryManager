using System;
using System.Collections.Generic;

namespace FELFEL.Services.DTO
{
    public class InventoryProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<InventoryProductDetailDTO> InventoryList { get; set; }

    }
}