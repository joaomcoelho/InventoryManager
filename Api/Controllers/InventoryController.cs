using Microsoft.AspNetCore.Mvc;
using FELFEL.Services.InventoryManagerService;
using System.Threading.Tasks;
using FELFEL.Services.DTO;
using System;

namespace FELFEL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryManagerService _InventoryManagerService;

        public InventoryController(IInventoryManagerService InventoryManagerService)
        {
            _InventoryManagerService = InventoryManagerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(InventoryAddDTO inventory)
        {
            return Ok(await _InventoryManagerService.InventoryAdd(inventory));
        }

        [HttpGet("Product/{productId?}")]
        public async Task<IActionResult> GetInventoryByProduct(int? productId = null)
        {
            return Ok(await _InventoryManagerService.GetInventoryByProduct(productId));
        }


        [HttpGet("State/{batchStateId}")]
        public async Task<IActionResult> GetInventoryByState(int batchStateId)
        {
            return Ok(await _InventoryManagerService.GetInventoryByState(batchStateId));
        }

    }
}