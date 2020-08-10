using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FELFEL.Library.Enums;
using Microsoft.EntityFrameworkCore;

namespace FELFEL.Data
{
    public class InventoryWorker : BaseWorker
    {
        public InventoryWorker(DataContext context) : base(context) { }

        public async Task<Inventory> Get(int id)
        {
            return await _context.Inventory.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Inventory>> List()
        {
            return await _context.Inventory.ToListAsync();
        }


        private int _calculateFreshness(DateTime expirationDate)
        {
            if (expirationDate.Date < DateTime.Now.Date)
            {
                return BatchStateTypes.Expired;
            }
            if (expirationDate.Date == DateTime.Now.Date)
            {
                return BatchStateTypes.ExpiringToday;
            }

            return BatchStateTypes.Fresh;
        }

        public async Task<List<Inventory>> Add(Inventory Inventory, InventoryHistory InventoryHistory, DateTime expirationDate)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                /*
                    Validates if exists a batch for the expirationDate.
                    - Create a batch if does not exist.
                    - Get the batch if exists.
                */
                Batch batch = await _context.Batch.Include(b => b.BatchState).FirstOrDefaultAsync(b => b.ExpirationDate == expirationDate);
                if (batch == null)
                {
                    batch = new Batch { ExpirationDate = expirationDate, BatchStateId = _calculateFreshness(expirationDate) };
                    await _context.Batch.AddAsync(batch);
                    await _context.SaveChangesAsync();
                }

                /*
                    Validates if already exists a product for this batch.
                    - Create a ProductBatch with Stock value if does not exist.
                    - Update the ProductBatch Stock value if exists.
                */
                Inventory.BatchId = batch.Id;
                Inventory InventoryDb = await _context.Inventory.FirstOrDefaultAsync(bp => bp.BatchId == batch.Id && bp.ProductId == Inventory.ProductId);
                if (InventoryDb == null)
                {
                    InventoryDb = Inventory;
                    await _context.Inventory.AddAsync(InventoryDb);
                }
                else
                {
                    InventoryDb.Stock += Inventory.Stock;
                    _context.Inventory.Update(InventoryDb);
                }
                await _context.SaveChangesAsync();

                /*
                    Creates a record on InventoryHistory to track the history of a batch
                */
                InventoryHistory.InventoryId = InventoryDb.Id;
                InventoryHistory.Stock = Inventory.Stock;
                InventoryHistory.CreationDate = DateTime.Now;
                await _context.InventoryHistory.AddAsync(InventoryHistory);
                await _context.SaveChangesAsync();

                dbContextTransaction.Commit();

                return await _context.Inventory.Include(i => i.Product).ToListAsync();
            }
        }

        public async Task<List<InventoryProduct>> GetInventoryByProduct(int? productId)
        {
            var inventoryProductList = new List<InventoryProduct>();

            var productList = await _context.Product
                                         .Where(p => !productId.HasValue || p.Id == productId)
                                         .ToListAsync();

            foreach (var product in productList)
            {
                var inventoryProduct = new InventoryProduct();
                inventoryProduct.ProductId = product.Id;
                inventoryProduct.ProductName = product.Name;

                inventoryProduct.InventoryList = await _context.Inventory
                                         .Include(b => b.Batch)
                                         .ThenInclude(b => b.BatchState)
                                         .Where(i => i.ProductId == product.Id)
                                         .ToListAsync();

                inventoryProductList.Add(inventoryProduct);
            }
            return inventoryProductList;
        }

        public async Task<InventoryStateProduct> GetInventoryByState(int batchStateId)
        {
            var inventoryStateProduct = new InventoryStateProduct();
            var batchState = await _context.BatchState.Where(s => s.Id == batchStateId).FirstOrDefaultAsync();
            inventoryStateProduct.StateId = batchStateId;
            inventoryStateProduct.StateDescription = batchState.Description;

            var query = await (from b in _context.Batch
                               join i in _context.Inventory on b.Id equals i.BatchId
                               where b.BatchState.Id == batchStateId
                               select i
                               ).Include(b => b.Batch).Include(p => p.Product).ToListAsync();

            inventoryStateProduct.InventoryList = query;

            return inventoryStateProduct;
        }
    }
}