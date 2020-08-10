using System;
using System.Collections.Generic;

namespace FELFEL.Services.DTO
{
    public class InventoryStateProductDTO
    {
        public int StateId { get; set; }
        public string StateDescription { get; set; }
        public List<InventoryStateProductDetailDTO> InventoryList { get; set; }
    }
}