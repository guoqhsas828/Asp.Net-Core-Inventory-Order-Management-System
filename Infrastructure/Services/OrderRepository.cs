using StoreManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StoreManager.Models;

namespace StoreManager.Data
{
    public class OrderRepository : EfRepository<SalesOrder>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<SalesOrder> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.SalesOrder
                .Include(o => o.SalesOrderLines)
                .Include($"{nameof(SalesOrder.SalesOrderLines)}.{nameof(SalesOrderLine.ProductId)}")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
