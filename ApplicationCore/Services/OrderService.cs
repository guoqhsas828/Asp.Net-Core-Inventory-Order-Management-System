using System;
using StoreManager.Interfaces;
using System.Threading.Tasks;
using StoreManager.Models;
using System.Collections.Generic;
//using Ardalis.GuardClauses;
using System.Linq;

namespace StoreManager.Services
{
  public class OrderService : IOrderService
  {
    private readonly IAsyncRepository<SalesOrder> _orderRepository;
    private readonly IAsyncRepository<Basket> _basketRepository;
    private readonly IAsyncRepository<Product> _itemRepository;

    public OrderService(IAsyncRepository<Basket> basketRepository,
        IAsyncRepository<Product> itemRepository,
        IAsyncRepository<SalesOrder> orderRepository)
    {
      _orderRepository = orderRepository;
      _basketRepository = basketRepository;
      _itemRepository = itemRepository;
    }

    public async Task CreateOrderAsync(int basketId, Address shippingAddress)
    {
      var basket = await _basketRepository.GetByIdAsync(basketId);
      //Guard.Against.NullBasket(basketId, basket);
      var items = new List<SalesOrderLine>();
      foreach (var item in basket.Items)
      {
        var catalogItem = await _itemRepository.GetByIdAsync(item.CatalogItemId);
        var itemOrdered = catalogItem;
        var orderItem = new SalesOrderLine { Product = itemOrdered, Price = Convert.ToDouble(item.UnitPrice), Quantity = Convert.ToDouble(item.Quantity), ProductId = itemOrdered.ProductId, Amount = item.Quantity };
        items.Add(orderItem);
      }
      var order = new SalesOrder { Amount = items.Sum(t => t.Total), Remarks = shippingAddress.Street, SalesOrderLines = items }; //CustomerId = basket.BuyerId,

      await _orderRepository.AddAsync(order);
    }
  }
}
