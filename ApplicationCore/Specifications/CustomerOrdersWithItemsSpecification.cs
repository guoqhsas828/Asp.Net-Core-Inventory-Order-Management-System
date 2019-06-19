using StoreManager.Models;

namespace StoreManager.Specifications
{
    public class CustomerOrdersWithItemsSpecification : BaseSpecification<SalesOrder>
    {
        public CustomerOrdersWithItemsSpecification(string buyerId)
            : base(o => o.CustomerRefNumber == buyerId)
        {
            AddInclude(o => o.SalesOrderLines);
            AddInclude($"{nameof(SalesOrder.SalesOrderLines)}.{nameof(SalesOrderLine.Product)}");
        }
    }
}
