using Microsoft.AspNetCore.Mvc;
using FELFEL.Services.InventoryManagerService;
using System.Threading.Tasks;
using FELFEL.Services.DTO;
using System;
using FELFEL.Api.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
            var inventoryModel = new InventoryAddModel();
            inventoryModel.Inventory = inventory;
            inventoryModel.InventoryProduct = (await _InventoryManagerService.GetInventoryByProduct(inventory.ProductId)).Data.FirstOrDefault();

            if (inventoryModel.Validate())
            {
                var response = await _InventoryManagerService.InventoryAdd(inventory);
                if(response.Success){
                     return Ok(response);
                }else{
                    //Not showing the error message from IServiceResponse to the client
                    //For security reasons the client should not know what really happened in the Database  
                    return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = "An unexpected error has ocurred" } );
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, inventoryModel.ValidationErrors);
            }

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