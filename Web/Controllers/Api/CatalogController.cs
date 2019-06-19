using System;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Infrastructure.Identity;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Controllers.Api
{
  public class CatalogController : BaseApiController
  {
    private readonly ICatalogViewModelService _catalogViewModelService;
    private readonly IBasketService _basketService;
    private const string _basketSessionKey = "basketId";
    private readonly IUriComposer _uriComposer;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private string _username = null;
    private readonly IBasketViewModelService _basketViewModelService;

    public CatalogController(ICatalogViewModelService catalogViewModelService,
      IBasketService basketService,
      IBasketViewModelService basketViewModelService,
      IUriComposer uriComposer,
      SignInManager<ApplicationUser> signInManager)
    {
      _catalogViewModelService = catalogViewModelService;
      _basketService = basketService;
      _uriComposer = uriComposer;
      _signInManager = signInManager;
      _basketViewModelService = basketViewModelService;
    }

    [HttpGet]
    public async Task<IActionResult> List(int? brandFilterApplied, int? typesFilterApplied, int? page)
    {
      var itemsPage = 10;
      var catalogModel =
        await _catalogViewModelService.GetCatalogItems(page ?? 0, itemsPage, brandFilterApplied, typesFilterApplied);
      return Ok(catalogModel);
    }

    public async Task<IActionResult> AddToBasket(CatalogItemViewModel productDetails)
    {
      if (productDetails?.Id == null)
      {
        return RedirectToPage("/Index");
      }

      await SetBasketModelAsync();

      await _basketService.AddItemToBasket(BasketModel.Id, productDetails.Id, productDetails.Price, 1);

      await SetBasketModelAsync();

      return RedirectToPage();
    }

    private async Task SetBasketModelAsync()
    {
      if (_signInManager.IsSignedIn(HttpContext.User))
      {
        BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
      }
      else
      {
        GetOrSetBasketCookieAndUserName();
        BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(_username);
      }
    }

    private void GetOrSetBasketCookieAndUserName()
    {
      if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
      {
        _username = Request.Cookies[Constants.BASKET_COOKIENAME];
      }

      if (_username != null) return;

      _username = Guid.NewGuid().ToString();
      var cookieOptions = new CookieOptions {IsEssential = true};
      cookieOptions.Expires = DateTime.Today.AddYears(10);
      Response.Cookies.Append(Constants.BASKET_COOKIENAME, _username, cookieOptions);
    }
  }
}
