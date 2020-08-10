using AutoMapper;
using FELFEL.Data;
using FELFEL.Services.DTO;

namespace FELFEL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Batch, BatchDTO>();
            CreateMap<BatchAddDTO, Batch>();
            CreateMap<BatchUpdateDTO, Batch>();

            CreateMap<Inventory, InventoryDTO>();
            CreateMap<InventoryDTO, Inventory>();
            CreateMap<InventoryAddDTO, Inventory>();
            CreateMap<InventoryAddDTO, InventoryHistory>();

            CreateMap<Product, ProductDTO>();
            CreateMap<BatchState, BatchStateDTO>();

            CreateMap<InventoryProduct, InventoryProductDTO>();
            CreateMap<InventoryProductDTO, InventoryProduct>();

            CreateMap<Inventory, InventoryProductDetailDTO>();
            CreateMap<InventoryProductDetailDTO, Inventory>();

            CreateMap<InventoryBatch, InventoryBatchDTO>();
            CreateMap<InventoryBatchDTO, InventoryBatch>();

            CreateMap<BatchHistory, BatchHistoryDTO>();
            CreateMap<BatchHistoryDTO, BatchHistory>();

            CreateMap<InventoryStateProduct, InventoryStateProductDTO>();
            CreateMap<InventoryStateProductDTO, InventoryStateProduct>();

            CreateMap<Inventory, InventoryStateProductDetailDTO>();
            CreateMap<InventoryStateProductDetailDTO, Inventory>();
        }
    }
}