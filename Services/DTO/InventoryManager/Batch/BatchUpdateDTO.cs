using System;

namespace FELFEL.Services.DTO
{
    public class BatchUpdateDTO
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int BatchStateID { get; set; }
    }
}