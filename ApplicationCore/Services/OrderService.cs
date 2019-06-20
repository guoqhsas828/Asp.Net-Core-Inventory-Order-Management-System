using System;
using StoreManager.Interfaces;
using System.Threading.Tasks;
using StoreManager.Models;
using System.Collections.Generic;
//using Ardalis.GuardClauses;
using System.Linq;
using Ardalis.GuardClauses;
using StoreManager.Specifications;

namespace StoreManager.Services
{
  public class OrderService : IOrderService
  {
    private readonly IAsyncRepository<SalesOrder> _orderRepository;
    private readonly IAsyncRepository<Basket> _basketRepository;
    private readonly IAsyncRepository<Product> _itemRepository;
    private readonly IAsyncRepository<Customer> _customerRepository;

    public OrderService(IAsyncRepository<Basket> basketRepository,
        IAsyncRepository<Product> itemRepository,
        IAsyncRepository<SalesOrder> orderRepository,
      IAsyncRepository<Customer> customerRepo)
    {
      _orderRepository = orderRepository;
      _basketRepository = basketRepository;
      _itemRepository = itemRepository;
      _customerRepository = customerRepo;
    }

    public async Task CreateOrderAsync(int basketId, Address shippingAddress)
    {
      var basket = await _basketRepository.GetByIdAsync(basketId);
      Guard.Against.NullBasket(basketId, basket);
      Guard.Against.NullBuyerId(basket?.BuyerId, basket);
      var items = new List<SalesOrderLine>();
      foreach (var item in basket.Items)
      {
        var catalogItem = await _itemRepository.GetByIdAsync(item.CatalogItemId);
        var itemOrdered = catalogItem;
        var orderItem = new SalesOrderLine { Product = itemOrdered,
          Price = Convert.ToDouble(item.UnitPrice), Quantity = Convert.ToDouble(item.Quantity),
          ProductId = itemOrdered.ProductId, Amount = item.Quantity };
        orderItem.Total = orderItem.SubTotal = orderItem.Price * orderItem.Quantity;
        items.Add(orderItem);
      }

      var customer = _customerRepository.ListAsync(new CustomerSpecification(basket?.BuyerId)).Result.FirstOrDefault();
      var order = new SalesOrder
      {
        Amount = items.Sum(t => t.Total), Remarks = shippingAddress.Street, SalesOrderLines = items ,
        CustomerRefNumber = basket.BuyerId,
        OrderDate = DateTime.Today,
        DeliveryDate = DateTime.Today.AddDays(1),
        SalesOrderName = basket.BuyerId,
      }; //

      if (customer != null)
        order.CustomerId = customer.CustomerId;

      order.Total = order.SubTotal = order.Amount;
      await _orderRepository.AddAsync(order);
    }
  }
}
