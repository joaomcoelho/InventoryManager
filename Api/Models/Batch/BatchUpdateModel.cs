using System.Collections.Generic;
using System.Threading.Tasks;
using FELFEL.Services.DTO;
using FELFEL.Services.InventoryManagerService;

namespace FELFEL.Api.Models
{
    public class BatchUpdateModel
    {
        public BatchUpdateDTO Batch { get; set; }
        public List<ValidationError> ValidationErrors = new List<ValidationError>();
        public List<BatchDTO> BatchList { get; set; }
        public bool Validate() {
            bool expirationDateExists = BatchList.Exists(b => b.ExpirationDate == Batch.ExpirationDate);

            if(expirationDateExists){
                ValidationErrors.Add(new ValidationError {FieldName = "ExpirationDate", ValidationMessage = "Expiration date already exists." });
            }

            return ValidationErrors.Count == 0;
        }
    }
}