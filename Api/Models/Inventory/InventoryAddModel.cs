using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FELFEL.Services.DTO;
using FELFEL.Services.InventoryManagerService;

namespace FELFEL.Api.Models
{
    public class InventoryAddModel
    {
        public InventoryAddDTO Inventory { get; set; }
        public List<ValidationError> ValidationErrors = new List<ValidationError>();
        public InventoryProductDTO InventoryProduct { get; set; }
        public bool Validate() {

            int? currentStock = InventoryProduct?.InventoryList.Where(p => p.Batch.ExpirationDate == Inventory.ExpirationDate).FirstOrDefault()?.Stock;
            currentStock= currentStock.GetValueOrDefault(0);

            if(InventoryProduct == null){
                ValidationErrors.Add(new ValidationError {FieldName = "ProductID", ValidationMessage = $"Product does not exist" });
            }

            if(currentStock + Inventory.Stock < 0){
                ValidationErrors.Add(new ValidationError {FieldName = "Stock", ValidationMessage = $"Current Stock is {currentStock} and cannot be negative." });
            }

            return ValidationErrors.Count == 0;
        }
    }
}