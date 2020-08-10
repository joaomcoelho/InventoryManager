using Microsoft.AspNetCore.Mvc;
using FELFEL.Services.InventoryManagerService;
using System.Threading.Tasks;
using FELFEL.Services.DTO;

namespace FELFEL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatchController : ControllerBase
    {
        private readonly IInventoryManagerService _InventoryManagerService;

        public BatchController(IInventoryManagerService InventoryManagerService)
        {
            _InventoryManagerService = InventoryManagerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _InventoryManagerService.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _InventoryManagerService.List());
        }

        [HttpPost]
        public async Task<IActionResult> Add(BatchAddDTO batch)
        {
            return Ok(await _InventoryManagerService.Add(batch));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BatchUpdateDTO batch)
        {
            return Ok(await _InventoryManagerService.Update(batch));
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _InventoryManagerService.Delete(id));
        }

        [HttpGet("History/{batchId}")]
        public async Task<IActionResult> GetBatchHistory(int batchId)
        {
            return Ok(await _InventoryManagerService.GetBatchHistory(batchId));
        }
    }
}