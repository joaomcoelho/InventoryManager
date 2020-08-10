using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FELFEL.Data;
using FELFEL.Services.InventoryManagerService;
using FELFEL.Services.DTO;

namespace FELFEL.Services.InventoryManagerService
{
    public partial class InventoryManagerService : IInventoryManagerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public InventoryManagerService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BatchDTO>> Get(int id)
        {
            var serviceResponse = new ServiceResponse<BatchDTO>();
            try
            {
                serviceResponse.Data = _mapper.Map<BatchDTO>(await new BatchWorker(_context).Get(id));
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BatchDTO>>> List()
        {
            var serviceResponse = new ServiceResponse<List<BatchDTO>>();
            try
            {
                var list = await new BatchWorker(_context).List();
                serviceResponse.Data = list.Select(b => _mapper.Map<BatchDTO>(b)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BatchDTO>>> Add(BatchAddDTO batchDTO)
        {
            var serviceResponse = new ServiceResponse<List<BatchDTO>>();
            try
            {
                var list = await new BatchWorker(_context).Add(_mapper.Map<Batch>(batchDTO));
                serviceResponse.Data = list.Select(b => _mapper.Map<BatchDTO>(b)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<BatchDTO>> Update(BatchUpdateDTO batchDTO)
        {
            var serviceResponse = new ServiceResponse<BatchDTO>();
            try
            {
                var batch = _mapper.Map<Batch>(batchDTO);
                serviceResponse.Data = _mapper.Map<BatchDTO>(await new BatchWorker(_context).Update(batch));
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BatchDTO>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<BatchDTO>>();
            try
            {
                var list = await new BatchWorker(_context).Delete(id);
                serviceResponse.Data = list.Select(b => _mapper.Map<BatchDTO>(b)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BatchHistoryDTO>>> GetBatchHistory(int batchId)
        {
            var serviceResponse = new ServiceResponse<List<BatchHistoryDTO>>();
            try
            {
                var list = await new BatchWorker(_context).GetBatchHistory(batchId);
                serviceResponse.Data = list.Select(b => _mapper.Map<BatchHistoryDTO>(b)).ToList();
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