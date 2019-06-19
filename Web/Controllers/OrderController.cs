using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using StoreManager.Interfaces;
using StoreManager.Specifications;

namespace Microsoft.eShopWeb.Web.Controllers
{
  [ApiExplorerSettings(IgnoreApi = true)]
  [Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
  [Route("[controller]/[action]")]
  public class OrderController : Controller
  {
    private readonly IOrderRepository _orderRepository;
    private readonly IUriComposer _uriComposer;
    public OrderController(IOrderRepository orderRepository, IUriComposer uriComposer)
    {
      _orderRepository = orderRepository;
      _uriComposer = uriComposer;
    }

    [HttpGet()]
    public async Task<IActionResult> MyOrders()
    {
      var orders = await _orderRepository.ListAsync(new CustomerOrdersWithItemsSpecification(User.Identity.Name));

      var viewModel = orders
          .Select(o => new OrderViewModel()
          {
            OrderDate = o.OrderDate,
            OrderItems = o.SalesOrderLines?.Select(oi => new OrderItemViewModel()
            {
              Discount = 0,
              PictureUrl = _uriComposer.ComposePicUri(oi.Product.ProductImageUrl),
              ProductId = oi.Product.ProductId,
              ProductName = oi.Product.ProductName,
              UnitPrice = Convert.ToDecimal(oi.Price),
              Units = Convert.ToInt32(oi.Quantity)
            }).ToList(),
            OrderNumber = o.Id,
            //ShippingAddress = o.ShipToAddress,
            OrderNotes = o.Remarks,
            Status = "Pending",
            Total = Convert.ToDecimal(o.Total),
          });
      return View(viewModel);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> Detail(int orderId)
    {
      var customerOrders = await _orderRepository.ListAsync(new CustomerOrdersWithItemsSpecification(User.Identity.Name));
      var order = customerOrders.FirstOrDefault(o => o.Id == orderId);
      if (order == null)
      {
        return BadRequest("No such order found for this user.");
      }
      var viewModel = new OrderViewModel()
      {
        OrderDate = order.OrderDate,
        OrderItems = order.SalesOrderLines?.Select(oi => new OrderItemViewModel()
        {
          Discount = 0,
          PictureUrl = _uriComposer.ComposePicUri(oi.Product.ProductImageUrl),
          ProductId = oi.Product.ProductId,
          ProductName = oi.Product.ProductName,
          UnitPrice = Convert.ToDecimal(oi.Price),
          Units = Convert.ToInt32(oi.Quantity)
        }).ToList(),
        OrderNumber = order.Id,
        //ShippingAddress = order.ShipToAddress,
        OrderNotes = order.Remarks,
        Status = "Pending",
        Total = Convert.ToDecimal( order.Total)
      };
      return View(viewModel);
    }
  }
}
