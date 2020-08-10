using System;

namespace FELFEL.Services.DTO
{
    public class BatchAddDTO
    {
        public DateTime ExpirationDate { get; set; }
        public int BatchStateID { get; set; }
    }
}