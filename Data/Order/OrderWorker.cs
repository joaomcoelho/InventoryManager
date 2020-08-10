using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FELFEL.Data
{
    public class OrderWorker : BaseWorker
    {
        public OrderWorker(DataContext context) : base(context) { }

        public async Task<Order> Get(int id)
        {
            return await _context.Order.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Order>> List()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<List<Order>> Add(Order order)
        {
            var list = await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            return await _context.Order.ToListAsync();
        }

        public async Task<Order> Update(Order order)
        {
            var updatedOrder = await _context.Order.FirstOrDefaultAsync(b => b.Id == order.Id);

            _context.Order.Update(updatedOrder);
            await _context.SaveChangesAsync();

            return updatedOrder;
        }

        public async Task<List<Order>> Delete(int id)
        {
            var deleteOrder = await _context.Order.FirstAsync(b => b.Id == id);
            _context.Order.Remove(deleteOrder);
            await _context.SaveChangesAsync();

            return await _context.Order.ToListAsync(); ;
        }


    }
}