using Microsoft.eShopWeb.ApplicationCore.Exceptions;
using StoreManager.Models;

namespace Ardalis.GuardClauses
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }
    }
}