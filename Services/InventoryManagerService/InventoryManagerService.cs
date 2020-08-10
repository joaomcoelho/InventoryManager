using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FELFEL.Data;
using FELFEL.Services.DTO;

namespace FELFEL.Services.InventoryManagerService
{
    public partial class InventoryManagerService : IInventoryManagerService
    {

        public async Task<ServiceResponse<List<InventoryDTO>>> InventoryAdd(InventoryAddDTO inventoryDTO)
        {
            var serviceResponse = new ServiceResponse<List<InventoryDTO>>();
            try
            {
                var list = await new InventoryWorker(_context).Add(_mapper.Map<Inventory>(inventoryDTO), _mapper.Map<InventoryHistory>(inventoryDTO), inventoryDTO.ExpirationDate);
                serviceResponse.Data = list.Select(b => _mapper.Map<InventoryDTO>(b)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<InventoryProductDTO>>> GetInventoryByProduct(int? productId)
        {
            var serviceResponse = new ServiceResponse<List<InventoryProductDTO>>();
            try
            {
                var list = await new InventoryWorker(_context).GetInventoryByProduct(productId);
                serviceResponse.Data = list.Select(p => _mapper.Map<InventoryProductDTO>(p)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<InventoryStateProductDTO>> GetInventoryByState(int batchStateId)
        {
            var serviceResponse = new ServiceResponse<InventoryStateProductDTO>();
            try
            {
                serviceResponse.Data = _mapper.Map<InventoryStateProductDTO>(await new InventoryWorker(_context).GetInventoryByState(batchStateId));
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }
    }
}