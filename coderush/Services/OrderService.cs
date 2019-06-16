using System;
using StoreManager.Interfaces;
//using StoreManager.Entities.OrderAggregate;
using System.Threading.Tasks;
using StoreManager.Models;
using System.Collections.Generic;
//using Ardalis.GuardClauses;
//using StoreManager.Entities.BasketAggregate;

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
      throw new NotImplementedException();
            //var basket = await _basketRepository.GetByIdAsync(basketId);
            ////Guard.Against.NullBasket(basketId, basket);
            //var items = new List<SalesOrderLine>();
            //foreach (var item in basket.Items)
            //{
            //    var catalogItem = await _itemRepository.GetByIdAsync(item.CatalogItemId);
            //    var itemOrdered = new CatalogItemOrdered(catalogItem.Id, catalogItem.Name, catalogItem.PictureUri);
            //    var orderItem = new SalesOrderLine(itemOrdered, item.UnitPrice, item.Quantity);
            //    items.Add(orderItem);
            //}
            //var order = new SalesOrder(basket.BuyerId, shippingAddress, items);

            //await _orderRepository.AddAsync(order);
        }
    }
}
