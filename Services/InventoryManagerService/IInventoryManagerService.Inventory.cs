using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FELFEL.Services.InventoryManagerService;
using FELFEL.Services.DTO;

namespace FELFEL.Services.InventoryManagerService
{
    public partial interface IInventoryManagerService
    {
        Task<ServiceResponse<List<InventoryDTO>>> InventoryAdd(InventoryAddDTO inventoryDTO);
        Task<ServiceResponse<List<InventoryProductDTO>>> GetInventoryByProduct(int? productId);
        Task<ServiceResponse<InventoryStateProductDTO>> GetInventoryByState(int batchStateId);
    }
}