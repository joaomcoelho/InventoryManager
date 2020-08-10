using System;
using System.Collections.Generic;

namespace FELFEL.Data
{
    public class Batch
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int BatchStateId { get; set; }

        public BatchState BatchState { get; set; }
    }
}