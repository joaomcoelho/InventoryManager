using System;
using System.Collections.Generic;

namespace FELFEL.Services.DTO
{
    public class BatchDTO
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public BatchStateDTO BatchState { get; set; }
    }
}