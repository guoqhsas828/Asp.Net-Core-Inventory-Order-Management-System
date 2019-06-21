using System;
using StoreManager.Interfaces;
using System.Threading.Tasks;
using StoreManager.Models;
using System.Collections.Generic;
//using Ardalis.GuardClauses;
using System.Linq;
using Ardalis.GuardClauses;
using StoreManager.Specifications;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace StoreManager.Services
{
  public class OrderService : IOrderService
  {
    private readonly IAsyncRepository<SalesOrder> _orderRepository;
    private readonly IAsyncRepository<Basket> _basketRepository;
    private readonly IAsyncRepository<Product> _itemRepository;
    private readonly IAsyncRepository<Customer> _customerRepository;
    private readonly IAsyncRepository<Branch> _branchRepository;

    public OrderService(IAsyncRepository<Basket> basketRepository,
        IAsyncRepository<Product> itemRepository,
        IAsyncRepository<SalesOrder> orderRepository,
      IAsyncRepository<Customer> customerRepo,
      IAsyncRepository<Branch> branchRepo)
    {
      _orderRepository = orderRepository;
      _basketRepository = basketRepository;
      _itemRepository = itemRepository;
      _customerRepository = customerRepo;
      _branchRepository = branchRepo;
    }

    public async Task CreateOrderAsync(int basketId, Address shippingAddress)
    {
      var basket = await _basketRepository.GetByIdAsync(basketId);
      Guard.Against.NullBasket(basketId, basket);
      Guard.Against.NullBuyerId(basket?.BuyerId, basket);
      var items = new List<SalesOrderLine>();
      int? ccy = null;
      HashSet<Branch> contacts = new HashSet<Branch>();
      foreach (var item in basket.Items)
      {
        var catalogItem = await _itemRepository.GetByIdAsync(item.CatalogItemId);
        var branch = await _branchRepository.GetByIdAsync(catalogItem.BranchId);
        if (branch != null) contacts.Add(branch);
        var itemOrdered = catalogItem;
        var orderItem = new SalesOrderLine { Product = itemOrdered,
          Price = Convert.ToDouble(item.UnitPrice), Quantity = Convert.ToDouble(item.Quantity),
          ProductId = itemOrdered.ProductId, Amount = item.Quantity };
        orderItem.Total = orderItem.SubTotal = orderItem.Price * orderItem.Quantity;
        if (orderItem.Product != null) ccy = orderItem.Product.CurrencyId;
        items.Add(orderItem);
      }

      var customer = _customerRepository.ListAsync(new CustomerSpecification(basket?.BuyerId)).Result.FirstOrDefault();
      var order = new SalesOrder
      {
        Amount = items.Count,
        Total = items.Sum(t => t.Total),  SalesOrderLines = items ,
        CustomerRefNumber = "Pending",
        OrderDate = DateTimeOffset.Now,
        DeliveryDate = DateTime.Now.AddDays(1),
        SalesOrderName = basket.BuyerId,
        Remarks = "Pick up",
      };

      order.SubTotal = order.Total;

      if (customer != null)
        order.CustomerId = customer.CustomerId;

      if (ccy.HasValue)
        order.CurrencyId = ccy.Value;

      if (contacts.Any())
      {
        order.BranchId = contacts.First().BranchId;
      }
      await _orderRepository.AddAsync(order);

      foreach (var branch in contacts.Where(b => !string.IsNullOrWhiteSpace(b.Phone)))
      {
        SendSmsMessage($"New Order {order.SalesOrderId}: {order.SalesOrderName}", branch.Phone);
      }
    }

    public static void SendSmsMessage(string msgText, string phoneNumber)
    {
      // Find your Account Sid and Token at twilio.com/console
      // DANGER! This is insecure. See http://twil.io/secure
      const string accountSid = "ACb67669cc96d3515c8f72350de005ac27";
      const string authToken = "064ed763e077f935b9c8e4591a4e30c4";

      TwilioClient.Init(accountSid, authToken);

      var message = MessageResource.Create(
          body: msgText,
          from: new Twilio.Types.PhoneNumber("+17323147277"),
          to: new Twilio.Types.PhoneNumber("+1"+phoneNumber)
      );
    }
  }
}
