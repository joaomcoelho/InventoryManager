using Microsoft.AspNetCore.Mvc;
using FELFEL.Services.InventoryManagerService;
using System.Threading.Tasks;
using FELFEL.Services.DTO;
using FELFEL.Api.Models;
using System;
using Microsoft.AspNetCore.Http;

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
            var batchModel = new BatchAddModel();
            batchModel.Batch = batch;
            batchModel.BatchList = (await _InventoryManagerService.List()).Data;

            if (batchModel.Validate())
            {
                var response = await _InventoryManagerService.Add(batch);
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
                return StatusCode(StatusCodes.Status400BadRequest, batchModel.ValidationErrors);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update(BatchUpdateDTO batch)
        {

            var batchModel = new BatchUpdateModel();
            batchModel.Batch = batch;
            batchModel.BatchList = (await _InventoryManagerService.List()).Data;

            if (batchModel.Validate())
            {
                var response = await _InventoryManagerService.Update(batch);
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
                return StatusCode(StatusCodes.Status400BadRequest, batchModel.ValidationErrors);
            }
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