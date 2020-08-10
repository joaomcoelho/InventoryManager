using System.Collections.Generic;
using System.Threading.Tasks;
using FELFEL.Services.InventoryManagerService;
using FELFEL.Services.DTO;

namespace FELFEL.Services.InventoryManagerService
{
    public partial interface IInventoryManagerService
    {
        Task<ServiceResponse<BatchDTO>> Get(int id);
        Task<ServiceResponse<List<BatchDTO>>> List();
        Task<ServiceResponse<List<BatchDTO>>> Add(BatchAddDTO batch);
        Task<ServiceResponse<BatchDTO>> Update(BatchUpdateDTO batch);
        Task<ServiceResponse<List<BatchDTO>>> Delete(int id);

        Task<ServiceResponse<List<BatchHistoryDTO>>> GetBatchHistory(int batchId);
    }
}