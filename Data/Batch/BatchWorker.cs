using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FELFEL.Data
{
    public class BatchWorker : BaseWorker
    {
        public BatchWorker(DataContext context) : base(context) { }

        public async Task<Batch> Get(int id)
        {
            return await _context.Batch.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Batch>> List()
        {
            return await _context.Batch.ToListAsync();
        }

        public async Task<List<Batch>> Add(Batch batch)
        {
            var list = await _context.Batch.AddAsync(batch);
            await _context.SaveChangesAsync();

            return await _context.Batch.Include(b => b.BatchState).ToListAsync();
        }

        public async Task<Batch> Update(Batch batch)
        {
            var updatedBatch = await _context.Batch.FirstOrDefaultAsync(b => b.Id == batch.Id);
            updatedBatch.ExpirationDate = batch.ExpirationDate;
            updatedBatch.BatchStateId = batch.BatchStateId;

            _context.Batch.Update(updatedBatch);
            await _context.SaveChangesAsync();

            return await _context.Batch.Include(b => b.BatchState).FirstOrDefaultAsync(b => b.Id == updatedBatch.Id);
        }

        public async Task<List<Batch>> Delete(int id)
        {
            var deleteBatch = await _context.Batch.FirstAsync(b => b.Id == id);
            _context.Batch.Remove(deleteBatch);
            await _context.SaveChangesAsync();

            return await _context.Batch.Include(b => b.BatchState).ToListAsync(); ;
        }

        public async Task<List<BatchHistory>> GetBatchHistory(int batchId)
        {
            var batchHistoryList = new List<BatchHistory>();
            var query = await (from b in _context.Batch
                                       join i in _context.Inventory on b.Id equals i.BatchId
                                       join p in _context.Product on i.ProductId equals p.Id
                                       join ih in _context.InventoryHistory on i.Id equals ih.InventoryId
                                       join c in _context.Customer on ih.CustomerId equals c.Id into cc from c in cc.DefaultIfEmpty()
                                       join s in _context.Supplier on ih.SupplierId equals s.Id into ss from s in ss.DefaultIfEmpty()
                                       where b.Id == batchId
                                       select new
                                       {
                                           BatchId = b.Id,
                                           ExpirationDate = b.ExpirationDate,
                                           ProductId = i.ProductId,
                                           ProductName = p.Name,
                                           SupplierId = ih.SupplierId,
                                           SupplierName = s.Name,
                                           CustomerId = ih.CustomerId,
                                           CustomerName = c.Name,
                                           Stock = ih.Stock,
                                           Reason = ih.Reason,
                                           CreationDate = ih.CreationDate,
                                       }).ToListAsync();

            foreach (var row in query)
            {
                var batchHistory = new BatchHistory();
                batchHistory.BatchId = row.BatchId;
                batchHistory.ExpirationDate = row.ExpirationDate;
                batchHistory.ProductId = row.ProductId;
                batchHistory.ProductName = row.ProductName;
                batchHistory.SupplierId = row.SupplierId;
                batchHistory.SupplierName = row.SupplierName;
                batchHistory.CustomerId = row.CustomerId;
                batchHistory.CustomerName = row.CustomerName;
                batchHistory.Stock = row.Stock;
                batchHistory.Reason = row.Reason;
                batchHistory.CreationDate = row.CreationDate;

                batchHistoryList.Add(batchHistory);
            }
            return batchHistoryList.OrderBy(bh => bh.CreationDate).ToList();
        }

    }
}